using System.ComponentModel.DataAnnotations;

namespace PhotoShop.Models.Domain;

public class OrderLine
{
    public OrderLine(Guid productId, string productTitle, int quantity)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        ProductTitle = productTitle;
        Quantity = quantity;
    }

    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    [MaxLength(20)]
    public string ProductTitle { get; set; } = string.Empty;

    public int Quantity { get; set; }
}
