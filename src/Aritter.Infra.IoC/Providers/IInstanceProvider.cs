using SimpleInjector;
using System.Web.Http.Dependencies;

namespace Aritter.Infra.IoC.Providers
{
    public interface IInstanceProvider
	{
		#region Properties

		Container Container { get; }
		IDependencyResolver DependencyResolver { get; }

		#endregion Properties
	}
}