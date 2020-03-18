using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.People
{
    public interface IPersonAppService : IAppService
    {
        Task<PersonResponse> AddPerson(AddPersonRequest request);
        Task<PersonResponse> UpdatePerson(int personId, UpdatePersonRequest request);
        Task DeletePerson(int personId);
    }
}
