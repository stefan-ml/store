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
    public class EventCreateController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCreateController(IEventCatalogService eventCatalogService, IShoppingBasketService shoppingBasketService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var getCategories = eventCatalogService.GetCategories();

            var getEvents = eventCatalogService.GetAll(); 

            await Task.WhenAll(new Task[] { getCategories, getEvents });

            return View(
                new EventCreateViewModel()
                {
                    Events = getEvents.Result,
                    CategoryList = getCategories.Result
                }
            ); 
        }

        public IActionResult Create(EventCreateViewModel model)
        {
            if(model.CategoryId != null)
            {
                var getCategories = eventCatalogService.GetCategories();
                model.CategoryName = getCategories.Result.
                    Where(it => it.CategoryId == model.CategoryId).FirstOrDefault().Name;
            }
            if (ModelState.IsValid)
            {
                var newEvent = new Event
                {
                    Name = model.Name,
                    Price = model.Price,
                    Artist = model.Artist,
                    Date = model.Date,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    City = model.City
                };

                eventCatalogService.CreateEvent(newEvent);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid eventId)
        {

            return RedirectToAction("Index"); 
        }
    }
}
