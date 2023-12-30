using EventTicket.Frontend.Client.Models.Api;
using System;
using System.Collections.Generic;

namespace EventTicket.Frontend.Client.Models.View
{
    public class EventListModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public string SelectedEventDate { get; set; }
        public string SelectedEventCity { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}
