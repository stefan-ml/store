using Store.Service.Basket.Entities;
using Store.Service.Basket.Extensions;
using Store.Service.Basket.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Service.Basket.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly HttpClient client;

        public ProductCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var response = await client.GetAsync($"/api/products/{id}");
            return await response.ReadContentAs<Product>();
        }
    }
}
