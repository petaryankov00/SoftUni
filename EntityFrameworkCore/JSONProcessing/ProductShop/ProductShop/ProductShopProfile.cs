using AutoMapper;
using ProductShop.Models;
using ProductShop.ModelsDTO;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();
            this.CreateMap<ProductInputDto, Product>();
            this.CreateMap<CategoryInputDto, Category>();
            this.CreateMap<CategoryProductsInputDto, CategoryProduct>();
            this.CreateMap<User, UsersOutputModelDto>();
                
        }
    }
}
