using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Requests;

namespace Ritter.Infra.Http.Extensions
{
    public static class ExtensionMethods
    {
        public static Pagination ToPagination(this PaginationRequest request)
        {
            if (request is null)
            {
                return new Pagination();
            }

            return new Pagination(
                request.PageIndex,
                request.PageSize,
                request.OrderByName,
                request.Ascending);
        }
    }
}
