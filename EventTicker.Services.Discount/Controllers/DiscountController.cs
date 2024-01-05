﻿using AutoMapper;
using EventTicker.Services.Discount.Models;
using EventTicker.Services.Discount.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventTicker.Services.Discount.Controllers
{
    [Route("api/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public DiscountController(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetDiscountForCode(string code)
        {
            var coupon = await _couponRepository.GetCouponByCode(code);

            if (coupon == null)
                return NotFound();

            return Ok(_mapper.Map<CouponDto>(coupon));
        }

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountForCode(Guid couponId)
        {

            var coupon = await _couponRepository.GetCouponById(couponId);

            if (coupon == null)
                return NotFound();

            return Ok(_mapper.Map<CouponDto>(coupon));
        }

        [HttpPut("use/{couponId}")]
        public async Task<IActionResult> UseCoupon(Guid couponId)
        {
            await _couponRepository.UseCoupon(couponId);
            return Ok();
        }
    }
}
