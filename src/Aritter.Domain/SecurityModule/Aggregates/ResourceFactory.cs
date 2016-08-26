namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class ResourceFactory
    {
        public static Resource CreateResource(string name, Client client)
        {
            return CreateResource(name, null, client);
        }

        public static Resource CreateResource(string name, string description, Client client)
        {
            var resource = new Resource(name, description);
            resource.SetClient(client);

            return resource;
        }
    }
}
