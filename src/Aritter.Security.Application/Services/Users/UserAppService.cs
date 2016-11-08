using Aritter.Application.Seedwork.Services;
using Aritter.Security.Domain.Users.Aggregates;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Security.Application.Services.Users
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserRepository userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            Check.IsNotNull(userRepository, nameof(userRepository));

            this.userRepository = userRepository;
        }
    }
    }
