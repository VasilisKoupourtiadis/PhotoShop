using Microsoft.AspNetCore.Mvc;
using PhotoShop.Models.Dto;
using System.Text.Json;

namespace PhotoShop.ViewComponents;

public class Basket : ViewComponent
{
    const string sessionKey = "Basket";

    public IViewComponentResult Invoke()
    {
        var basketItemCount = 0;

        var basket = HttpContext.Session.GetString(sessionKey);

        if(!string.IsNullOrEmpty(basket))
        {
            var basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            foreach(var product in basketDto.Products)
            {
                basketItemCount += product.Quantity.GetValueOrDefault(0);
            }            
        }

        ViewData["BasketItemCount"] = basketItemCount;

        return View();
    }
}
