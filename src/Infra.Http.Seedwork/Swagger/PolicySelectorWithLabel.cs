using System;
using System.Collections.Generic;

namespace Ritter.Infra.Http.Swagger
{
    public sealed class PolicySelectorWithLabel<T> where T : Attribute
    {
        public Func<IEnumerable<T>, IEnumerable<string>> Selector { get; set; }
        public string Label { get; set; }
    }
}
