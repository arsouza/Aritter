using Aritter.Domain.Services;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
	internal sealed class DomainServiceModule : NinjectModule
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
