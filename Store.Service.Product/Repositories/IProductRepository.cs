using Microsoft.Extensions.Logging;

namespace Store.Service.Product.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts(Guid productId);
        Task<Entities.Product> GetProductById(Guid productId);
        Task<List<Entities.Product>> GetProductsByIds(List<Guid> productIds);
        Task<Entities.Product> AddProductAsync(Entities.Product newProduct);
    }
}
