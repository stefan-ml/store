using EventTicket.Services.ShoppingBasket.Entities;

namespace EventTicket.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}