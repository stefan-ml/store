using System;
using System.Threading.Tasks;

namespace Store.Service.Basket.Services
{
    public interface IProductCatalogService
    {
        Task<Entities.Product> GetProduct(Guid id);
    }
}