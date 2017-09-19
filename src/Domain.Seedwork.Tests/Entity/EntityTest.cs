namespace Ritter.Domain.Seedwork.Tests.Entity
{
    public class EntityTest : Seedwork.Entity
    {
        public EntityTest()
            : base()
        {
        }

        public EntityTest(int id)
            : base()
        {
            Id = id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public EntityTest Clone()
        {
            return new EntityTest
            {
                Id = Id,
                UID = UID
            };
        }
    }
}
