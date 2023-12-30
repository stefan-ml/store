using System;
using System.ComponentModel.DataAnnotations;

namespace EventTicket.Frontend.Client.Models.Api
{
    public class CouponForUpdate
    {
        [Required]
        public Guid CouponId { get; set; }
    }
}
