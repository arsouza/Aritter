using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ritter.Infra.Data
{
    public abstract class EFUnitOfWork : DbContext, IEFUnitOfWork, ISql
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected EFUnitOfWork(DbContextOptions options) : base(options)
        {
        }

        public virtual int ExecuteCommand(string sqlCommand, params object[] parameters) => Database.ExecuteSqlRaw(sqlCommand, parameters);

        public virtual async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters) => await Database.ExecuteSqlRawAsync(sqlCommand, parameters);

        public virtual async Task<int> ExecuteCommandAsync(string sqlCommand, IEnumerable<object> parameters, CancellationToken cancellationToken = default) => await Database.ExecuteSqlRawAsync(sqlCommand, parameters, cancellationToken);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            if (Equals(environment, "Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
