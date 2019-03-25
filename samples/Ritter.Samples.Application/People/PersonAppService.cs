using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Domain.Aggregates.People;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.People
{
    public class PersonAppService : AppService, IPersonAppService
    {
        private readonly IPersonRepository personRepository;
        private readonly IEntityValidator entityValidator;

        public PersonAppService(
            IPersonRepository personRepository,
            IEntityValidator entityValidator)
            : base(null)
        {
            this.personRepository = personRepository;
            this.entityValidator = entityValidator;
        }

        public async Task<PersonResponse> AddPerson(AddPersonRequest request)
        {
            var result = entityValidator.Validate(request);

            if (!result.IsValid)
                throw new ValidationException(result.Errors.First().ToString());

            if (await personRepository.AnyAsync(PersonSpecifications.PersonHasCpf(request.Cpf)))
                throw new ValidationException("Já existe outra pessoa cadastrada com este CPF");

            var person = Person.CreatePerson(
                request.FirstName,
                request.LastName,
                request.Cpf);

            await personRepository.AddAsync(person);

            return (PersonResponse)person;
        }

        public async Task<PersonResponse> UpdatePerson(int personId, UpdatePersonRequest request)
        {
            var result = entityValidator.Validate(request);

            if (!result.IsValid)
                throw new ValidationException(result.Errors.First().ToString());

            var person = await personRepository.FindAsync(personId)
                ?? throw new NotFoundObjectException("Pessoa não encontrada");

            if (await personRepository.AnyAsync(
                !PersonSpecifications.PersonHasId(person.Id)
                && PersonSpecifications.PersonHasCpf(person.Cpf.Number)))
            {
                throw new ValidationException("Já existe outra pessoa cadastrada com este CPF");
            }

            await personRepository.UpdateAsync(person);

            return (PersonResponse)person;
        }

        public async Task DeletePerson(int personId)
        {
            var person = await personRepository.FindAsync(personId)
                ?? throw new NotFoundObjectException("Pessoa não encontrada");

            await personRepository.RemoveAsync(person);
        }
    }
}
