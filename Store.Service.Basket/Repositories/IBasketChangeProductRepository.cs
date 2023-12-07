
namespace Store.Service.Basket.Repositories
{
    public interface IBasketChangeProductRepository
    {
        Task AddBasketProduct(Entities.BasketChangeProduct basketChangeProduct);
        Task<List<Entities.BasketChangeProduct>> GetBasketChangeProducts(DateTime startDate, int max);
    }
}
