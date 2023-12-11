using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotoShop.Data;
using PhotoShop.Helpers;
using PhotoShop.Models.Dto;
using PhotoShop.Models.ViewModels;
using PhotoShop.Services;
using System.Text.Json;

namespace PhotoShop.Controllers;

public class ProductsController : Controller
{    
    const string URLPath = "details";

    private readonly IBasketHelper basketHelper;

    private readonly IKeyHelper keyHelper;

    private readonly ApplicationContext context;

    private readonly IMapper mapper;

    public ProductsController(IBasketHelper basketHelper, IKeyHelper keyHelper, ApplicationContext context, IMapper mapper) =>
        (this.basketHelper, this.keyHelper, this.context, this.mapper) = (basketHelper, keyHelper, context, mapper);

    public IActionResult Details(Guid? id)
    {
        var dataFetcher = new DataFetcher(context, mapper);

        var product = dataFetcher.GetProductById(id).Result;

        return View(product);
    }

    public IActionResult AddProductToCart(Guid? id)
    {
        var referer = Request.Headers["Referer"].ToString();

        var dataFetcher = new DataFetcher(context, mapper);

        var product = dataFetcher.GetProductById(id).Result;

        var basketDto = basketHelper.GetBasket();

        var productAlreadyInCart = basketDto.Products.FirstOrDefault(x => x.Id == product.Id);

        if (productAlreadyInCart is not null)
        {
            productAlreadyInCart.Quantity++;
            productAlreadyInCart.Price *= 2;
        }
        else
        {
            product.Quantity = 1;
            basketDto.Products.Add(product);
        }        

        var serializedBasket = JsonSerializer.Serialize(basketDto);

        var sessionKey = keyHelper.GetSessionKey();

        HttpContext.Session.SetString(sessionKey, serializedBasket);

        if(referer.ToLower().Contains(URLPath)) return RedirectToAction(nameof(Details), new { id });

        return Redirect(referer);
    }
}
