using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Data;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Person Find(long id)
        {
            return UnitOfWork
                .Set<Person>()
                .Include(p => p.Cpf)
                .FirstOrDefault(p => p.Id == id);
        }

        public override async Task<Person> FindAsync(long id)
        {
            return await UnitOfWork
                .Set<Person>()
                .Include(p => p.Cpf)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Person Find(Guid uid)
        {
            return UnitOfWork
                .Set<Person>()
                .Include(p => p.Cpf)
                .FirstOrDefault(p => p.Uid == uid);
        }

        public async Task<Person> FindAsync(Guid uid)
        {
            return await UnitOfWork
                .Set<Person>()
                .Include(p => p.Cpf)
                .FirstOrDefaultAsync(p => p.Uid == uid);
        }

        public override ICollection<Person> Find()
        {
            return UnitOfWork.Set<Person>()
                .Include(p => p.Cpf)
                .ToList();
        }

        public override async Task<ICollection<Person>> FindAsync()
        {
            return await UnitOfWork.Set<Person>()
                 .Include(p => p.Cpf)
                 .ToListAsync();
        }

        public override IPagedCollection<Person> Find(IPagination pagination)
        {
            return UnitOfWork.Set<Person>()
                .Include(p => p.Cpf)
                .PaginateList(pagination);
        }

        public override async Task<IPagedCollection<Person>> FindAsync(IPagination pagination)
        {
            return await UnitOfWork.Set<Person>()
                .AsNoTracking()
                .Include(p => p.Cpf)
                .PaginateListAsync(pagination);
        }
    }
}
