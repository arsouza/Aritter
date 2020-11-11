using System.Collections.Generic;
using Ritter.Infra.Crosscutting.Adapters;
using Ritter.Infra.Crosscutting.Collections;

namespace Ritter.Application.Extensions
{
    public static class ProjectionsExtensionMethods
    {
        public static TProjection ProjectAs<TProjection>(this ITypeAdapter adapter, object source)
            where TProjection : class, new()
        {
            return adapter.Adapt<TProjection>(source);
        }

        public static TProjection ProjectAs<TSource, TProjection>(this ITypeAdapter adapter, TSource source)
            where TSource : class
            where TProjection : class, new()
        {
            return adapter.ProjectAs<TProjection>(source);
        }

        public static ICollection<TProjection> ProjectAsCollection<TProjection>(this ITypeAdapter adapter, IEnumerable<object> source)
            where TProjection : class, new()
        {
            return adapter.Adapt<List<TProjection>>(source);
        }

        public static ICollection<TProjection> ProjectAsCollection<TSource, TProjection>(this ITypeAdapter adapter, IEnumerable<TSource> source)
            where TSource : class
            where TProjection : class, new()
        {
            return adapter.ProjectAsCollection<TProjection>(source);
        }

        public static IPagedCollection<TProjection> ProjectAsPagedCollection<TProjection>(this ITypeAdapter adapter, IPagedCollection<object> source)
            where TProjection : class, new()
        {
            List<TProjection> projection = adapter.Adapt<List<TProjection>>(source);
            return new PagedList<TProjection>(projection, source.TotalCount);
        }

        public static IPagedCollection<TProjection> ProjectAsPagedCollection<TSource, TProjection>(this ITypeAdapter adapter, IPagedCollection<TSource> source)
            where TSource : class
            where TProjection : class, new()
        {
            return adapter.ProjectAsPagedCollection<TProjection>(source);
        }
    }
}
