using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Linq;

namespace Aritter.Application.Services.Security
{
    public class ApplicationAppService : AppService, IApplicationAppService
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationAppService(IApplicationRepository applicationRepository)
        {
            Check.IsNotNull(applicationRepository, nameof(applicationRepository));

            this.applicationRepository = applicationRepository;
        }

        public ApplicationDto GetApplicationByUID(GetApplicationDto getApplication)
        {
            var application = applicationRepository
                .Find(ApplicationSpecs.HasUID(getApplication.UID))
                .FirstOrDefault();

            return application.ProjectedAs<ApplicationDto>();
        }
    }
}
