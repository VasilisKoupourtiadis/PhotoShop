using Microsoft.AspNetCore.Mvc;
using PhotoShop.Helpers;
using PhotoShop.Models.Dto;
using PhotoShop.Services;
using System.Text.Json;

namespace PhotoShop.ViewComponents;

public class Basket : ViewComponent
{
    private readonly IKeyHelper keyHelper;

    private readonly IBasketHelper basketHelper;

    public Basket(IKeyHelper keyHelper, IBasketHelper basketHelper) =>
        (this.keyHelper, this.basketHelper) = (keyHelper, basketHelper);

    public IViewComponentResult Invoke()
    {
        var basketItemCount = 0;

        var basketDto = basketHelper.GetBasket();

        foreach (var product in basketDto.Products)
        {
            basketItemCount += product.Quantity.GetValueOrDefault(0);
        }

        ViewData["BasketItemCount"] = basketItemCount;

        return View();
    }
}
