using Store.Service.Basket.Entities;

namespace Store.Service.Basket.Models
{
    public class BasketChangeProductForPublication
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public BasketChangeTypeEnum BasketChangeType { get; set; }
    }
}
