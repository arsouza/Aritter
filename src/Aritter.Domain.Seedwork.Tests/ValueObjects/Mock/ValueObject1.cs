namespace Aritter.Domain.Seedwork.Tests.ValueObjects.Mock
{
    public class ValueObject1 : ValueObject<ValueObject1>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}