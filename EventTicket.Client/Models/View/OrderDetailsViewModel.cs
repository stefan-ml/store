using EventTicket.Web.Models.Api;
using System.Collections.Generic;

namespace EventTicket.Web.Models.View
{
    public class OrderDetailsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
    }
}
