
using Microsoft.EntityFrameworkCore;
using Store.Service.Basket.Entities;

namespace Store.Service.Basket.DbContexts
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options)
        {
        }

        public DbSet<Entities.Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketChangeProduct> BasketChangeProducts { get; set; }
    }
}
