using AutoMapper;

namespace Store.Service.Basket.Profiles
{
    public class BasketLineProfile : Profile
    {
        public BasketLineProfile()
        {
            CreateMap<Models.BasketLineForCreation, Entities.BasketLine>();
            CreateMap<Models.BasketLineForUpdate, Entities.BasketLine>();
            CreateMap<Entities.BasketLine, Models.BasketLine>().ReverseMap();

        }
    }
}
