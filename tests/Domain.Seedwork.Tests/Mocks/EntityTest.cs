namespace Ritter.Domain.Seedwork.Tests.Mocks
{
    internal class EntityTest : Entity<EntityTest>
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
                Uid = Uid
            };
        }
    }
}
