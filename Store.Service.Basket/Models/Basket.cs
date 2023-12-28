﻿namespace Store.Service.Basket.Models
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
        public Guid? CouponId { get; set; }
    }
}