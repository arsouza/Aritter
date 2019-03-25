using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Domain.Aggregates.People;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Samples.Infra.Data.Query.Repositories.People
{
    public class PersonQueryRepository : QueryRepository<Person, PersonResponse>, IPersonQueryRepository
    {
        public PersonQueryRepository(IEFQueryUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override PersonResponse Find(long id)
        {
            var result = UnitOfWork
                .Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .FirstOrDefault(p => p.Id == id);

            return CastResult(result);
        }

        public override async Task<PersonResponse> FindAsync(long id)
        {
            var result = await UnitOfWork
                .Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .FirstOrDefaultAsync(p => p.Id == id);

            return CastResult(result);
        }

        public override ICollection<PersonResponse> Find()
        {
            return UnitOfWork.Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .ToList()
                .Select(e => CastResult(e))
                .ToList();
        }

        public override async Task<ICollection<PersonResponse>> FindAsync()
        {
            var result = await UnitOfWork.Set<Person>()
                 .AsNoTracking()
                 .Include(p => p.Cpf)
                 .ToListAsync();

            return result
                .Select(e => CastResult(e))
                .ToList();
        }

        public override IPagedCollection<PersonResponse> Find(IPagination pagination)
        {
            return UnitOfWork.Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .PaginateList(pagination)
                .Select(e => CastResult(e));
        }

        public override async Task<IPagedCollection<PersonResponse>> FindAsync(IPagination pagination)
        {
            var result = await UnitOfWork.Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .PaginateListAsync(pagination);

            return result
                .Select(e => CastResult(e));
        }

        protected override PersonResponse CastResult(Person obj)
        {
            return (PersonResponse)obj;
        }
    }
}
