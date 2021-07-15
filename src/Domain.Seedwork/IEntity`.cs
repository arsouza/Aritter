namespace Ritter.Domain
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }

        bool IsTransient();
    }
}
