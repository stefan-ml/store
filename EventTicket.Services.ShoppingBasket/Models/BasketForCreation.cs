using System;
using System.ComponentModel.DataAnnotations;

namespace EventTicket.Services.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
