using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Basket.Models;
using Store.Service.Basket.Repositories;

namespace Store.Service.Basket.Controllers
{

    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {

        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketsController(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        [HttpGet("{basketId}", Name = "GetBasket")]
        public async Task<ActionResult<Models.Basket>> Get(Guid basketId)
        {
            var basket = await basketRepository.GetBasketById(basketId);
            if (basket == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Models.Basket>(basket);
            result.NumberOfItems = basket.BasketLines.Sum(bl => bl.ProductAmount);
            return Ok(result);
        }
    }
}
