using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Persistance
{
    public class HelperITDbContextFactory : DesignTimeDbContextFactoryBase<HelperItDbContext>
    {
        protected override HelperItDbContext CreateNewInstance(DbContextOptions<HelperItDbContext> options)
        {
            return new HelperItDbContext(options);
        }
    }
}
