using EventTicket.Services.EventCatalog.DbContexts;
using EventTicket.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventTicket.Services.EventCatalog.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Event>> GetEvents(Guid categoryId)
        {
            return await _eventCatalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => (x.CategoryId == categoryId || categoryId == Guid.Empty)).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents(Guid categoryId, string date, string city)
        {
            DateTime? eventDate = null;
            if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out var parsedDate))
            {
                eventDate = parsedDate.Date;
            }

            var query = _eventCatalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => (categoryId == Guid.Empty || x.CategoryId == categoryId)
                            && (string.IsNullOrEmpty(city) || x.City.ToLower().Contains(city.ToLower()))
                            && (eventDate == null || EF.Functions.DateDiffDay(x.Date, eventDate) == 0));

            return await query.ToListAsync();
        }

        public async Task<Event> GetEventById(Guid eventId)
        {
            return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => x.EventId == eventId).FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetEventsByIds(List<Guid> eventIds)
        {
            return await _eventCatalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => eventIds.Contains(x.EventId))
                .ToListAsync();
        }

        public async Task<Event> AddEventAsync(Event newEvent)
        {
            try
            {
                if (newEvent == null)
                {
                    return null;
                }
                newEvent.Category = null;
                _eventCatalogDbContext.Events.Add(newEvent);
                await _eventCatalogDbContext.SaveChangesAsync();

                return newEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteEventAsync(Guid eventId)
        {
            try
            {
                var eventToDelete = await _eventCatalogDbContext.Events.FindAsync(eventId);

                if (eventToDelete == null)
                {
                    return false;
                }

                _eventCatalogDbContext.Events.Remove(eventToDelete);
                await _eventCatalogDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
