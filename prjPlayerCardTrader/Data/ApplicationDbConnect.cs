using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prjPlayerCardTrader.Models;

namespace prjPlayerCardTrader.Data
{
    public class ApplicationDbConnect : DbContext
    {

        public ApplicationDbConnect(DbContextOptions<ApplicationDbConnect> options)
            : base(options)
        {
        }


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbConnect).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
