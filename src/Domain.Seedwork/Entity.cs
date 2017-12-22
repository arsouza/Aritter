using Ritter.Domain.Seedwork.Validation;
using System;

namespace Ritter.Domain.Seedwork
{
    public abstract class Entity : IEntity
    {
        private int? requestedHashCode;

        public virtual int Id { get; protected set; }

        public virtual Guid Uid { get; protected set; } = Guid.NewGuid();

        protected Entity() : base() { }

        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            Entity item = obj as Entity;

            if (item.IsTransient() || this.IsTransient())
                return false;

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!requestedHashCode.HasValue)
                    requestedHashCode = this.Id.GetHashCode() ^ 31;

                return requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}