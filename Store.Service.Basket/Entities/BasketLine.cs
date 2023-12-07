using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }

        [Required]
        public Guid BasketId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int ProductAmount { get; set; }

        [Required]
        public int Price { get; set; }

        public Basket Basket { get; set; }
    }
}
