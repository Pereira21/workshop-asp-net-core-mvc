using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
