using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Specification;
using Aritter.Domain.Seedwork.UnitOfWork;
using Aritter.Infra.Data.SeedWork.Repository;
using System.Data.Entity;
using System.Linq;

namespace Aritter.Infra.Data.Repository
{
	public sealed class UserRepository : Repository<User>, IUserRepository
	{
		#region Constructors

		public UserRepository(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		#endregion

		public User GetAuthorizations(ISpecification<User> specification)
		{
			var user = Find(specification)
				.Include(u => u.Roles.Select(r => r.Authorizations.Select(a => a.Permission.Resource.Module)))
				.Select(u => new
				{
					u.UserName,
					u.FirstName,
					u.LastName,
					u.Guid,
					Roles = u.Roles.Select(r => new
					{
						r.Name,
						Authorizations = r.Authorizations.Where(a => a.Allowed && !a.Denied).Select(a => new
						{
							a.Allowed,
							a.Denied,
							Permission = new
							{
								a.Permission.Rule,
								Resource = new
								{
									Module = new
									{
										a.Permission.Resource.Module.Name
									},
									a.Permission.Resource.Name
								}
							}
						})
					})
				})
				.FirstOrDefault();

			if (user == null)
			{
				return null;
			}

			return typeAdapter.Adapt<User>(user);
		}

		public User GetUserPassword(ISpecification<User> specification)
		{
			var query = Find(specification)
				.Include(u => u.PasswordHistory)
				.Select(u => new
				{
					PasswordHistory = u.PasswordHistory.Select(ph => new
					{
						ph.PasswordHash
					})
				})
				.FirstOrDefault();

			if (query == null)
			{
				return null;
			}

			var user = new User
			{
				PasswordHistory = query.PasswordHistory.Select(ph => new UserPassword
				{
					PasswordHash = ph.PasswordHash
				}).ToList()
			};

			return user;
		}
	}
}
