using SimpleInjector;

namespace Aritter.Infra.IoC.Providers
{
    public interface IServiceProvider
    {
        Container Container { get; }
        ScopedLifestyle DefaultScopedLifestyle { get; set; }
    }
}
