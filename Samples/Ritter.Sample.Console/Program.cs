using Microsoft.EntityFrameworkCore;
using Ritter.Samples.Application;
using Ritter.Samples.Domain;
using Ritter.Samples.Infra.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace Ritter.Sample.Console
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            var migrationsAssembly = typeof(UnitOfWork).GetTypeInfo().Assembly.GetName().Name;
            var optionsBuilder = new DbContextOptionsBuilder<UnitOfWork>();

            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RitterSample;Integrated Security=True", options =>
                options.MigrationsAssembly(migrationsAssembly));

            using (var context = new UnitOfWork(optionsBuilder.Options))
            {
                await (context as DbContext).Database.EnsureDeletedAsync();
                await (context as DbContext).Database.MigrateAsync();

                IEmployeeRepository repository = new EmployeeRepository(context);
                IEmployeeAppService appService = new EmployeeAppService(repository);

                var employee1 = await appService.TestAddAndUpdate();
                await appService.TestUpdate(employee1.Id);

                System.Console.WriteLine(employee1.Name);
            }
        }
    }
}
