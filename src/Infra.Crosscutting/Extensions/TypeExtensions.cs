using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllTypesOf<T>(this Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(
                    type => type.IsClass
                    && !type.IsAbstract
                    && typeof(T).IsAssignableFrom(type)
                );
        }
    }
}
