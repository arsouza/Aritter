using Aritter.Infrastructure.Injection.Modules;
using Ninject;
using Ninject.Modules;
using System;

namespace Aritter.Infrastructure.Injection
{
	public class DependencyProvider : IDependencyProvider
	{
		#region Fields

		private static IDependencyProvider instance;
		private KernelBase kernel;

		#endregion Fields

		#region Properties

		public static IDependencyProvider Instance
		{
			get
			{
				if (instance == null)
					instance = new DependencyProvider();
				return instance;
			}
		}

		public KernelBase Kernel
		{
			get
			{
				if (kernel == null)
				{
					var modules = RegisterModules();
					kernel = new StandardKernel(modules);
				}

				return kernel;
			}
		}

		#endregion Properties

		#region Methods

		public static TService Get<TService>() where TService : class
		{
			return Instance.Kernel.Get<TService>();
		}

		public static object Get(Type serviceType)
		{
			return Instance.Kernel.Get(serviceType);
		}

		private INinjectModule[] RegisterModules()
		{
			return new INinjectModule[]
			{
				new UnitOfWorkModule(),
				new RepositoryModule(),
				new DomainServiceModule(),
				new ApplicationManagerModule()
			};
		}

		#endregion
	}
}