using Ritter.Application.Shared;
using Ritter.Domain;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.TypeAdapter;
using System.Collections.Generic;

namespace Ritter.Application.Services
{
    public static class ProjectionExtensions
    {
        public static TProjection ProjectedAs<TProjection>(this Entity item)
            where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> ProjectedAsList<TProjection>(this IEnumerable<Entity> items)
           where TProjection : class, new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        public static PagedList<TProjection> ProjectedAsPagedList<TProjection>(this IPagedCollection<Entity> items)
            where TProjection : class, new()
        {
            var page = items.ProjectedAsList<TProjection>();
            return new PagedList<TProjection>(page, items.PageSize, items.PageCount, items.TotalCount);
        }
    }
}
