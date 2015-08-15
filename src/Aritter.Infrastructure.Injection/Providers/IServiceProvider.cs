using Ninject;

namespace Aritter.Infrastructure.Injection.Providers
{
	public interface IServiceProvider
	{
		#region Properties

		KernelBase Kernel { get; }

		#endregion Properties
	}
}