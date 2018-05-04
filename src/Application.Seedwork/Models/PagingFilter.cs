using Ritter.Infra.Crosscutting;

namespace Ritter.Application.Models
{
    public sealed class PagingFilter
    {
        /// <summary>
        /// The required page index (starts at zero)
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// The number of page items
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The field name to sort
        /// </summary>
        public string OrderByName { get; set; }

        /// <summary>
        /// The sorting orientation
        /// </summary>
        public bool Ascending { get; set; }

        public Pagination GetPagination() => new Pagination(PageIndex, PageSize, OrderByName, Ascending);
    }
}
