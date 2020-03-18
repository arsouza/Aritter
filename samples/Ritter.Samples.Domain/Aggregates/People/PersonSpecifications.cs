using Ritter.Infra.Crosscutting.Specifications;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public static class PersonSpecifications
    {
        public static Specification<Person> PersonHasCpf(string cpf)
        {
            return new DirectSpecification<Person>(p => p.Cpf.Number == cpf);
        }

        public static Specification<Person> PersonHasId(long personId)
        {
            return new DirectSpecification<Person>(p => p.Id == personId);
        }
    }
}
