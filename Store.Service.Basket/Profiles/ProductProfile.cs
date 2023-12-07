using AutoMapper;

namespace Store.Service.Basket.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.Product>().ReverseMap();
        }
    }
}
