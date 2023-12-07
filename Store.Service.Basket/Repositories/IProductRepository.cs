

namespace Store.Service.Basket.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Entities.Product theProduct);
        Task<bool> ProductExists(Guid productId);
        Task<bool> SaveChanges();
    }
}