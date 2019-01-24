using Ritter.Infra.Crosscutting.Validations;
using System;
using System.Linq;
using System.Reflection;

namespace Ritter.Domain
{
    public class ValueObject : Validatable
    {
        protected ValueObject()
            : base()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj.IsNull())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (!this.GetType().IsInstanceOfType(obj))
                return false;

            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(obj, null);

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

            PropertyInfo[] properties = this.GetType().GetProperties();

            if (properties.Any())
            {
                foreach (var item in properties)
                {
                    object value = item.GetValue(this, null);

                    if (value.IsNull())
                        hashCode = hashCode ^ (index * 13);
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
            if (left.IsNull())
                return right.IsNull();

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
    }
}
