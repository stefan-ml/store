using EventTicket.Web.Extensions;
using EventTicket.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventTicket.Web.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await client.GetAsync("/api/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid)
        {
            var response = await client.GetAsync($"/api/events/?categoryId={categoryid}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByFilters(Guid categoryId, string date, string city)
        {
            var queryString = $"?categoryId={categoryId}";
            queryString += $"&date={Uri.EscapeDataString(date ?? "")}";
            queryString += $"&city={Uri.EscapeDataString(city ?? "")}";

            var response = await client.GetAsync($"/api/events/eventsFilter{queryString}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<List<Event>> GetEvents(List<Guid> eventIds)
        {
            var idList = string.Join(",", eventIds.Select(id => id.ToString()));
            var response = await client.GetAsync($"/api/events/events?eventIds={idList}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await client.GetAsync("/api/categories");
            return await response.ReadContentAs<List<Category>>();
        }

        public async Task<Event> CreateEvent(Event eventDto)
        {
            try
            {
                var response = await client.PostAsJson("/api/events", eventDto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.ReadContentAs<Event>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
