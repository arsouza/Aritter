using System;

namespace Aritter.Domain.Seedwork
{
    public abstract class Entity : IEntity
    {
        #region Members

        private int? currentHashCode;

        #endregion

        #region Properties

        public virtual int Id { get; private set; }

        public virtual Guid UID { get; private set; }

        #endregion

        #region Constructors

        public Entity()
        {
            GenerateUID();
        }

        #endregion

        #region Public Methods

        public bool IsTransient()
        {
            return Id == default(int);
        }

        public bool IsStored()
        {
            return Id > default(int);
        }

        public void GenerateUID()
        {
            if (IsTransient())
                UID = Guid.NewGuid();
        }

        public void SetUID(Guid uid)
        {
            if (!IsTransient())
                UID = uid;
        }

        #endregion

        #region Overrides Methods

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var entity = (Entity)obj;

            if (!entity.IsTransient() || !IsTransient())
                return entity.Id == Id;

            if (entity.IsTransient() || IsTransient())
                return entity.UID == UID;

            return entity.Id == Id
                && entity.UID == UID;
        }

        public override int GetHashCode()
        {
            if (IsTransient())
                currentHashCode = base.GetHashCode();
            else if (!currentHashCode.HasValue)
                currentHashCode = UID.GetHashCode() ^ 31;

            return currentHashCode.Value;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, null)
                ? Equals(right, null)
                : left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
