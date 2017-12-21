using Domain.Seedwork.Validation;
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

        public IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable
        {
            var contract = this.ValidateContract<ValidableEntityTest>(ctx =>
            {
                ctx.Property(p => p.Id)
                    .HasMaxValue(50);
            });

            return contract as IValidationContract<TValidable>;
        }
    }
}