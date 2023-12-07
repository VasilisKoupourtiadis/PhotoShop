using AutoMapper;
using PhotoShop.Models.Domain;
using PhotoShop.Models.ViewModels;

namespace PhotoShop.Helpers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Product, ProductViewModel>().ReverseMap();
    }
}
