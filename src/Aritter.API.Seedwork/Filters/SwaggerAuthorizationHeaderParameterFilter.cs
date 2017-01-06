using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.API.Seedwork.Filters
{
    public class SwaggerAuthorizationHeaderParameterFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (CheckIfShouldAuthorize(context))
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Authorization access token",
                    Required = true,
                    Type = "string"
                });
            }
        }

        private bool CheckIfShouldAuthorize(OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;

            bool allowAnonymous = filterPipeline
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is IAllowAnonymousFilter);

            if (allowAnonymous)
                return false;

            bool hasAuthorization = filterPipeline
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is AuthorizeFilter);

            return hasAuthorization;
        }
    }
}
