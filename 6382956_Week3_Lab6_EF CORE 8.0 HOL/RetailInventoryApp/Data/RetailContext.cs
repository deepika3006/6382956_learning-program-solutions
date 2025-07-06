using Microsoft.EntityFrameworkCore;
using RetailInventoryApp.Models;

namespace RetailInventoryApp.Data;

public class RetailContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Stock> Stocks => Set<Stock>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=retail.db");
}
