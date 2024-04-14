using HelperIT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelperIT.Persistance
{
    public class HelperItDbContext: DbContext
    {
        public HelperItDbContext(DbContextOptions<HelperItDbContext> options): base(options)
        {
             
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            //Tutaj dodajemy ValueObject np:
            //modelBuilder.Entity<Director>().OwnsOne(p => p.DirectorName); - przykład z kursu
           modelBuilder.SeedData();
        }
    }
}
