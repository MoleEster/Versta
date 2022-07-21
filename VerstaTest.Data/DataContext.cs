using Microsoft.EntityFrameworkCore;
using VerstaTest.Data.Data;

namespace VerstaTest.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
