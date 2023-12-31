using AutoMapper;
using EventTicket.Services.ShoppingBasket.Messages;
using EventTicket.Services.ShoppingBasket.Models;

namespace EventTicket.Services.ShoppingBasket.Profiles
{
    public class BasketCheckoutProfile: Profile
    {
        public BasketCheckoutProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutMessage>().ReverseMap();
        }
    }
}
