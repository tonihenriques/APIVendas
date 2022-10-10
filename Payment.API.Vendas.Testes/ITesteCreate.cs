using Castle.Components.DictionaryAdapter.Xml;
using Moq;
using Payment.API.Vendas.Data.ValueObject;
using System;
using System.Collections.Generic;
using Xunit;
using TstVendas = Payment.API.Vendas;

namespace Payment.API.Vendas.Testes
{
    public class ITesteCreate
    {
        private TstVendas.Repository.IOrderVendastRepository _OrderVendas;
        private Mock<TstVendas.Repository.IOrderVendastRepository> _mockVenda;
        List<OrderVendasVO> orderVendasVO = new List<OrderVendasVO>();

        OrderVendasVO _orderVO = new OrderVendasVO();
        

        public ITesteCreate()
        {
            _mockVenda = new Mock<TstVendas.Repository.IOrderVendastRepository>();
            _mockVenda.Setup(m => m.Create(_orderVO)).Returns(_orderVO);
            _OrderVendas = _mockVenda.Object;

        }

        [Fact]
        public void TesteCreate()
        {
            Assert.Equal(_orderVO, _OrderVendas.Create(_orderVO));

            
        }

       
    }
}
