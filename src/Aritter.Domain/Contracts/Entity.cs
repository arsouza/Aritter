namespace Aritter.Domain.Contracts
{
    public abstract class Entity : IEntity
    {
        #region Constructor

        public Entity()
        {
            Enabled = true;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public bool Enabled { get; set; }

        #endregion Properties

        #region Methods

        public void Enable()
        {
            if (!Enabled)
            {
                Enabled = true;
            }
        }

        public void Disable()
        {
            if (Enabled)
            {
                Enabled = false;
            }
        }

        #endregion
    }
}