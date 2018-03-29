using System;
using System.Linq;
using System.Reflection;

namespace Ritter.Domain.Seedwork
{
    public class ValueObject<TValueObject> : IEquatable<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        protected ValueObject() { }

        public bool Equals(TValueObject other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            PropertyInfo[] properties = this.GetType().GetProperties();

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    if (left is ValueObject<TValueObject>)
                        return ReferenceEquals(left, right);

                    return left.Equals(right);
                });
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is ValueObject<TValueObject> item)
                return Equals((TValueObject)item);

            return false;

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

                    if (value is null)
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

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }
    }
}
