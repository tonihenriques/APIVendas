using Payment.API.Vendas.Data.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Vendas.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<OrderVendasVO>> FindAllProducts(string token);
        Task<ProductVO> FindProductById(long id);
        Task<OrderVendasVO> CreateProduct(OrderVendasVO model, string token);
        Task<OrderVendasVO> UpdateProduct(OrderVendasVO model, string token);
        Task<bool> DeleteProductById(long id, string token);
    }
}
