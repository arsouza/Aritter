using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Adapter;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Extensions
{

    public static class ProjectionsExtensionMethods
    {
        public static TProjection ProjectedAs<TProjection>(this Entity item) where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<Entity> items)
           where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}