using Ritter.Domain;

namespace Ritter.Application.Tests.Mocks
{
    internal class EntityTest : Entity
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
