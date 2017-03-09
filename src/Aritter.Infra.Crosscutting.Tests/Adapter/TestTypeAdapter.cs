using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aritter.Infra.Crosscutting.Adapter;
using System.Reflection;
using System.Linq;

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
            PropertyInfo[] sourceProperties = sourceType.GetProperties(BindingFlags.Instance);

            Type targetType = source.GetType();
            PropertyInfo[] targetProperties = targetType.GetProperties(BindingFlags.Instance);

            TTarget target = new TTarget();

            foreach (var property in targetProperties)
            {
                if (property.SetMethod != null)
                {
                    PropertyInfo sourceProperty = sourceProperties.FirstOrDefault(p => p.Name == property.Name);

                    if (sourceProperty != null)
                    {
                        property.SetValue(target, sourceProperty.GetValue(source));
                    }
                }
            }

            return target;
        }
    }
}