using RetailInventoryApp.Data;
using RetailInventoryApp.Models;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new RetailContext())
        {
            context.Database.EnsureCreated();

            Console.WriteLine("Database setup complete with sample data.\n");

            if (!context.Categories.Any())
            {
                var category1 = new Category
                {
                    Name = "Beverages",
                    Products = new List<Product>()
                };

                var category2 = new Category
                {
                    Name = "Groceries",
                    Products = new List<Product>()
                };

                var supplier1 = new Supplier
                {
                    SupplierName = "Global Beverages",
                    ContactEmail = "contact@globalbev.com",
                    Products = new List<Product>()
                };

                var supplier2 = new Supplier
                {
                    SupplierName = "Fresh Farm Foods",
                    ContactEmail = "info@freshfarm.com",
                    Products = new List<Product>()
                };

                var product1 = new Product
                {
                    ProductName = "Orange Juice",
                    Price = 49.99M,
                    Category = category1,
                    Supplier = supplier1
                };

                var product2 = new Product
                {
                    ProductName = "Whole Wheat Rice",
                    Price = 72.50M,
                    Category = category2,
                    Supplier = supplier2
                };

                var stock1 = new Stock
                {
                    QuantityAvailable = 100,
                    LastChecked = DateTime.Now,
                    Product = product1
                };
                product1.Stock = stock1;

                var stock2 = new Stock
                {
                    QuantityAvailable = 60,
                    LastChecked = DateTime.Now,
                    Product = product2
                };
                product2.Stock = stock2;

                category1.Products.Add(product1);
                category2.Products.Add(product2);
                supplier1.Products.Add(product1);
                supplier2.Products.Add(product2);

                context.Categories.AddRange(category1, category2);
                context.Suppliers.AddRange(supplier1, supplier2);
                context.Products.AddRange(product1, product2);
                context.Stocks.AddRange(stock1, stock2);
                context.SaveChanges();
            }

            Console.WriteLine("=== CATEGORIES ===");
            foreach (var category in context.Categories)
            {
                Console.WriteLine($"ID: {category.CategoryId}, Name: {category.Name}");
            }

            Console.WriteLine("\n=== SUPPLIERS ===");
            foreach (var supplier in context.Suppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.SupplierName}, Email: {supplier.ContactEmail}");
            }

            Console.WriteLine("\n=== PRODUCTS ===");
            foreach (var product in context.Products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}, " +
                                  $"Category: {product.Category.Name}, Supplier: {product.Supplier.SupplierName}");
            }

            Console.WriteLine("\n=== STOCKS ===");
            foreach (var stock in context.Stocks)
            {
                Console.WriteLine($"Stock ID: {stock.StockId}, Quantity: {stock.QuantityAvailable}, " +
                                  $"Last Checked: {stock.LastChecked}, Product: {stock.Product.ProductName}");
            }
        }
        string dbPath = "RetailStoreLite.db"; 
        string connectionString = $"Data Source={dbPath}";

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        Console.WriteLine("\nConnected to SQLite database via raw query.\n");

        var getTablesCommand = connection.CreateCommand();
        getTablesCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

        using var tablesReader = getTablesCommand.ExecuteReader();
        while (tablesReader.Read())
        {
            string tableName = tablesReader.GetString(0);
            Console.WriteLine($"\n📋 TABLE: {tableName}");

            var getContentCommand = connection.CreateCommand();
            getContentCommand.CommandText = $"SELECT * FROM {tableName};";

            using var contentReader = getContentCommand.ExecuteReader();
 
            for (int i = 0; i < contentReader.FieldCount; i++)
            {
                Console.Write($"{contentReader.GetName(i),-20}");
            }
            Console.WriteLine();

            while (contentReader.Read())
            {
                for (int i = 0; i < contentReader.FieldCount; i++)
                {
                    Console.Write($"{contentReader.GetValue(i),-20}");
                }
                Console.WriteLine();
            }
        }

        connection.Close(); 
    }
}
