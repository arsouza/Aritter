using System;
using System.Threading.Tasks;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data.Query.Repositories.People
{
    public interface IPersonQueryRepository : IQueryRepository<Person, PersonResponse>
    {
        PersonResponse Find(Guid uid);
        Task<PersonResponse> FindAsync(Guid uid);
    }
}
