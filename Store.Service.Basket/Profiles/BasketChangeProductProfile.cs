using AutoMapper;
using Store.Service.Basket.Entities;
using Store.Service.Basket.Models;

namespace Store.Service.Basket.Profiles
{
    public class BasketChangeProductProfile: Profile
    {
        public BasketChangeProductProfile()
        {
            CreateMap<BasketChangeProduct, BasketChangeProductForPublication>().ReverseMap();
        }
    }
}
