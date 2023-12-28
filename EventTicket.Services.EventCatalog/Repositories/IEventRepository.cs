using EventTicket.Services.EventCatalog.Entities;

namespace EventTicket.Services.EventCatalog.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(Guid categoryId, string date, string city);
        Task<IEnumerable<Event>> GetEvents(Guid categoryId);
        Task<Event> GetEventById(Guid eventId);
        Task<List<Event>> GetEventsByIds(List<Guid> eventIds);
        Task<Event> AddEventAsync(Event newEvent);
        Task<bool> DeleteEventAsync(Guid eventId);
    }
}
