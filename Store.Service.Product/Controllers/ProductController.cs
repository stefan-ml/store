using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Product.Repositories;

namespace Store.Service.Product.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProductDto>>> Get([FromQuery] Guid productId)
        {
            var result = await productRepository.GetProducts(productId);
            return Ok(mapper.Map<List<Models.ProductDto>>(result));
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Models.ProductDto>> GetById(Guid productId)
        {
            var result = await productRepository.GetProductById(productId);
            return Ok(mapper.Map<Models.ProductDto>(result));
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Models.ProductDto>>> GetProductsByIds([FromQuery(Name = "productIds")] string idList)
        {
            List<Guid> eventIds = idList.Split(',').Select(id => Guid.Parse(id)).ToList();
            var events = await productRepository.GetProductsByIds(eventIds);
            return Ok(mapper.Map<List<Models.ProductDto>>(events));
        }

        [HttpGet("productsFilter")]
        public async Task<ActionResult<List<Models.ProductDto>>> GetProductsByIds([FromQuery] Guid productId)
        {
            var result = await productRepository.GetProducts(productId);
            return Ok(mapper.Map<List<Models.ProductDto>>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Models.ProductDto>> CreateProduct([FromBody] Models.ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                {
                    return BadRequest("Invalid product data.");
                }

                var createdProduct = await productRepository.AddProductAsync(mapper.Map<Entities.Product>(productDto));

                if (createdProduct == null)
                {
                    return StatusCode(500, "Failed to create the product.");
                }

                var createdProductDto = mapper.Map<Models.ProductDto>(createdProduct);
                return CreatedAtAction(nameof(GetById), new { productId = createdProductDto.ProductId }, createdProductDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
