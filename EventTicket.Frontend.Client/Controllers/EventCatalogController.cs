using System;
using System.Linq;
using System.Threading.Tasks;
using EventTicket.Frontend.Client.Extensions;
using EventTicket.Frontend.Client.Models;
using EventTicket.Frontend.Client.Models.Api;
using EventTicket.Frontend.Client.Models.View;
using EventTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventTicket.Frontend.Client.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService, IShoppingBasketService shoppingBasketService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryId, string selectedEventDate, string selectedEventCity)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);

            var getBasket = currentBasketId == Guid.Empty ? Task.FromResult<Basket>(null) :
                shoppingBasketService.GetBasket(currentBasketId);

            var getCategories = eventCatalogService.GetCategories();

            var getEvents = //categoryId == Guid.Empty ? eventCatalogService.GetAll() :
                eventCatalogService.GetByFilters(categoryId, selectedEventDate, selectedEventCity);

            await Task.WhenAll(new Task[] { getBasket, getCategories, getEvents });

            var numberOfItems = getBasket.Result?.NumberOfItems ?? 0;

            var filteredEvents = getEvents.Result;
            if (selectedEventDate != null)
            {
                var date = DateTime.Parse(selectedEventDate);
                if (date != default(DateTime))
                {
                    filteredEvents = filteredEvents.Where(item => item.Date.Date.Equals(date.Date));
                }
            }

            if (!String.IsNullOrEmpty(selectedEventCity))
            {
                filteredEvents = filteredEvents.Where(item => item.City.ToLower().Contains(selectedEventCity.ToLower()));
            }


            return View(
                new EventListModel
                {
                    Events = filteredEvents,
                    Categories = getCategories.Result,
                    NumberOfItems = numberOfItems,
                    SelectedCategory = categoryId,
                    SelectedEventCity = selectedEventCity,
                    SelectedEventDate = selectedEventDate
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm]Guid selectedCategory, [FromForm]string selectedEventDate, [FromForm]string selectedEventCity)
        {
            return RedirectToAction("Index", new { 
                categoryId = selectedCategory,
                selectedEventDate = selectedEventDate,
                selectedEventCity
            });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);

            var getBasket = currentBasketId == Guid.Empty ? Task.FromResult<Basket>(null) :
                shoppingBasketService.GetBasket(currentBasketId);

            var ev = eventCatalogService.GetEvent(eventId);

            await Task.WhenAll(new Task[] { getBasket, ev });

            var numberOfItems = getBasket.Result?.NumberOfItems ?? 0;

            return View(new EventViewModel
            {
                EventId = ev.Result.EventId,
                Name = ev.Result.Name,
                Price = ev.Result.Price,
                Artist = ev.Result.Artist,
                Date = ev.Result.Date,
                Description = ev.Result.Description,
                ImageUrl = ev.Result.ImageUrl,
                CategoryId = ev.Result.CategoryId,
                CategoryName = ev.Result.CategoryName,
                NumberOfItems = numberOfItems
            });
        }
    }
}
