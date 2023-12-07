using Microsoft.EntityFrameworkCore;
using PhotoShop.Models.Domain;

namespace PhotoShop.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Product> Products {  get; set; }

    public DbSet<Order> Orders { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var products = new Product[10];

        var numberGenerator = new Random();

        for(var i = 1; i <= 10; i++)
        {
            var price = numberGenerator.Next(50, 1000);
            var photoId = numberGenerator.Next(1, 100);

            products[i - 1] = new Product(
                $"Photo {i}",
                $"This is Photo Nr {i} in our collection of photographs.",
                $"https://picsum.photos/id/{photoId}/500", 
                price);
        }

        builder.Entity<Product>().HasData(products);
    }
}
