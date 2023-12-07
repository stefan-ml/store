using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Basket.Models;
using Store.Service.Basket.Repositories;

namespace Store.Service.Basket.Controllers
{

    [ApiController]
    [Route("api/basketproduct")]
    public class BasketChangeProductController : Controller
    {
        private readonly IBasketChangeProductRepository basketChangeProductRepository;
        private readonly IMapper mapper;

        public BasketChangeProductController(IMapper mapper, IBasketChangeProductRepository basketChangeProductRepository)
        {
            this.mapper = mapper;
            this.basketChangeProductRepository = basketChangeProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] DateTime fromDate, [FromQuery] int max)
        {
            var products = await basketChangeProductRepository.GetBasketChangeProducts(fromDate, max);
            return Ok(mapper.Map<List<BasketChangeProductForPublication>>(products));
        }
    }
}
