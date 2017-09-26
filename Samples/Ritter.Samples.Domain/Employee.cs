using Ritter.Domain.Seedwork;

namespace Ritter.Samples.Domain
{
    public class Employee : Entity
    {
        public string Name { get; private set; }

        protected Employee()
            : base()
        {

        }

        public Employee(string name)
            : this()
        {
            Name = name;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
