using Ritter.Domain;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Exceptions;
using System;

namespace Ritter.Samples.Domain.Aggregates.Persons
{
    public class PersonName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonName() : base() { }

        public PersonName(string firstName, string lastName) : this()
        {
            Ensure.That<ValidationException>(!firstName.IsNullOrEmpty(), "The First Name is required.");
            Ensure.That<ValidationException>(!lastName.IsNullOrEmpty(), "The Last Name is required.");

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
