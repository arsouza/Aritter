namespace Ritter.Infra.Crosscutting.TypeAdapter
{
    public interface ITypeAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TTarget : class, new()
            where TSource : class;

        TTarget Adapt<TTarget>(object source)
            where TTarget : class, new();
    }
}
