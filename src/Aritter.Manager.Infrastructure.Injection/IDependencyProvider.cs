using SimpleInjector;
using System;

namespace Aritter.Manager.Infrastructure.Injection
{
	public interface IDependencyProvider
	{
		#region Properties

		Container Container { get; }

		#endregion Properties

		#region Methods

		TService GetInstance<TService>() where TService : class;
		object GetInstance(Type serviceType);

		#endregion Methods
	}
}