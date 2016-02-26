using Aritter.Application.Seedwork.Services;
using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Domain.Seedwork.Services;
using Aritter.Domain.Seedwork.UnitOfWork;
using Aritter.Infra.Data.Repository;
using Aritter.Infra.Data.UnitOfWork;
using Aritter.Infra.IoC.Extensions;
using SimpleInjector;
using System;

namespace Aritter.Infra.IoC.Providers
{
    public class ServiceProvider : IServiceProvider
    {
        #region Fields

        private static IServiceProvider instance;
        private Container container;

        #endregion Fields

        #region Properties

        public static IServiceProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceProvider();
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
                    RegisterDependencies();
                }

                return container;
            }
        }

        #endregion Properties

        #region Methods

        public static TService Get<TService>() where TService : class
        {
            return Instance.Container.GetInstance<TService>();
        }

        public static object Get(Type serviceType)
        {
            return Instance.Container.GetInstance(serviceType);
        }

        private void RegisterDependencies()
        {
            // Container.Register(CreateUnitOfWork, new WebRequestLifestyle(false));
            Container.RegisterWebApiRequest(CreateUnitOfWork);
            Container.RegisterAsDefaultInterfaces<IRepository, UserRepository>(Lifestyle.Singleton);
            Container.RegisterAsDefaultInterfaces<IDomainService>(Lifestyle.Singleton);
            Container.RegisterAsDefaultInterfaces<IAppService>(Lifestyle.Singleton);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            return new AritterContext();
        }

        #endregion
    }
}