using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Requests;

namespace Ritter.Infra.Http.Extensions
{
    public static class GeneralExtensions
    {
        public static Pagination ToPagination(this PaginationRequest request)
        {
            if (request is null)
            {
                return Pagination.Default();
            }

            return new Pagination(
                request.PageIndex,
                request.PageSize,
                request.OrderByName,
                request.Ascending);
        }
    }
}
