namespace Ritter.Infra.Crosscutting.Collections
{
    public class Pagination : IPagination
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public string OrderByName { get; private set; }

        public bool Ascending { get; private set; }

        public Pagination()
            : this(default, int.MaxValue)
        {
        }

        public Pagination(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex < 0 ? 0 : pageIndex;
            PageSize = pageSize < 1 ? int.MaxValue : pageSize;
        }

        public Pagination(int pageIndex, int pageSize, string orderByName, bool ascending)
            : this(pageIndex, pageSize)
        {
            OrderByName = orderByName;
            Ascending = ascending;
        }
    }
}
