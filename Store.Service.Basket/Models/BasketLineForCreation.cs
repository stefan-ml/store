using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Models
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int ProductAmount { get; set; }
    }
}
