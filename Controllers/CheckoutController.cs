using Microsoft.AspNetCore.Mvc;
using PhotoShop.Models.Dto;
using System.Text.Json;
using Stripe;
using Stripe.Checkout;
using PhotoShop.Models.ViewModels;
using PhotoShop.Helpers;

namespace PhotoShop.Controllers;

public class CheckoutController : Controller
{
    const string Domain = "https://localhost:7015";

    const string Mode = "payment";

    const string Currency = "USD";

    const string PaymentMethod = "card";

    private readonly string sessionKey = StringHelper.GetSessionKey();

    public IActionResult Index()
    {
        var basket = HttpContext.Session.GetString(sessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);
        }

        decimal total = 0;

        foreach (var item in basketDto.Products)
        {
            total += item.Price;
        }

        var checkoutViewModel = new CheckoutViewModel()
        {
            Basket = basketDto,
            Total = total
        };

        return View(checkoutViewModel);
    }

    public IActionResult CreateCheckoutSession()
    {
        var basket = HttpContext.Session.GetString(sessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);
        }

        var options = new SessionCreateOptions
        {            
            PaymentMethodTypes = new List<string>
            {
                PaymentMethod
            },
            Mode = Mode,
            SuccessUrl = $"{Domain}/Order/Success/" + basketDto.Id,
            CancelUrl = $"{Domain}/Order/Cancel/" + basketDto.Id,
        };

        var lineItems = new List<SessionLineItemOptions>();

        foreach(var product in basketDto.Products)
        {
            var sessionLineItemOption = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = (product.Price * 100) / product.Quantity,
                    Currency = Currency,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Description = product.Description,
                        Images = new List<string> { product.ImageUrl }
                    },
                },
                Quantity = product.Quantity
            };

            lineItems.Add(sessionLineItemOption);
        }

        options.LineItems = lineItems;
        var service = new SessionService();
        var session = service.Create(options);

        return Redirect(session.Url);
    }
}
