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
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RitterSample;Integrated Security=True";
            string migrationsAssembly = typeof(UnitOfWork).GetTypeInfo().Assembly.GetName().Name;
            DbContextOptionsBuilder<UnitOfWork> optionsBuilder = new DbContextOptionsBuilder<UnitOfWork>();

            optionsBuilder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly));

            using (UnitOfWork uow = new UnitOfWork(optionsBuilder.Options))
            using (IEmployeeRepository repository = new EmployeeRepository(uow))
            using (IEmployeeAppService appService = new EmployeeAppService(repository))
            {
                await (uow as DbContext).Database.EnsureDeletedAsync();
                await (uow as DbContext).Database.MigrateAsync();

                await appService.AddValidEmployee();
                await appService.AddInvalidEmployee();
                await appService.UpdateEmployee(1);
            }
        }
    }
}