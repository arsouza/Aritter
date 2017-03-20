using System;
using System.Linq;
using System.Reflection;

namespace Aritter.Domain.Seedwork
{
    public class ValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        #region IEquatable and Override Equals operators

        public bool Equals(TValueObject other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            var properties = GetType().GetProperties();

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    if (typeof(TValueObject).IsAssignableFrom(left.GetType()))
                        return ReferenceEquals(left, right);

                    return left.Equals(right);
                });
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var other = obj as ValueObject<TValueObject>;

            if ((object)other != null)
                return Equals((TValueObject)other);

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            var index = 1;

            var publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (var property in publicProperties)
                {
                    var value = property.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                        hashCode = hashCode ^ (index * 13); //only for support {"a",null,null,"a"} <> {null,"a","a",null}
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return Equals(left, null)
                ? Equals(right, null)
                : left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }

        #endregion
    }
}
