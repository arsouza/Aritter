namespace Aritter.Domain.SecurityModule.Aggregates.Modules
{
    public static class ResourceFactory
    {
        public static Resource CreateResource(string name, Application application)
        {
            return CreateResource(name, null, application);
        }

        public static Resource CreateResource(string name, string description, Application application)
        {
            var resource = new Resource(name, description);
            resource.SetApplication(application);

            return resource;
        }
    }
}
