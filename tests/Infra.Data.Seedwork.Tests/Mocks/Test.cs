using System;
using Ritter.Domain.Seedwork;

namespace Infra.Data.Seedwork.Tests.Mocks
{
    public class Test : Entity
    {
        public bool Active { get; set; }

        public Test(int id)
            : this(id, true)
        {
        }

        public Test(int id, bool active)
            : this()
        {
            Id = id;
            Active = active;
        }

        public Test()
            : base()
        {
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
