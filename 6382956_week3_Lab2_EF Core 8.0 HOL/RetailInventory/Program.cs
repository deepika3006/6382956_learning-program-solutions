using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailInventory
{
    class Program
    {
        static void Main()
        {
            using var context = new RetailDbContext();
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                SeedData(context);
            }

            var inventory = context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();

            Console.WriteLine("\nRetail Inventory:\n");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.ProductName,-20} | ₹{item.Price,8} | Stock: {item.Stock,3} | Category: {item.Category.CategoryName} | Supplier: {item.Supplier.SupplierName}");
            }
        }

        static void SeedData(RetailDbContext context)
        {
            var cat1 = new Category { CategoryName = "Electronics" };
            var cat2 = new Category { CategoryName = "Groceries" };

            var sup1 = new Supplier { SupplierName = "ElectroMax", ContactEmail = "contact@electromax.com" };
            var sup2 = new Supplier { SupplierName = "DailyNeeds", ContactEmail = "hello@dailyneeds.com" };

            var products = new List<Product>
            {
                new Product { ProductName = "Bluetooth Speaker", Price = 2500, Stock = 10, Category = cat1, Supplier = sup1 },
                new Product { ProductName = "LED TV", Price = 40000, Stock = 5, Category = cat1, Supplier = sup1 },
                new Product { ProductName = "Rice Bag 10kg", Price = 800, Stock = 20, Category = cat2, Supplier = sup2 }
            };

            context.Categories.AddRange(cat1, cat2);
            context.Suppliers.AddRange(sup1, sup2);
            context.Products.AddRange(products);
            context.SaveChanges();

            Console.WriteLine("\n Sample data inserted.\n");
        }
    }
}
