using AutoMapper;
using EventTicket.Services.ShoppingBasket.Entities;
using EventTicket.Services.ShoppingBasket.Models;

namespace EventTicket.Services.ShoppingBasket.Profiles
{
    public class BasketChangeEventProfile: Profile
    {
        public BasketChangeEventProfile()
        {
            CreateMap<BasketChangeEvent, BasketChangeEventForPublication>().ReverseMap();
        }
    }
}
