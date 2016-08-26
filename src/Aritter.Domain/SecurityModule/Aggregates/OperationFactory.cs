namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class OperationFactory
    {
        public static Operation CreateOperation(string name, Client client)
        {
            var operation = new Operation(name);
            operation.SetClient(client);

            return operation;
        }
    }
}
