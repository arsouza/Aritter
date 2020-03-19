using System;
using System.Threading.Tasks;
using Ritter.Domain;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Find(Guid uid);
        Task<Person> FindAsync(Guid uid);
    }
}
