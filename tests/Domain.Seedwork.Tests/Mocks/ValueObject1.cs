namespace Ritter.Domain.Seedwork.Tests.ValueObjects.Mocks
{
    internal class ValueObject1 : ValueObject<ValueObject1>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
