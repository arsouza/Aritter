using Aritter.Domain;
using Aritter.Infrastructure.Data;
using Ninject.Modules;

namespace Aritter.Infrastructure.Injection.Modules
{
	public class RepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
		}
	}
}
