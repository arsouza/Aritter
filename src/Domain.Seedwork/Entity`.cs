namespace Ritter.Domain
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        protected Entity() { }

        public bool IsTransient() => Id.Equals(default(TKey));

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is Entity item)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (item.IsTransient() || IsTransient())
                {
                    return false;
                }

                return item.Id.Equals(Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (IsTransient())
                {
                    return Id.GetHashCode() ^ 31;
                }

                return (Id.GetHashCode() * 397) ^ Id.GetHashCode();
            }
        }
    }
}
