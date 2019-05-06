using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ritter.Infra.Http.Configurations.Swagger
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //  paths
            IDictionary<string, PathItem> paths = swaggerDoc.Paths;

            //	generate the new keys
            var newPaths = new Dictionary<string, PathItem>();
            var removeKeys = new List<string>();

            foreach (KeyValuePair<string, PathItem> path in paths)
            {
                string newKey = LowercaseEverythingButParameters(path.Key);

                if (newKey != path.Key)
                {
                    removeKeys.Add(path.Key);
                    newPaths.Add(newKey, path.Value);
                }
            }

            //	add the new keys
            foreach (KeyValuePair<string, PathItem> path in newPaths)
            {
                swaggerDoc.Paths.Add(path.Key, path.Value);
            }

            //	remove the old keys
            foreach (string key in removeKeys)
            {
                swaggerDoc.Paths.Remove(key);
            }
        }

        private string LowercaseEverythingButParameters(string key)
        {
            return string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
        }
    }
}
