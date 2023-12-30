using EventTicket.Frontend.Client.Models;
using EventTicket.Frontend.Client.Models.View;
using EventTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Frontend.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly Settings settings;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly IEventCatalogService eventCatalogService;

        public OrderController(Settings settings, IOrderService orderService, IShoppingBasketService shoppingBasketService, IEventCatalogService eventCatalogService)
        {
            this.settings = settings;
            this.orderService = orderService;
            this.shoppingBasketService = shoppingBasketService;
            this.eventCatalogService = eventCatalogService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetOrdersForUser(settings.UserId);

            return View(new OrderViewModel { Orders = orders });
        }

        public async Task<IActionResult> Detail(Guid basketId)
        {
            var basketLines = await shoppingBasketService.GetLinesForBasket(basketId);
            if (basketLines.Count() > 0)
            {
                var events = await eventCatalogService.GetEvents(basketLines.Select(bl => bl.EventId).ToList());
                return View(new OrderDetailsViewModel { Events = events } );
            }
            return View(new OrderDetailsViewModel { Events = Enumerable.Empty<Models.Api.Event>() });
        }
    }
}
