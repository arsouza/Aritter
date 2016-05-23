using System;
using System.Linq;

namespace Aritter.Domain.Seedwork
{
    public class ValueObject<TValueObject> : IEquatable<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        #region IEquatable and Override Equals operators

        public bool Equals(TValueObject other)
        {
            if ((object)other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var publicProperties = GetType().GetProperties();

            if (publicProperties != null && publicProperties.Any())
            {
                return publicProperties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    if (typeof(TValueObject).IsAssignableFrom(left.GetType()))
                    {
                        return ReferenceEquals(left, right);
                    }
                    return left.Equals(right);
                });
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = obj as ValueObject<TValueObject>;

            if ((object)item != null)
            {
                return Equals((TValueObject)item);
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            var index = 1;

            var publicProperties = GetType().GetProperties();

            if (publicProperties != null
                &&
                publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    var value = item.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();

                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode = hashCode ^ (index * 13); //only for support {"a",null,null,"a"} <> {null,"a","a",null}
                    }
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null) ? true : false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }

        #endregion
    }
}