namespace Ritter.Domain.Seedwork.Tests.ValueObjects.Mocks
{
    internal class ValueObject3 : ValueObject<ValueObject3>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public ValueObject3 ValueObject { get; set; }
    }
}