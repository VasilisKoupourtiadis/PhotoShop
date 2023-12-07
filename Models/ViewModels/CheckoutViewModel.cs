using PhotoShop.Models.Dto;

namespace PhotoShop.Models.ViewModels;

public class CheckoutViewModel
{
    public BasketDto Basket { get; set; }

    public decimal Total { get; set; }

    public int OrderId { get; set; }
}
