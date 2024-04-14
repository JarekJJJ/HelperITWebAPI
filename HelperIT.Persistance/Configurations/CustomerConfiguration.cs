using HelperIT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Persistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
          builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasDefaultValue("brak opisu");
        }
    }
}
