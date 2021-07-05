using Ritter.Domain;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public interface IPersonRepository : ISqlRepository<Person, string>
    {
    }
}
