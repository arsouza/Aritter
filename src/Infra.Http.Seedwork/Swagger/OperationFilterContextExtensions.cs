using System;
using System.Collections.Generic;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ritter.Infra.Http.Swagger
{
    internal static class OperationFilterContextExtensions
    {
        public static IEnumerable<T> GetControllerAndActionAttributes<T>(this OperationFilterContext context) where T : Attribute
        {
            IEnumerable<T> controllerAttributes = context.MethodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes<T>();
            IEnumerable<T> actionAttributes = context.MethodInfo.GetCustomAttributes<T>();

            var result = new List<T>(controllerAttributes);
            result.AddRange(actionAttributes);
            return result;
        }
    }
}
