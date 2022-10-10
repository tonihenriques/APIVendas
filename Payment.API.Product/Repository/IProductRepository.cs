using Payment.API.Product.Data.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Product.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductVO> FindAll();
        ProductVO FindById(long id);
        Task<ProductVO> FindProdId(long id);
        ProductVO Create(ProductVO vo);
        ProductVO Update(ProductVO vo);
        bool Delete(long id);
    }
}
