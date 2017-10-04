namespace Ritter.Infra.Crosscutting.Tests.Mocks
{
    internal class TestObject1
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int TestObject2Id { get; set; }
        public TestObject2 TestObject2 { get; set; }
    }
}
