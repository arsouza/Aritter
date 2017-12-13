using Ritter.Domain.Seedwork.Validation;
using System;

namespace Ritter.Domain.Seedwork
{
    public abstract class Entity : Validable, IEntity
    {
        public virtual int Id { get; protected set; }

        public virtual Guid Uid { get; protected set; } = Guid.NewGuid();

        protected Entity() : base() {}

        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var entity = obj as Entity;

            if (!entity.IsTransient() || !IsTransient())
                return entity.Id == Id;

            return entity.Uid == Uid;
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }
    }
}