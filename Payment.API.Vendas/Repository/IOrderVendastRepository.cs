using Payment.API.Vendas.Data.ValueObject;
using Payment.API.Vendas.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Vendas.Repository
{
    public interface IOrderVendastRepository
    {
        IEnumerable<OrderVendasVO> FindAll();
        OrderVendasVO FindById(long id);
        OrderVendasVO Create(OrderVendasVO vo);
        string atualiza(OrderVendas vo, string status);
        bool Update(OrderVendasVO vo, string status);
        bool Delete(long id);
        
    }
}
