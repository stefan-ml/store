using AutoMapper;

namespace Store.Service.Basket.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Models.BasketForCreation, Entities.Basket>();
            CreateMap<Entities.Basket, Models.Basket>().ReverseMap();
        }
    }
}
