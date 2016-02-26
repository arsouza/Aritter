using System;

namespace Aritter.Domain.Seedwork.Aggregates
{
    public abstract class Entity : IEntity
    {
        #region Constructor

        public Entity()
        {
            Enable();
            Guid = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public bool Enabled { get; set; }

        public Guid Guid { get; set; }

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