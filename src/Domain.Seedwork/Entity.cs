using System;

namespace Ritter.Domain
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; protected set; }

        public virtual Guid Uid { get; protected set; } = Guid.NewGuid();

        protected Entity() : base() { }

        public bool IsTransient() => Id == default(int);

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            Entity item = obj as Entity;

            if (item.IsTransient() || this.IsTransient())
                return false;

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
                return this.Id.GetHashCode() ^ 31;

            return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
