namespace Ritter.Domain.Tests.Mocks
{
    internal class EntityTest : Domain.Entity
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
    }
}
