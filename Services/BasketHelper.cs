using PhotoShop.Models.Dto;
using System.Text.Json;

namespace PhotoShop.Services;

public class BasketHelper : IBasketHelper
{
    private readonly IKeyHelper keyHelper;

    private readonly IHttpContextAccessor httpContextAccessor;

    public BasketHelper(IKeyHelper keyHelper, IHttpContextAccessor httpContextAccessor) =>
        (this.keyHelper, this.httpContextAccessor) = (keyHelper, httpContextAccessor);

    public BasketDto GetBasket()
    {
        var sessionKey = keyHelper.GetSessionKey();

        try
        {
            var basket = httpContextAccessor?.HttpContext?.Session.GetString(sessionKey);

            var basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

            return basketDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return new BasketDto();
        }
    }
}
