using EventTicket.Frontend.Client.Models.Api;
using System.Collections.Generic;

namespace EventTicket.Frontend.Client.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
