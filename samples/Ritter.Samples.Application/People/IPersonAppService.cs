using System.Threading.Tasks;
using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;

namespace Ritter.Samples.Application.People
{
    public interface IPersonAppService : IAppService
    {
        Task<PersonResponse> AddPerson(AddPersonRequest request);
        Task<PersonResponse> UpdatePerson(string id, UpdatePersonRequest request);
        Task DeletePerson(string id);
    }
}
