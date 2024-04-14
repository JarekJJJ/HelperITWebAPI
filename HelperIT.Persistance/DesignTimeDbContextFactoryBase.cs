using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Persistance
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "HelperItDatabase";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}HelperITWebAPI",
                Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            return Create(connectionString);
        }
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"SQL connection string '{connectionString}' is null or empty");
            }
            Console.WriteLine($"DesignTimeDbContextFactoryBase.Ceate(string): Connection string: '{connectionString}'.");
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
