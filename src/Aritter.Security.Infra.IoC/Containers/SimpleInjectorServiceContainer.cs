using Aritter.Application.Seedwork.Services;
using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Services;
using Aritter.Infra.Crosscutting.Extensions;
using Aritter.Infra.Data.Seedwork;
using Aritter.Infra.IoC.Containers;
using Aritter.Security.Application.Services.Users;
using Aritter.Security.Domain.Security.Users.Services;
using Aritter.Security.Infra.Data;
using Aritter.Security.Infra.Data.Repositories;
using Aritter.Security.Infra.Ioc.Extensions;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using System.Reflection;

namespace Aritter.Security.Infra.Ioc.Containers
{
    public class SimpleInjectorServiceContainer : ISimpleInjectorServiceContainer
    {
        private Container container;

        public Container Container
        {
            get
            {
                if (container == null)
                    container = new Container();

                return container;
            }
        }

        IServiceProvider IServiceContainer.Container
        {
            get
            {
                return this.Container;
            }
        }

        public void Configure(IServiceProvider rootProvider)
        {
            Container.Register<IQueryableUnitOfWork>(() => { return new AritterContext((IConfiguration)rootProvider.GetService(typeof(IConfiguration))); }, Lifestyle.Scoped);
            Container.RegisterAllServices<IRepository>(typeof(UserRepository).GetTypeInfo().Assembly, Lifestyle.Scoped);
            Container.RegisterAllServices<IDomainService>(typeof(UserService).GetTypeInfo().Assembly, Lifestyle.Scoped);
            Container.RegisterAllServices<IAppService>(typeof(UserAppService).GetTypeInfo().Assembly, Lifestyle.Scoped);
        }

        public void Configure(IServiceProvider rootProvider, Action<Container> configureAction)
        {
            configureAction(Container);
            Configure(rootProvider);
        }

        public object Get(Type serviceType)
        {
            return Container.GetInstance(serviceType);
        }

        public TService Get<TService>() where TService : class
        {
            return Container.GetInstance<TService>();
        }
    }
}
