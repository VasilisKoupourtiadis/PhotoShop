namespace PhotoShop.Models.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; } 

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int? Quantity { get; set; }
}
