using EventTicket.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace EventTicket.Services.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}