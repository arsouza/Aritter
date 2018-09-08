using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Samples.Web.Swagger
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //  paths
            var paths = swaggerDoc.Paths;

            //	generate the new keys
            var newPaths = new Dictionary<string, PathItem>();
            var removeKeys = new List<string>();

            foreach (var path in paths)
            {
                var newKey = LowercaseEverythingButParameters(path.Key);

                if (newKey != path.Key)
                {
                    removeKeys.Add(path.Key);
                    newPaths.Add(newKey, path.Value);
                }
            }

            //	add the new keys
            foreach (var path in newPaths)
                swaggerDoc.Paths.Add(path.Key, path.Value);

            //	remove the old keys
            foreach (var key in removeKeys)
                swaggerDoc.Paths.Remove(key);
        }

        private string LowercaseEverythingButParameters(string key)
            => string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
    }
}
