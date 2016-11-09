using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aritter.Infra.IoC.Containers
{
    public interface IServiceContainer
    {
        IServiceProvider Container { get; }

        TService Get<TService>() where TService : class;

        object Get(Type serviceType);
    }
}
