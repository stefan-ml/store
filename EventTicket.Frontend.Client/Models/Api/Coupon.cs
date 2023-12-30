using System;

namespace EventTicket.Frontend.Client.Models.Api
{
    public class Coupon
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}
