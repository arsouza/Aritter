using System.Linq;
using System.Threading.Tasks;
using Ritter.Application.Extensions;
using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.Adapters;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Application.People
{
    public class PersonAppService : AppService, IPersonAppService
    {
        private readonly IPersonRepository personRepository;
        private readonly IEntityValidator entityValidator;
        private readonly ITypeAdapter adapter;

        public PersonAppService(
            IPersonRepository personRepository,
            IEntityValidator entityValidator,
            ITypeAdapter adapter)
            : base()
        {
            this.personRepository = personRepository;
            this.entityValidator = entityValidator;
            this.adapter = adapter;
        }

        public async Task<IPagedCollection<PersonResponse>> FindPaginatedAsync(Pagination pagination)
        {
            IPagedCollection<Person> people = await personRepository.FindAsync(pagination);
            return adapter.ProjectAsPagedCollection<PersonResponse>(people);
        }

        public async Task<PersonResponse> GetPersonAsync(string id)
        {
            Person person = await personRepository.FindAsync(id)
                ?? throw new NotFoundException("Pessoa não encontrada");

            return adapter.ProjectAs<PersonResponse>(person);
        }

        public async Task<PersonResponse> AddPerson(AddPersonRequest request)
        {
            ValidationResult result = entityValidator.Validate(request);

            if (!result.IsValid)
                throw new BusinessException(result.Errors.First().ToString());

            if (await personRepository.AnyAsync(PersonSpecifications.PersonHasCpf(request.Cpf)))
                throw new BusinessException("CPF duplicado");

            var person = Person.CreatePerson(
                request.FirstName,
                request.LastName,
                request.Cpf);

            await personRepository.AddAsync(person);

            return adapter.ProjectAs<PersonResponse>(person);
        }

        public async Task<PersonResponse> UpdatePerson(string id, UpdatePersonRequest request)
        {
            ValidationResult result = entityValidator.Validate(request);

            if (!result.IsValid)
                throw new BusinessException(result.Errors.First().ToString());

            Person person = await personRepository.FindAsync(id)
                ?? throw new NotFoundException("Pessoa não encontrada");

            if (await personRepository.AnyAsync(
                !PersonSpecifications.PersonHasId(person.Id)
                && PersonSpecifications.PersonHasCpf(person.Cpf.Number)))
            {
                throw new BusinessException("CPF duplicado");
            }

            await personRepository.UpdateAsync(person);

            return adapter.ProjectAs<PersonResponse>(person);
        }

        public async Task DeletePerson(string id)
        {
            Person person = await personRepository.FindAsync(id)
                ?? throw new NotFoundException("Pessoa não encontrada");

            await personRepository.RemoveAsync(person);
        }
    }
}
