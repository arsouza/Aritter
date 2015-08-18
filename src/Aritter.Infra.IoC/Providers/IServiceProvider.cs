using Ninject;

namespace Aritter.Infra.IoC.Providers
{
	public interface IServiceProvider
	{
		#region Properties

		KernelBase Kernel { get; }

		#endregion Properties
	}
}