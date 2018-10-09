using Ritter.Domain;
using System.Text.RegularExpressions;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public class Cpf : ValueObject
    {
        public string Value { get; private set; }

        protected Cpf()
            : base()
        {
        }

        public Cpf(string value)
            : this()
        {
            Value = Regex.Replace(value, "[^0-9]", "");

            AddValidations(context =>
            {
                context.Property<Cpf>(e => e.Value)
                    .IsRequired("O CPF é obrigatório")
                    .HasMaxLength(11)
                    .HasPattern(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                    .IsCpf();

                return context.Validate(this);
            });
        }
    }
}
