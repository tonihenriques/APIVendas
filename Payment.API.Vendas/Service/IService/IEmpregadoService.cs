using Payment.API.Vendas.Data.ValueObject;
using Payment.API.Vendas.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Vendas.Service.IService
{
    public interface IEmpregadoService
    {
        //Task<IEnumerable<FuncionarioVO>> FindAllProducts(string token);
        Task<FuncionarioVO> FindEmpregadoById(long id);
        //Task<FuncionarioVO> CreateProduct(FuncionarioVO model, string token);
        //Task<FuncionarioVO> UpdateProduct(FuncionarioVO model, string token);
        //Task<bool> DeleteProductById(long id, string token);
    }
}
