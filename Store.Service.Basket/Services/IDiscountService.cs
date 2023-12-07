using Store.Service.Basket.Models;
using System;
using System.Threading.Tasks;

namespace Store.Service.Basket.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCoupon(Guid couponId);
        Task<Coupon> GetCouponWithError(Guid couponId);
    }
}
