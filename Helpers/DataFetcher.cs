using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoShop.Data;
using PhotoShop.Models.Domin;
using PhotoShop.Models.ViewModels;

namespace PhotoShop.Helpers;

public class DataFetcher : ControllerBase
{
    private readonly ApplicationContext context;

    private readonly IMapper mapper;

    public DataFetcher(ApplicationContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ICollection<ProductViewModel>> GetProducts()
    {
        if(context.Products is null) throw new ArgumentNullException(nameof(context.Products));

        var products = await context.Products.ToListAsync();

        if(products is null || products.Count == 0) throw new ArgumentNullException($"{nameof(products)}.");

        var mappedProducts = mapper.Map<ICollection<ProductViewModel>>(products);

        return mappedProducts;
    }

    public async Task<ProductViewModel> GetProductById(Guid? id)
    {
        if (context.Products is null) throw new ArgumentNullException(nameof(context.Products));

        var product = await context.Products.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));

        var mappedProduct = mapper.Map<ProductViewModel>(product);

        return mappedProduct;
    }
}
