using Auctria.EcommerceStore.Core.Application.Carts;
using Auctria.EcommerceStore.Core.Application.Products;
using AutoMapper;

namespace Auctria.EcommerceStore.Core.Application;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCartItemCommand, CartItem>().ReverseMap();
        CreateMap<CreateCartCommand, Cart>().ReverseMap();
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<Product, ProductVm>().ReverseMap();
        CreateMap<Cart, CartVm>().ReverseMap();
    }
}
