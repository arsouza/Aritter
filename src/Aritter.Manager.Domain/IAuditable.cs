using System;

namespace Aritter.Manager.Domain
{
	public interface IAuditable : IEntity
	{
		Guid Guid { get; }
	}
}
