using SimpleInjector;

namespace Aritter.Infra.IoC.Providers
{
    public interface IServiceProvider
    {
        #region Properties

        Container Container { get; }

        #endregion Properties
    }
}