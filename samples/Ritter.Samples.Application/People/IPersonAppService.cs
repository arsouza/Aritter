using System;
using System.Threading.Tasks;
using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;

namespace Ritter.Samples.Application.People
{
    public interface IPersonAppService : IAppService
    {
        Task<PersonResponse> AddPerson(AddPersonRequest request);
        Task<PersonResponse> UpdatePerson(Guid uid, UpdatePersonRequest request);
        Task DeletePerson(Guid uid);
    }
}
