using HelperIT.Application.Common.Interfaces;
using HelperIT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HelperIT.Persistance
{
    public class HelperItDbContext: DbContext
    {
        //private readonly IDateTime _dateTime;
        public HelperItDbContext(DbContextOptions<HelperItDbContext> options): base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // base.OnModelCreating(modelBuilder);
            //Tutaj dodajemy ValueObject np:
            //modelBuilder.Entity<Director>().OwnsOne(p => p.DirectorName); - przykład z kursu
           modelBuilder.SeedData();
        }
    }
}
