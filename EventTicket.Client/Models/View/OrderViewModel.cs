using EventTicket.Web.Models.Api;
using System.Collections.Generic;

namespace EventTicket.Web.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
