using System.Threading.Tasks;
using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Infra.Crosscutting.Trying;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;

namespace Ritter.Samples.Application.People
{
    public interface IPersonAppService : IAppService
    {
        Task<Try<ApplicationException, PersonResponse>> AddPerson(AddPersonRequest request);
        Task<Try<ApplicationException, PersonResponse>> UpdatePerson(string id, UpdatePersonRequest request);
        Task<Try<ApplicationException, bool>> DeletePerson(string id);
        Task<IPagedCollection<PersonResponse>> FindPaginatedAsync(Pagination pagination);
        Task<PersonResponse> GetPersonAsync(string id);
    }
}
