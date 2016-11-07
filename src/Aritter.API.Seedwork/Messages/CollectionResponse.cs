namespace Aritter.API.Seedwork.Messages
{
    public abstract class CollectionResponse<TData> : Response<TData>
        where TData : class
    {
        public int TotalCount { get; set; }
    }
}
