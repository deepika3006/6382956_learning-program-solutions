using RetailInventoryApp.Data;
using RetailInventoryApp.Models;
using Microsoft.EntityFrameworkCore;

using var context = new RetailContext();
await context.Database.EnsureCreatedAsync();

// Insert if empty
if (!await context.Products.AnyAsync())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    var supplier = new Supplier { Name = "Tech Supplier", Email = "tech@supplier.com" };

    var p1 = new Product
    {
        Name = "Laptop",
        Price = 75000,
        Category = electronics,
        Supplier = supplier,
        Stock = new Stock { QuantityAvailable = 10, LastChecked = DateTime.Now }
    };

    var p2 = new Product
    {
        Name = "Rice Bag",
        Price = 1200,
        Category = groceries,
        Supplier = supplier,
        Stock = new Stock { QuantityAvailable = 100, LastChecked = DateTime.Now }
    };

    var p3 = new Product
    {
        Name = "Smartphone",
        Price = 30000,
        Category = electronics,
        Supplier = supplier,
        Stock = new Stock { QuantityAvailable = 30, LastChecked = DateTime.Now }
    };

    await context.AddRangeAsync(electronics, groceries, supplier, p1, p2, p3);
    await context.SaveChangesAsync();
    Console.WriteLine("Sample data inserted.\n");
}

var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p =>(double) p.Price)
    .ToListAsync();

Console.WriteLine(" Filtered Products ((double)Price > ₹1000):");
foreach (var p in filtered)
{
    Console.WriteLine($"- {p.Name}: ₹{p.Price}");
}

// LINQ Projection to DTO
var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();

Console.WriteLine("\n DTO Projection (Name + Price):");
foreach (var dto in productDTOs)
{
    Console.WriteLine($"• {dto.Name} - ₹{dto.Price}");
}
