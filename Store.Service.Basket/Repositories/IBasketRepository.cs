using Store.Service.Basket.Entities;

namespace Store.Service.Basket.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<Entities.Basket> GetBasketById(Guid basketId);

        void AddBasket(Entities.Basket basket);

        Task<bool> SaveChanges();

        Task ClearBasket(Guid basketId);
    }
}