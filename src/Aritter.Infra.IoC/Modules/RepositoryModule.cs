using Aritter.Domain;
using Aritter.Infra.Data;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
	public class RepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
		}
	}
}
