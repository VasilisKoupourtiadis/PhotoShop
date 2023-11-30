using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhotoShop.Models.Domin;

public class Product
{
    public Product(string title, string description, string imageUrl, decimal price)
    {
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(20)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(200)]
    public string ImageUrl { get; set; }

    [Precision(6,2)]
    public decimal Price { get; set; }
}
