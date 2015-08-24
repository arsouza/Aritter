using Aritter.Infra.CrossCutting.Logging;
using Ninject.Modules;

namespace Aritter.Infra.IoC.Modules
{
    internal sealed class CrossCuttingModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ILogger>().ToMethod(p => Logger.CreateLogger());
                }
    }
}
