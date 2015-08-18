using Aritter.Application.Managers;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
	public class ApplicationManagerModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind(x => x
				.FromAssemblyContaining<IApplicationManager>()
				.SelectAllClasses()
				.InheritedFrom<IApplicationManager>()
				.BindDefaultInterface()
				.Configure(y => y.InSingletonScope()));
		}
	}
}
