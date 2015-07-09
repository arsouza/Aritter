using Aritter.Manager.Application.Services;
using Aritter.Manager.Domain;
using Aritter.Manager.Domain.Services;
using Aritter.Manager.Domain.UnitOfWork;
using Aritter.Manager.Infrastructure.Data.Repositories;
using Aritter.Manager.Infrastructure.Data.UnitOfWork;
using Aritter.Manager.Infrastructure.Extensions;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;

namespace Aritter.Manager.Infrastructure.Injection
{
	public class DependencyProvider : IDependencyProvider
	{
		#region Fields

		private static IDependencyProvider instance;
		private Container container;

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

		public Container Container
		{
			get
			{
				if (container == null)
				{
					container = new Container();
					RegisterServices();
				}

				return container;
			}
		}

		#endregion Properties

		#region Methods

		public TService GetInstance<TService>() where TService : class
		{
			return Container.GetInstance<TService>();
		}

		public object GetInstance(Type serviceType)
		{
			return Container.GetInstance(serviceType);
		}

		private void RegisterServices()
		{
			Container.Register(CreateUnitOfWork, new WebRequestLifestyle(false));
			Container.Register<IRepository, Repository>(Lifestyle.Singleton);
			Container.RegisterAsDefaultInterfaces<IDomainService>(Lifestyle.Singleton);
			Container.RegisterAsDefaultInterfaces<IAppService>(Lifestyle.Singleton);
		}

		private IUnitOfWork CreateUnitOfWork()
		{
			return new ManagerContext();
		}

		#endregion
	}
}