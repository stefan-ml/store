using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Service.Product.DbContexts;

namespace Store.Service.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogDbContext _productCatalogDbContext;

        public ProductRepository(ProductCatalogDbContext productCatalogDbContext)
        {
            _productCatalogDbContext = productCatalogDbContext;
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts(Guid productId)
        {
            return await _productCatalogDbContext.Products
                .Where(x => (x.ProductId == productId || productId == Guid.Empty)).ToListAsync();
        }

        public async Task<Entities.Product> GetProductById(Guid productId)
        {
            return await _productCatalogDbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<List<Entities.Product>> GetProductsByIds(List<Guid> productIds)
        {
            return await _productCatalogDbContext.Products
                .Where(x => productIds.Contains(x.ProductId))
            .ToListAsync();
        }

        public async Task<Entities.Product> AddProductAsync(Entities.Product newProduct)
        {
            try
            {
                if (newProduct == null)
                {
                    return null;
                }
                _productCatalogDbContext.Products.Add(newProduct);
                await _productCatalogDbContext.SaveChangesAsync();

                return newProduct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
