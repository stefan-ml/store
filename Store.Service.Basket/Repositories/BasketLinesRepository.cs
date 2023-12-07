using Store.Service.Basket.DbContexts;
using Store.Service.Basket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Service.Basket.Repositories
{
    public class BasketLinesRepository : IBasketLinesRepository
    {
        private readonly BasketDbContext basketDbContext;

        public BasketLinesRepository(BasketDbContext basketDbContext)
        {
            this.basketDbContext = basketDbContext;
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await basketDbContext.BasketLines.Include(bl => bl.Product)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await basketDbContext.BasketLines.Include(bl => bl.Product)
                .Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await basketDbContext.BasketLines.Include(bl => bl.Product)
                .Where(b => b.BasketId == basketId && b.ProductId == basketLine.ProductId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                    basketDbContext.BasketLines.Add(basketLine);
                return basketLine;
            }
            existingLine.ProductAmount += basketLine.ProductAmount;
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            // empty on purpose
        }
        
        public void RemoveBasketLine(BasketLine basketLine)
        {
            basketDbContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await basketDbContext.SaveChangesAsync() > 0);
        }
    }
}
