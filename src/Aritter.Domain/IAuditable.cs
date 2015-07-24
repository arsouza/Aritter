using System;

namespace Aritter.Domain
{
	public interface IAuditable : IEntity
	{
		Guid Guid { get; }
	}
}
