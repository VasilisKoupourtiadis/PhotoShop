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

    private readonly IKeyHelper keyHelper;

    private readonly ILogger<ProductsController> logger;

    private readonly ApplicationContext context;

    private readonly IMapper mapper;

    public ProductsController(ILogger<ProductsController> logger, ApplicationContext context, IMapper mapper, IKeyHelper keyHelper)
    {
        this.logger = logger;
        this.context = context;
        this.mapper = mapper;
        this.keyHelper = keyHelper;
    }

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

        var sessionKey = keyHelper.GetSessionKey();

        var basket = HttpContext.Session.GetString(sessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            if (basketDto is null) return View("Error");            
        }

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

        HttpContext.Session.SetString(sessionKey, serializedBasket);

        if(referer.ToLower().Contains(URLPath)) return RedirectToAction(nameof(Details), new { id });

        return Redirect(referer);
    }
}
