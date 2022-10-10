using Moq;
using Payment.API.Product.Data.ValueObject;
using System.Collections.Generic;
using Xunit;
using TstProduct = Payment.API.Product;

namespace Payment.API.Product.Testes
{
    public class ITesteFindAll
    {
        private TstProduct.Repository.IProductRepository _Product;
        private Mock<TstProduct.Repository.IProductRepository> _mockProd;
        List<ProductVO> productVOs = new List<ProductVO>();

        ProductVO _productVO = new ProductVO();
      
        public ITesteFindAll()
        {
            _mockProd = new Mock<TstProduct.Repository.IProductRepository>();
            _mockProd.Setup(m => m.FindAll()).Returns(productVOs);
            _Product = _mockProd.Object;

        }

        [Fact]
        public void TesteFindAll()
        {
            Assert.Equal(productVOs, _Product.FindAll());
        }
    }
}
