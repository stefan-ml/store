using Microsoft.Extensions.Logging;

namespace Store.Service.Basket.Models
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Price { get; set; }
        public int ProductAmount { get; set; }
        public Product Product { get; set; }
    }
}
