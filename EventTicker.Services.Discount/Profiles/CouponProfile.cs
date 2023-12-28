using AutoMapper;
using EventTicker.Services.Discount.Entities;
using EventTicker.Services.Discount.Models;

namespace EventTicker.Services.Discount.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
