using Store.Service.Basket.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
