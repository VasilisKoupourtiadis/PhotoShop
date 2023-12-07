namespace PhotoShop.Services;

public class KeyHelper : IKeyHelper
{
    private readonly string SessionKey = "Basket";

    public string GetSessionKey() => SessionKey;
}
