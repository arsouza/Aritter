using Ritter.Domain.Seedwork.Validation;
using System.Linq;

namespace Ritter.Domain.Seedwork
{
    public class ValueObject<TValueObject> : Validable<TValueObject> where TValueObject : class
    {
        public ValueObject() : base() {}

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is ValueObject<TValueObject>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var properties = GetType().GetProperties();

            if (properties.Any())
            {
                return properties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(obj, null);

                    if (left is ValueObject<TValueObject>)
                        return ReferenceEquals(left, right);

                    return left.Equals(right);
                });
            }

            return true;
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
                        hashCode = hashCode ^ (index * 13);
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !Equals(left, right);
        }
    }
}