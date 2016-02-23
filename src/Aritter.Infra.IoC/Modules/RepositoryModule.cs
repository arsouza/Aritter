using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Infra.Data.Repository;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
    internal sealed class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x
                .FromAssemblyContaining<Repository>()
                .SelectAllClasses()
                .InheritedFrom<IRepository>()
                .BindDefaultInterface()
                .Configure(y => y.InSingletonScope()));
        }
    }
}
