using Aritter.Domain.UnitOfWork;
using Aritter.Infrastructure.Data.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Aritter.Infrastructure.Injection.Modules
{
	public class UnitOfWorkModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUnitOfWork>().To<AritterContext>().InRequestScope();
		}
	}
}
