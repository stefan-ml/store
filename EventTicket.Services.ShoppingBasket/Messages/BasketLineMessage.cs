﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Services.ShoppingBasket.Messages
{
    public class BasketLineMessage
    {
        public Guid BasketLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}
