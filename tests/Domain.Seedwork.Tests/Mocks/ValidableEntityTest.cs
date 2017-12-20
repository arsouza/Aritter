using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Fluent;

namespace Ritter.Domain.Seedwork.Tests.Mocks
{
    internal class ValidableEntityTest : Domain.Seedwork.Entity, IValidable
    {
        public ValidableEntityTest() : base() { }

        public ValidableEntityTest(int id) : base()
        {
            Id = id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public ValidationResult Validate()
        {
            this.ValidateContract(contract =>
            {
                contract.Property(p => p.Id)
                    .HasMaxValue(50);
            });

            return null;
        }
    }
}