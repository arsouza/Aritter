using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.SecurityModule.Aggregates.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.SecurityModule
{
    public class ClientAppService : AppService, IClientAppService
    {
        private readonly IClientRepository clientRepository;

        public ClientAppService(IClientRepository clientRepository)
        {
            Check.IsNotNull(clientRepository, nameof(clientRepository));

            this.clientRepository = clientRepository;
        }

        public ClientDto GetClientByUID(GetClientDto getClient)
        {
            var client = clientRepository
                .Find(ClientSpecs.HasUID(getClient.UID))
                .FirstOrDefault();

            return client.ProjectedAs<ClientDto>();
        }
    }
}
