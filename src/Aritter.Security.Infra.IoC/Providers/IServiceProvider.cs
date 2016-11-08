using SimpleInjector;

namespace Aritter.Security.Infra.Ioc.Providers
{
    public interface IServiceProvider
    {
        Container Container { get; }
        ScopedLifestyle DefaultScopedLifestyle { get; set; }
    }
}
