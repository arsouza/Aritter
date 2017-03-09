using Aritter.Infra.Crosscutting.Adapter;
using System;
using System.Linq;
using System.Reflection;

namespace Aritter.Infra.Crosscutting.Tests.Adapter
{
    public class TestTypeAdapter : ITypeAdapter
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Adapt<TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source)
            where TTarget : class, new()
        {
            Type sourceType = source.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();

            Type targetType = typeof(TTarget);
            PropertyInfo[] targetProperties = targetType.GetProperties();

            TTarget target = new TTarget();

            foreach (var property in targetProperties)
            {
                if (property.SetMethod != null)
                {
                    PropertyInfo sourceProperty = sourceProperties.FirstOrDefault(p => p.Name == property.Name);
                    object sourcePropertyValue;

                    if (sourceProperty != null)
                    {
                        sourcePropertyValue = sourceProperty.GetValue(source, null);
                        property.SetValue(target, sourcePropertyValue, null);
                    }
                }
            }

            return target;
        }
    }
}