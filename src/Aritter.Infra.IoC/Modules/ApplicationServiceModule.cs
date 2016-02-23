using Aritter.Application.Seedwork.Services;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
    internal sealed class ApplicationServiceModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x
                .FromAssemblyContaining<IAppService>()
                .SelectAllClasses()
                .InheritedFrom<IAppService>()
                .BindDefaultInterface()
                .Configure(y => y.InSingletonScope()));
        }
    }
}
