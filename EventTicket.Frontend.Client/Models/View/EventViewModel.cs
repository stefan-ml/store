using EventTicket.Frontend.Client.Models.Api;
using System;

namespace EventTicket.Frontend.Client.Models.View
{
    public class EventViewModel : Event
    {
        public int NumberOfItems { get; set; }
    }
}
