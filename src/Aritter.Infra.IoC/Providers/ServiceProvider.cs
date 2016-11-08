using System;
using Aritter.Domain.Seedwork.Services;
using Aritter.Infra.IoC.Extensions;
using Aritter.Domain.Security.Services.Users;
using SimpleInjector;
using System.Reflection;
using Aritter.Infra.Data.Seedwork;
using Aritter.Infra.Data;

namespace Aritter.Infra.IoC.Providers
{
    public class ServiceProvider : IServiceProvider
    {
        private static IServiceProvider instance;
        private Container container;

        public static IServiceProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceProvider();
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

        public ScopedLifestyle DefaultScopedLifestyle
        {
            get
            {
                return Container.Options.DefaultScopedLifestyle;
            }

            set
            {
                Container.Options.DefaultScopedLifestyle = value;
            }
        }

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
            container.Register<IQueryableUnitOfWork, AritterContext>(Lifestyle.Scoped);
            // container.RegisterAllServices<IRepository, UserRepository>(Lifestyle.Scoped);
            container.RegisterAllServices<IDomainService>(typeof(UserService).GetTypeInfo().Assembly, Lifestyle.Scoped);
            // container.RegisterAllServices<IAppService, UserAppService>(Lifestyle.Scoped);
        }
    }
}
