﻿using System;

namespace EventTicket.Services.ShoppingBasket.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
