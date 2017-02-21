using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Adapter;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Extensions
{
    public static class ProjectionsExtension
    {
        public static TProjection ProjectedAs<TProjection>(this IEntity item)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<IEntity> items)
           where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}