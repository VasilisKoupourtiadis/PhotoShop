using Microsoft.AspNetCore.Mvc;
using PhotoShop.Data;
using PhotoShop.Models.Dto;
using System.Text.Json;
using PhotoShop.Models.ViewModels;

namespace PhotoShop.Controllers;

public class CartController : Controller
{
    const string SessionKey = "Basket";

    private readonly ApplicationContext context;

    public CartController(ApplicationContext context)
    {
        this.context = context;
    }

    public IActionResult DecreaseCartItemQuantityByOne(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basket = HttpContext.Session.GetString(SessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            if (basketDto is null) return View("Error");
        }

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null) 
        {
            var individualItemPrice = item.Price / item.Quantity;
            item.Price -= individualItemPrice.GetValueOrDefault(0);
            item.Quantity--;            
        }

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        HttpContext.Session.SetString(SessionKey, serializedBasket);

        return Redirect(referer);
    }

    public IActionResult IncreaseCartItemQuantityByOne(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basket = HttpContext.Session.GetString(SessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            if (basketDto is null) return View("Error");
        }

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null)
        {
            var individualItemPrice = item.Price / item.Quantity;
            item.Price += individualItemPrice.GetValueOrDefault(0);
            item.Quantity++;
        }

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        HttpContext.Session.SetString(SessionKey, serializedBasket);

        return Redirect(referer);
    }

    public IActionResult DeleteCartItemRow(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basket = HttpContext.Session.GetString(SessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            if (basketDto is null) return View("Error");
        }

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null) basketDto.Products.Remove(item);

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        HttpContext.Session.SetString(SessionKey, serializedBasket);

        return Redirect(referer);
    }
}
