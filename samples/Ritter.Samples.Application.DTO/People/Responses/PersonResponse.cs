using System;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Application.DTO.People.Responses
{
    public class PersonResponse
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public static explicit operator PersonResponse(Person person)
        {
            if (person == null)
                return null;

            return new PersonResponse
            {
                PersonId = person.Id,
                FirstName = person.Name.FirstName,
                LastName = person.Name.LastName,
                Cpf = person.Cpf?.Number
            };
        }
    }
}
