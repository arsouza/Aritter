using Ritter.Domain.Seedwork;

namespace Infra.Data.Seedwork.Tests.Repositories.Mock
{
    public class Test : Entity
    {
        public Test(int id)
            : this()
        {
            Id = id;
        }

        public Test()
            : base()
        {
        }
    }
}
