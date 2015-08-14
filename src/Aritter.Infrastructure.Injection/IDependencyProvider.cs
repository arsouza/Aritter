using Ninject;

namespace Aritter.Infrastructure.Injection
{
	public interface IDependencyProvider
	{
		#region Properties

		KernelBase Kernel { get; }

		#endregion Properties
	}
}