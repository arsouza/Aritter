using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ritter.Samples.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(new string[] { "http://localhost:5000", "http://localhost:5001" })
                .UseKestrel()
                .Build()
                .Run();
        }
    }
}