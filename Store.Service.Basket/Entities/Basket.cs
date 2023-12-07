using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Service.Basket.Entities
{
    public class Basket
    {
        [Required]
        public Guid BasketId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Collection<BasketLine> BasketLines { get; set; }

        public Guid? CouponId { get; set; }
    }
}
