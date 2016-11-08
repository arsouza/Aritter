using Aritter.Application.Seedwork.Services;
using Aritter.Security.Application.Services.Users;
using Aritter.Security.Domain.Security.Users.Services;
using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Services;
using Aritter.Security.Infra.Data;
using Aritter.Security.Infra.Data.Repositories;
using Aritter.Infra.Data.Seedwork;
using Aritter.Security.Infra.Ioc.Extensions;
using SimpleInjector;
using System;
using System.Reflection;

namespace Aritter.Security.Infra.Ioc.Providers
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

        public ScopedLifestyle DefaultScopedLifestyle { get; set; }

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
            if (DefaultScopedLifestyle != null)
                container.Options.DefaultScopedLifestyle = DefaultScopedLifestyle;

            container.Register<IQueryableUnitOfWork, AritterContext>(Lifestyle.Scoped);
            container.RegisterAllServices<IRepository>(typeof(UserRepository).GetTypeInfo().Assembly, Lifestyle.Scoped);
            container.RegisterAllServices<IDomainService>(typeof(UserService).GetTypeInfo().Assembly, Lifestyle.Scoped);
            container.RegisterAllServices<IAppService>(typeof(UserAppService).GetTypeInfo().Assembly, Lifestyle.Scoped);
        }
    }
}
