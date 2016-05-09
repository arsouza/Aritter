using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Application.Seedwork.Services;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Domain.Security.Services;

namespace Aritter.Application.Services.Security
{
	public class UserAppService : AppService, IUserAppService
	{
		private readonly IUserDomainService userDomainService;
		private readonly IUserRepository userRepository;

		public UserAppService(IUserDomainService userDomainService,
							  IUserRepository userRepository)
		{
			this.userDomainService = userDomainService;
			this.userRepository = userRepository;
		}

		public UserDTO Authenticate(string userName, string password)
		{
			var user = userDomainService.Authenticate(userName, password);
			return user.ProjectedAs<UserDTO>();
		}

		public UserDTO GetAuthorizations(string userName)
		{
			var user = userRepository.GetAuthorizations(UsersSpecifications.FindByUserName(userName));
			return user.ProjectedAs<UserDTO>();
		}
	}
}