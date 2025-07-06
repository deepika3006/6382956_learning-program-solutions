using Microsoft.EntityFrameworkCore;
using RetailInventoryApp.Models;


namespace RetailInventoryApp.Data
{
    public class RetailContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RetailStore.db");
        }
    }
}
