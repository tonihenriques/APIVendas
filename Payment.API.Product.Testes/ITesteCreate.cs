using Moq;
using Payment.API.Product.Data.ValueObject;
using System.Collections.Generic;
using Xunit;
using TstProduct = Payment.API.Product;

namespace Payment.API.Product.Testes
{
    public class ITesteCreate
    {
        private TstProduct.Repository.IProductRepository _Product;
        private Mock<TstProduct.Repository.IProductRepository> _mockProd;
        List<ProductVO> productVOs = new List<ProductVO>();

        ProductVO _productVO = new ProductVO();
       
        public ITesteCreate()
        {
            _mockProd = new Mock<TstProduct.Repository.IProductRepository>();
            _mockProd.Setup(m => m.Create(_productVO)).Returns(_productVO);
            _Product = _mockProd.Object;

        }

        [Fact]
        public void TesteCreate()
        {
            Assert.Equal(_productVO, _Product.Create(_productVO));
        }
    }
}
