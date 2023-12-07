using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoShop.Models.Domain;

public class Order
{
    public Order(int id)
    {
        Id = id;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public void AddProduct(Guid productId, string productTitle, int quantity)
    {
        OrderLines.Add(new OrderLine(productId, productTitle, quantity));
    }
}
