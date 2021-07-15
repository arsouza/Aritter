using System;
using System.Linq;
using System.Reflection;
namespace Ritter.Domain
{
    public class ValueObject : IEquatable<ValueObject>
    {
        protected ValueObject() { }

        public override bool Equals(object other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is ValueObject valueObject)
            {
                return Equals(valueObject);
            }

            return false;
        }

        public bool Equals(ValueObject other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!GetType().IsInstanceOfType(other))
            {
                return false;
            }

            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    object left = p.GetValue(this, null);
                    object right = p.GetValue(other, null);

                    return object.Equals(left, right);
                });
            }

            return true;
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

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);
    }
}
