using Payment.API.Vendas.Data.ValueObject;
using Payment.API.Vendas.Service.IService;
using Payment.API.Vendas.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payment.API.Vendas.Service.ServiceConcrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<OrderVendasVO> CreateProduct(OrderVendasVO model, string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProductById(long id, string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<OrderVendasVO>> FindAllProducts(string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductVO> FindProductById(long prodID)
        {
            var response = await _client.GetAsync($"{BasePath}/regist-venda/{prodID}");
            return await response.ReadContentAs<ProductVO>();
        }

        public Task<OrderVendasVO> UpdateProduct(OrderVendasVO model, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
