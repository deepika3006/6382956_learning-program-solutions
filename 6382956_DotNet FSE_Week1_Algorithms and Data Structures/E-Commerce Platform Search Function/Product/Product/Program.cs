using System;

class Product
{
    public string name;
    public string category;
    public double price;

    public Product(string n, string c, double p)
    {
        name = n;
        category = c;
        price = p;
    }
}

class Program
{
    static void Main(string[] args)
    {
    
        Product[] products = new Product[5];
        products[0] = new Product("Laptop", "Electronics", 50000);
        products[1] = new Product("Mobile", "Electronics", 25000);
        products[2] = new Product("Shirt", "Clothing", 1500);
        products[3] = new Product("Shoes", "Footwear", 2000);
        products[4] = new Product("Jeans", "Clothing", 1800);
        
        Console.WriteLine("Welcome to our mini E-Commerce Search!");
        Console.WriteLine("Available categories: Electronics, Clothing, Footwear");
        Console.Write("Enter a category to search: ");
        string? searchCategory = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchCategory))
        {
            Console.WriteLine("You didn't enter a valid category.");
            return;
        }

        Console.WriteLine("\nProducts in category: " + searchCategory);
        int count = 0;

        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].category.ToLower() == searchCategory.ToLower())
            {
                Console.WriteLine("- " + products[i].name + " : ₹" + products[i].price);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No products found in this category.");
        }
        else
        {
            Console.WriteLine("\nTotal products found: " + count);
        }
    }
}
