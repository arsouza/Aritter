using System;
using Microsoft.EntityFrameworkCore;

namespace Ritter.Infra.Data.Query
{
    public abstract class EFQueryUnitOfWork : DbContext, IEFQueryUnitOfWork
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected EFQueryUnitOfWork(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            if (environment.Equals("Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
