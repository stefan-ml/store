using EventTicket.Web.Models.Api;

namespace EventTicket.Web.Models.View
{
    public class EventViewModel : Event
    {
        public int NumberOfItems { get; set; }
    }
}
