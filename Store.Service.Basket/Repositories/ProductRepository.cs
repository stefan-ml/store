using Microsoft.EntityFrameworkCore;
using Store.Service.Basket.DbContexts;

namespace Store.Service.Basket.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BasketDbContext basketDbContext;

        public ProductRepository(BasketDbContext basketDbContext)
        {
            this.basketDbContext = basketDbContext;
        }

        public async Task<bool> ProductExists(Guid productId)
        {
            return await basketDbContext.Products.AnyAsync(e => e.ProductId == productId);
        }

        public void AddProduct(Entities.Product theProduct)
        {
            basketDbContext.Products.Add(theProduct);

        }

        public async Task<bool> SaveChanges()
        {
            return (await basketDbContext.SaveChangesAsync() > 0);
        }
    }
}
