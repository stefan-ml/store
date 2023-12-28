using AutoMapper;

namespace EventTicket.Services.EventCatalog.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, Models.EventDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<Models.EventDto, Entities.Event>()
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => new Entities.Category
                {
                    Name = src.CategoryName,
                    CategoryId = src.CategoryId
                }));
        }
    }
}