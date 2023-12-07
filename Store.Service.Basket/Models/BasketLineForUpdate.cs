using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
