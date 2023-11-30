using PhotoShop.Models.ViewModels;

namespace PhotoShop.Models.Dto;

public class BasketDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
}
