using SimpleInjector;
using System.Web.Http.Dependencies;

namespace Aritter.Infra.IoC.Providers
{
    public interface IServiceProvider
    {
        #region Properties

        Container Container { get; }
        IDependencyResolver DependencyResolver { get; }

        #endregion Properties
    }
}