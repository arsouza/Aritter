using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ritter.Domain
{
    public class ValueObject : IEquatable<ValueObject>, IEqualityComparer<ValueObject>
    {
        protected ValueObject() { }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is ValueObject valueObject)
            {
                return Equals(valueObject);
            }

            return false;
        }

        public virtual bool Equals(ValueObject obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!GetType().IsInstanceOfType(obj))
            {
                return false;
            }

            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    object left = p.GetValue(this, null);
                    object right = p.GetValue(obj, null);

                    return object.Equals(left, right);
                });
            }

            return true;
        }

        public virtual bool Equals(ValueObject x, ValueObject y)
        {
            if (x is null)
            {
                return false;
            }

            if (y is null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            int index = 1;

            PropertyInfo[] properties = GetType().GetProperties();

            if (properties.Any())
            {
                foreach (PropertyInfo item in properties)
                {
                    object value = item.GetValue(this, null);

                    if (value is null)
                    {
                        hashCode = hashCode ^ (index * 13);
                    }
                    else
                    {
                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                }
            }

            return Math.Abs(hashCode);
        }

        public int GetHashCode(ValueObject obj) => GetHashCode() + obj.GetHashCode();
    }
}
