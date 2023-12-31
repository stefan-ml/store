using System.ComponentModel.DataAnnotations;

namespace EventTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
