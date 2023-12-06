using AutoMapper;

namespace Store.Service.Product.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() { 
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductDto, Entities.Product>();
        }
    }
}
