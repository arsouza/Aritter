using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Data.Seedwork;
using System;
using System.Data.Entity;
using System.Linq;

namespace Aritter.Infra.Data.Repositories
{
	public sealed class UserRepository : Repository<User>, IUserRepository
	{
		#region Constructors

		public UserRepository(IQueryableUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		#endregion

		public User GetAuthorizations(ISpecification<User> specification)
		{
			var user = ((IQueryableUnitOfWork)UnitOfWork)
				.Set<User>()
				.Include(u => u.Roles.Select(r => r.Authorizations.Select(a => a.Permission.Resource.Module)))
				.Where(specification.SatisfiedBy())
				.Select(u => new
				{
					u.UserName,
					u.FirstName,
					u.LastName,
					u.Identity,
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

		public User GetByCredentials(ISpecification<User> specification)
		{
			throw new NotImplementedException();
		}

		public User GetUserPassword(ISpecification<User> specification)
		{
			var user = ((IQueryableUnitOfWork)UnitOfWork)
				.Set < User: EntityBuilder <


				  .Include(u => u.PreviousCredentials)
				  .Where(specification.SatisfiedBy())
				  .Select(u => new
				  {
					  Credentials = u.PreviousCredentials.Select(ph => new
					  {
						  ph.PasswordHash
					  })
				  })
				  .FirstOrDefault();

			if (user == null)
			{
				return null;
			}

			return typeAdapter.Adapt<User>(user);
		}
	}
}
