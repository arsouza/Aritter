using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Pagination
{
    public class PaginatedList<T> : List<T>, IPaginatedList<T>
	{
		private readonly IPagination pagination;

		public PaginatedList(IEnumerable<T> source, IPagination pagination, int totalCount)
		{
			this.pagination = pagination;

			TotalCount = totalCount;
			AddRange(source);
		}

		public int TotalCount { get; set; }

		public int PageCount => GetPageCount(pagination.PageSize, TotalCount);

		private static int GetPageCount(int pageSize, int totalCount)
		{
			if (pageSize == 0)
			{
				return 0;
			}

			var remainder = totalCount % pageSize;
			return totalCount / pageSize + (remainder == 0 ? 0 : 1);
		}
	}
}