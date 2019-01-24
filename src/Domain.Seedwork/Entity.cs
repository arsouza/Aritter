using Ritter.Infra.Crosscutting.Validations;
using System;

namespace Ritter.Domain
{
    public abstract class Entity : Validatable, IEntity
    {
        public virtual int Id { get; protected set; }

        public virtual Guid Uid { get; protected set; } = Guid.NewGuid();

        protected Entity()
            : base()
        {
        }

        public bool IsTransient()
            => Id == default;

        public override bool Equals(object obj)
        {
            if (obj.IsNull())
                return false;

            if (obj is Entity item)
            {
                if (ReferenceEquals(this, obj))
                    return true;

                if (item.IsTransient() || IsTransient())
                    return false;

                return item.Id == Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (IsTransient())
                    return Uid.GetHashCode() ^ 31;

                return (Id.GetHashCode() * 397) ^ Uid.GetHashCode();
            }
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
            => !(left == right);
    }
}
