﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EventTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForCreation
    { 
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
