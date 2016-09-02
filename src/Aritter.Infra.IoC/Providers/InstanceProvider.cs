using Aritter.Application.Seedwork.Services;
using Aritter.Application.Services.Security;
using Aritter.Domain.Security.Services.Users;
using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Services;
using Aritter.Infra.Data;
using Aritter.Infra.Data.Repositories;
using Aritter.Infra.Data.Seedwork;
using Aritter.Infra.IoC.Extensions;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http.Dependencies;

namespace Aritter.Infra.IoC.Providers
{
    public class InstanceProvider : IInstanceProvider
    {
        #region Fields

        private static IInstanceProvider instance;
        private Container container;
        private IDependencyResolver dependencyResolver;

        #endregion Fields

        #region Properties

        public static IInstanceProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InstanceProvider();
                }

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
                    RegisterDependencies(container);
                }

                return container;
            }
        }

        public IDependencyResolver DependencyResolver
        {
            get
            {
                if (dependencyResolver == null)
                {
                    dependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
                }

                return dependencyResolver;
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

        private void RegisterDependencies(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IQueryableUnitOfWork, AritterContext>(Lifestyle.Scoped);
            container.RegisterAllServices<IRepository, UserAccountRepository>(Lifestyle.Scoped);
            container.RegisterAllServices<IDomainService, UserAccountService>(Lifestyle.Scoped);
            container.RegisterAllServices<IAppService, UserAppService>(Lifestyle.Scoped);
        }

        #endregion
    }
}