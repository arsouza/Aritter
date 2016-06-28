using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
	public class Role : Entity
	{
		public Role()
		{
		}

		public Role(string name)
			: this(name, null)
		{
		}

		public Role(string name, string description)
			: this()
		{
			Name = name;
			Description = description;
		}

		public string Name { get; private set; }
		public string Description { get; private set; }
		public virtual ICollection<UserRole> UserRoles => new HashSet<UserRole>();
		public virtual ICollection<Authorization> Authorizations => new HashSet<Authorization>();

		public void AddMember(User user)
		{
			if (UserRoles.All(p => p.Identity != user.Identity))
			{
				// UserRoles.Add(user);
			}
		}
	}
}
