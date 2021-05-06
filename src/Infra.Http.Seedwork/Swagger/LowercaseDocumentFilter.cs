using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ritter.Infra.Http.Swagger
{
    public class LowerCaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            IDictionary<string, OpenApiPathItem> paths = swaggerDoc.Paths;

            var newPaths = new Dictionary<string, OpenApiPathItem>();
            var removeKeys = new List<string>();

            foreach (KeyValuePair<string, OpenApiPathItem> path in paths)
            {
                string newKey = LowerCaseEverythingButParameters(path.Key);

                if (newKey != path.Key)
                {
                    removeKeys.Add(path.Key);
                    newPaths.Add(newKey, path.Value);
                }
            }

            foreach (KeyValuePair<string, OpenApiPathItem> path in newPaths)
            {
                swaggerDoc.Paths.Add(path.Key, path.Value);
            }

            foreach (string key in removeKeys)
            {
                swaggerDoc.Paths.Remove(key);
            }
        }

        private static string LowerCaseEverythingButParameters(string key)
        {
            return string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
        }
    }
}
