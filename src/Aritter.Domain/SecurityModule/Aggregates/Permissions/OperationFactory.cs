using Aritter.Domain.SecurityModule.Aggregates.Modules;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class OperationFactory
    {
        public static Operation CreateOperation(string name, Application application)
        {
            var operation = new Operation(name);
            operation.SetApplication(application);

            return operation;
        }
    }
}
