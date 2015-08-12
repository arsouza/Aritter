using Aritter.Application.Managers;
using Aritter.Domain;
using Aritter.Domain.Services;
using Aritter.Domain.UnitOfWork;
using Aritter.Infrastructure.Data;
using Aritter.Infrastructure.Data.UnitOfWork;
using Aritter.Infrastructure.Extensions;
using SimpleInjector;
using System;

namespace Aritter.Infrastructure.Injection
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
			//Container.Register(CreateUnitOfWork, new WebRequestLifestyle(false));
			Container.RegisterWebApiRequest(CreateUnitOfWork);
			Container.Register<IRepository, Repository>(Lifestyle.Singleton);
			Container.RegisterAsDefaultInterfaces<IDomainService>(Lifestyle.Singleton);
			Container.RegisterAsDefaultInterfaces<IApplicationManager>(Lifestyle.Singleton);
		}

		private IUnitOfWork CreateUnitOfWork()
		{
			return new ManagerContext();
		}

		#endregion
	}
}