using Microsoft.EntityFrameworkCore;
using Store.Service.Basket.DbContexts;

namespace Store.Service.Basket.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext basketDbContext;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            this.basketDbContext = basketDbContext;
        }

        public async Task<Entities.Basket> GetBasketById(Guid basketId)
        {
            return await basketDbContext.Baskets.Include(sb => sb.BasketLines)
                .Where(b => b.BasketId == basketId).FirstOrDefaultAsync();
        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            return await basketDbContext.Baskets
                .AnyAsync(b => b.BasketId == basketId);
        }

        public async Task ClearBasket(Guid basketId)
        {
            var basketLinesToClear = basketDbContext.BasketLines.Where(b => b.BasketId == basketId);
            /*basketDbContext.BasketLines.RemoveRange(basketLinesToClear);*/

            var basket = basketDbContext.Baskets.FirstOrDefault(b => b.BasketId == basketId);
            if (basket != null) basket.CouponId = null;

            await SaveChanges();
        }

        public void AddBasket(Entities.Basket basket)
        {
            basketDbContext.Baskets.Add(basket);
        }

        public async Task<bool> SaveChanges()
        {
            return (await basketDbContext.SaveChangesAsync() > 0);
        }
    }
}
