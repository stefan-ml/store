﻿using EventTicket.Web.Models.Api;
using System;
using System.Threading.Tasks;

namespace EventTicket.Web.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCouponByCode(string code);
        Task UseCoupon(Guid couponId);
        Task<Coupon> GetCouponById(Guid couponId);
    }
}
