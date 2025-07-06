using RetailInventoryApp.Data;
using RetailInventoryApp.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

// Step 1: Ensure the database is created
await context.Database.EnsureCreatedAsync();

// Step 2: Seed initial data if not already present
if (!context.Categories.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Smartphone", Price = 20000m, Category = electronics };
    var product2 = new Product { Name = "Washing Machine", Price = 18000m, Category = electronics };
    var product3 = new Product { Name = "Wheat Flour", Price = 450m, Category = groceries };
    var product4 = new Product { Name = "Sugar", Price = 60m, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2, product3, product4);
    await context.SaveChangesAsync();

    Console.WriteLine("Initial data inserted successfully.\n");
}
else
{
    Console.WriteLine(" Data already exists. Skipping insert.\n");
}

// Step 3: Query and verify the data
Console.WriteLine(" Categories and Products:");

var categories = await context.Categories
    .Include(c => c.Products)
    .ToListAsync();

foreach (var category in categories)
{
    Console.WriteLine($"\n Category: {category.Name}");

    foreach (var product in category.Products)
    {
        Console.WriteLine($" Product: {product.Name} - ₹{product.Price}");
    }
}
