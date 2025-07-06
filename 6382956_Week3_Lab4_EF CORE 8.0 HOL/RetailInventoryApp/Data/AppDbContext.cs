using Microsoft.EntityFrameworkCore;
using RetailInventoryApp.Models;

namespace RetailInventoryApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=RetailInventory.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
    }
}
