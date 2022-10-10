using Moq;
using Payment.API.Product.Data.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TstProduct = Payment.API.Product;

namespace Payment.API.Product.Testes
{
    public class ITesteUpdate
    {
        private TstProduct.Repository.IProductRepository _Product;
        private Mock<TstProduct.Repository.IProductRepository> _mockProd;
        List<ProductVO> productVOs = new List<ProductVO>();

        ProductVO _productVO = new ProductVO();
       
        public ITesteUpdate()
        {
            _mockProd = new Mock<TstProduct.Repository.IProductRepository>();
            _mockProd.Setup(m => m.Update(_productVO)).Returns(_productVO);           
            _Product = _mockProd.Object;

        }

        [Fact]
        public void TesteUpdate()
        {
            Assert.Equal(_productVO, _Product.Update(_productVO));
        }
    }
}
