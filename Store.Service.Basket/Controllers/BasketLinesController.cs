using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Basket.Entities;
using Store.Service.Basket.Models;
using Store.Service.Basket.Repositories;
using Store.Service.Basket.Services;

namespace Store.Service.Basket.Controllers
{

    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IBasketLinesRepository basketLinesRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductCatalogService productCatalogService;
        private readonly IMapper mapper;
        private readonly IBasketChangeProductRepository basketChangeProductRepository;

        public BasketLinesController(IBasketRepository basketRepository,
            IBasketLinesRepository basketLinesRepository, IProductRepository productRepository,
            IProductCatalogService productCatalogService, IMapper mapper, IBasketChangeProductRepository basketChangeProductRepository)
        {
            this.basketRepository = basketRepository;
            this.basketLinesRepository = basketLinesRepository;
            this.productRepository = productRepository;
            this.productCatalogService = productCatalogService;
            this.basketChangeProductRepository = basketChangeProductRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.BasketLine>>> Get(Guid basketId)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLines = await basketLinesRepository.GetBasketLines(basketId);
            return Ok(mapper.Map<IEnumerable<Models.BasketLine>>(basketLines));
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<Models.BasketLine>> Get(Guid basketId,
            Guid basketLineId)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLine = await basketLinesRepository.GetBasketLineById(basketLineId);
            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.BasketLine>(basketLine));
        }

        [HttpPost]
        public async Task<ActionResult<Models.BasketLine>> Post(Guid basketId, [FromBody] BasketLineForCreation basketLineForCreation)
        {
            var basket = await basketRepository.GetBasketById(basketId);

            if (basket == null)
            {
                return NotFound();
            }

            if (!await productRepository.ProductExists(basketLineForCreation.ProductId))
            {
                var productFromCatalog = await productCatalogService.GetProduct(basketLineForCreation.ProductId);
                productRepository.AddProduct(productFromCatalog);
                await productRepository.SaveChanges();
            }

            var basketLineEntity = mapper.Map<Entities.BasketLine>(basketLineForCreation);

            var processedBasketLine = await basketLinesRepository.AddOrUpdateBasketLine(basketId, basketLineEntity);
            await basketLinesRepository.SaveChanges();

            var basketLineToReturn = mapper.Map<Models.BasketLine>(processedBasketLine);

            //log also to the product repo
            BasketChangeProduct basketChangeProduct = new BasketChangeProduct
            {
                BasketChangeType = BasketChangeTypeEnum.Add,
                ProductId = basketLineForCreation.ProductId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await basketChangeProductRepository.AddBasketProduct(basketChangeProduct);

            return CreatedAtRoute(
                "GetBasketLine",
                new { basketId = basketLineEntity.BasketId, basketLineId = basketLineEntity.BasketLineId },
                basketLineToReturn);
        }

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<Models.BasketLine>> Put(Guid basketId,
            Guid basketLineId,
            [FromBody] BasketLineForUpdate basketLineForUpdate)
        {
            if (!await basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            // map the entity to a dto
            // apply the updated field values to that dto
            // map the dto back to an entity
            mapper.Map(basketLineForUpdate, basketLineEntity);

            basketLinesRepository.UpdateBasketLine(basketLineEntity);
            await basketLinesRepository.SaveChanges();

            return Ok(mapper.Map<Models.BasketLine>(basketLineEntity));
        }

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId, Guid basketLineId)
        {
            //if (!await basketRepository.BasketExists(basketId))
            //{
            //    return NotFound();
            //}

            var basket = await basketRepository.GetBasketById(basketId);

            if (basket == null)
            {
                return NotFound();
            }

            var basketLineEntity = await basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            basketLinesRepository.RemoveBasketLine(basketLineEntity);
            await basketLinesRepository.SaveChanges();

            //publish removal product
            BasketChangeProduct basketChangeProduct = new BasketChangeProduct
            {
                BasketChangeType = BasketChangeTypeEnum.Remove,
                ProductId = basketLineEntity.ProductId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await basketChangeProductRepository.AddBasketProduct(basketChangeProduct);

            return NoContent();
        }
    }
}
