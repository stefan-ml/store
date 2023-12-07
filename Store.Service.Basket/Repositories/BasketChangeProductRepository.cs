using Microsoft.EntityFrameworkCore;
using Store.Service.Basket.DbContexts;

namespace Store.Service.Basket.Repositories
{
    public class BasketChangeProductRepository: IBasketChangeProductRepository
    {
        private readonly BasketDbContext basketDbContext;

        public BasketChangeProductRepository(BasketDbContext basketDbContext)
        {
            this.basketDbContext = basketDbContext;
        }

        public async Task AddBasketProduct(Entities.BasketChangeProduct basketChangeProduct)
        {
            await basketDbContext.BasketChangeProducts.AddAsync(basketChangeProduct);
            await basketDbContext.SaveChangesAsync();
        }

        public async Task<List<Entities.BasketChangeProduct>> GetBasketChangeProducts(DateTime startDate, int max)
        {
            return await basketDbContext.BasketChangeProducts.Where(b => b.InsertedAt > startDate)
                .OrderBy(b => b.InsertedAt).Take(max).ToListAsync();
        }
    }
}
