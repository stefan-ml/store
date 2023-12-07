using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
