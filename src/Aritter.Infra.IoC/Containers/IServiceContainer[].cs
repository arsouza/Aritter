using System;

namespace Aritter.Infra.IoC.Containers
{
    public interface IServiceContainer<TServiceProvider> : IServiceContainer
        where TServiceProvider : IServiceProvider
    {
        new TServiceProvider Container { get; }

        void Configure(IServiceProvider rootProvider);

        void Configure(IServiceProvider rootProvider, Action<TServiceProvider> configureAction);
    }
}
