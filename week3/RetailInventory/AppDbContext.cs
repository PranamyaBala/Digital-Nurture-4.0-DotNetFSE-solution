using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace this with your actual connection string
            optionsBuilder.UseSqlServer("Server=BT-22053262;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
