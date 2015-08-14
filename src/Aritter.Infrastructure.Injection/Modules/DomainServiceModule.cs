using Aritter.Domain.Services;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aritter.Infrastructure.Injection.Modules
{
	public class DomainServiceModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind(x => x
				.FromAssemblyContaining<IDomainService>()
				.SelectAllClasses()
				.InheritedFrom<IDomainService>()
				.BindDefaultInterface()
				.Configure(y => y.InSingletonScope()));
		}
	}
}
