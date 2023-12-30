using EventTicket.Frontend.Client.Models.Api;
using System.Collections.Generic;

namespace EventTicket.Frontend.Client.Models.View
{
    public class OrderDetailsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
    }
}
