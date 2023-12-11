using Microsoft.AspNetCore.Mvc;
using PhotoShop.Data;
using PhotoShop.Models.Dto;
using System.Text.Json;
using PhotoShop.Models.ViewModels;
using PhotoShop.Helpers;
using PhotoShop.Services;

namespace PhotoShop.Controllers;

public class CartController : Controller
{
    private readonly IKeyHelper keyHelper;

    private readonly IBasketHelper basketHelper;

    public CartController(IKeyHelper keyHelper, IBasketHelper basketHelper) =>
        (this.keyHelper, this.basketHelper) = (keyHelper, basketHelper);

    public IActionResult DecreaseCartItemQuantityByOne(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basketDto = basketHelper.GetBasket();

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null) 
        {
            var individualItemPrice = item.Price / item.Quantity;
            item.Price -= individualItemPrice.GetValueOrDefault(0);
            item.Quantity--;            
        }

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        var sessionKey = keyHelper.GetSessionKey();
        HttpContext.Session.SetString(sessionKey, serializedBasket);

        return Redirect(referer);
    }

    public IActionResult IncreaseCartItemQuantityByOne(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basketDto = basketHelper.GetBasket();

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null)
        {
            var individualItemPrice = item.Price / item.Quantity;
            item.Price += individualItemPrice.GetValueOrDefault(0);
            item.Quantity++;
        }

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        var sessionKey = keyHelper.GetSessionKey();
        HttpContext.Session.SetString(sessionKey, serializedBasket);

        return Redirect(referer);
    }

    public IActionResult DeleteCartItemRow(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var basketDto = basketHelper.GetBasket();

        var item = basketDto.Products.FirstOrDefault(x => x.Id == id);

        if (item is not null) basketDto.Products.Remove(item);

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        var sessionKey = keyHelper.GetSessionKey();
        HttpContext.Session.SetString(sessionKey, serializedBasket);

        return Redirect(referer);
    }
}
