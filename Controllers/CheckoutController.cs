using Microsoft.AspNetCore.Mvc;
using PhotoShop.Models.Dto;
using System.Text.Json;
using Stripe;
using Stripe.Checkout;

namespace PhotoShop.Controllers;

public class CheckoutController : Controller
{
    const string SessionKey = "Basket";

    const string Domain = "https://localhost:7015";

    const string Mode = "payment";

    const string Currency = "USD";

    const string PaymentMethod = "card";

    public IActionResult Index()
    {
        var basket = HttpContext.Session.GetString(SessionKey);

        var basketDto = new BasketDto();

        if (!string.IsNullOrEmpty(basket))
        {
            basketDto = JsonSerializer.Deserialize<BasketDto>(basket);
        }
        
        return View(basketDto);
    }

    public IActionResult CreateCheckoutSession()
    {
        var basket = HttpContext.Session.GetString(SessionKey);

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
            SuccessUrl = $"{Domain}/Home/Success",
            CancelUrl = $"{Domain}/Home/Cancel",
        };

        var lineItems = new List<SessionLineItemOptions>();

        foreach(var product in basketDto.Products)
        {
            var sessionLineItemOption = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = Currency,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Description = product.Description,
                        Images = new List<string> { product.ImageUrl }
                    },
                },
                Quantity = 1
            };

            lineItems.Add(sessionLineItemOption);
        }

        options.LineItems = lineItems;
        var service = new SessionService();
        var session = service.Create(options);

        return Redirect(session.Url);
    }
}
