// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using RetailInventory;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        //LAB4

        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);
        await context.SaveChangesAsync();

        Console.WriteLine("Data inserted successfully!");

        //LAB5

        // 1. Retrieve All Products
        Console.WriteLine("---All Products Detsils---:");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - Rs {p.Price}");

        Console.WriteLine();

        // 2. Find by ID
        Console.WriteLine("---Find by Id---:");
        int[] ids = { 1, 2 };
        foreach (var id in ids)
        {
            var product = await context.Products.FindAsync(id);
            Console.WriteLine($"Found by ID {id}: {product?.Name}");
        }

        Console.WriteLine();

        // 3. FirstOrDefault with Condition
        Console.WriteLine("---First Expensive Product With Condition:---:");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Condition: Product > Rs 50,000: {expensive?.Name}");
    }
}
