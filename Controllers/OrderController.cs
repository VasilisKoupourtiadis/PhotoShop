using Microsoft.AspNetCore.Mvc;
using PhotoShop.Data;
using PhotoShop.Helpers;
using PhotoShop.Models.Domain;
using PhotoShop.Models.Dto;
using PhotoShop.Models.ViewModels;
using PhotoShop.Services;
using System.Text.Json;

namespace PhotoShop.Controllers;

public class OrderController : Controller
{
    private readonly IKeyHelper keyHelper;

    private readonly IBasketHelper basketHelper;

    private readonly ApplicationContext context;

    public OrderController(IKeyHelper keyHelper, IBasketHelper basketHelper, ApplicationContext context) => 
        (this.keyHelper, this.basketHelper, this.context) = (keyHelper, basketHelper, context);

    public async Task<IActionResult> Success(Guid? id)
    {        
        var basketDto = basketHelper.GetBasket();

        Random rand = new();
        var orderId = 00 + rand.Next(10000000, 99000000);

        var order = new Order(orderId);

        decimal total = 0;

        foreach (var product in basketDto.Products)
        {
            order.AddProduct(product.Id, product.Title, product.Quantity.GetValueOrDefault(0));
            total += product.Price;
        }

        await context.AddAsync(order);
        await context.SaveChangesAsync();

        var checkoutViewModel = new CheckoutViewModel()
        {
            Basket = basketDto,
            Total = total,
            OrderId = order.Id
        };

        var sessionKey = keyHelper.GetSessionKey();
        HttpContext.Session.Remove(sessionKey);

        return View(checkoutViewModel);
    }

    public IActionResult Cancel(Guid? id)
    {
        return View();
    }
}
