using Moq;
using Payment.API.Vendas.Data.ValueObject;
using System.Collections.Generic;
using Xunit;
using TstVendas = Payment.API.Vendas;

namespace Payment.API.Vendas.Testes
{
    public class ITesteFindAll
    {
        private TstVendas.Repository.IOrderVendastRepository _OrderVendas;
        private Mock<TstVendas.Repository.IOrderVendastRepository> _mockVenda;
        List<OrderVendasVO> orderVendasVO = new List<OrderVendasVO>();

        OrderVendasVO _orderVO = new OrderVendasVO();       

        public ITesteFindAll()
        {
            _mockVenda = new Mock<TstVendas.Repository.IOrderVendastRepository>();
            _mockVenda.Setup(m => m.FindAll()).Returns(orderVendasVO);
            _OrderVendas = _mockVenda.Object;

        }

        [Fact]
        public void TesteFindAll()
        {
            Assert.Equal(orderVendasVO, _OrderVendas.FindAll());
        }

    }
}
