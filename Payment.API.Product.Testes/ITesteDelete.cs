using Moq;
using Payment.API.Product.Data.ValueObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TstProduct = Payment.API.Product;

namespace Payment.API.Product.Testes
{
    public class ITesteDelete
    {
        private TstProduct.Repository.IProductRepository _Product;
        private Mock<TstProduct.Repository.IProductRepository> _mockProd;
        List<ProductVO> productVOs = new List<ProductVO>();

        ProductVO _productVO = new ProductVO();
       

        public ITesteDelete()
        {
            long id = 1;
            bool valor = true;
            _mockProd = new Mock<TstProduct.Repository.IProductRepository>();
            _mockProd.Setup(m => m.Delete(id)).Returns(valor);
            _Product = _mockProd.Object;

        }

        [Fact]
        public void Delete()
        {
            bool valor = true;
            long Id = 1;
            Assert.Equal(valor, _Product.Delete(Id));
        }
    }
}
