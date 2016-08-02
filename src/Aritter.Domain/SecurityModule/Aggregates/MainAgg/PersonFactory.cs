namespace Aritter.Domain.SecurityModule.Aggregates.MainAgg
{
	public class PersonFactory
	{
		public static Person CreatePerson(string firstName, string lastName)
		{
			return new Person(firstName, lastName);
		}
	}
}
