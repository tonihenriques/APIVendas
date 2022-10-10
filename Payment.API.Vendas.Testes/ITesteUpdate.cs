using Moq;
using Payment.API.Vendas.Data.ValueObject;
using System.Collections.Generic;
using Xunit;
using TstVendas = Payment.API.Vendas;

namespace Payment.API.Vendas.Testes
{
    public class ITesteUpdate
    {
        private TstVendas.Repository.IOrderVendastRepository _OrderVendas;
        private Mock<TstVendas.Repository.IOrderVendastRepository> _mockVenda;       
        private string Status;
       
        List<OrderVendasVO> orderVendasVO = new List<OrderVendasVO>();
        OrderVendasVO _orderVO = new OrderVendasVO();
       
        
        public ITesteUpdate()
        {
            Status = "Pagamento Aprovado";            
            _mockVenda = new Mock<TstVendas.Repository.IOrderVendastRepository>();
            _mockVenda.Setup(m => m.Update(_orderVO, Status)).Returns(true);          
            _OrderVendas = _mockVenda.Object;
           
        }       

        [Fact]
        public void TesteCreate()
        {                     
            Assert.True(_OrderVendas.Update(_orderVO, Status));
        }
        [Fact]
        public void TesteParametroNaoPermitido()
        {
            Status = "Entregue";
            Assert.False(_OrderVendas.Update(_orderVO, Status));
        }

        [Fact]
        public void TesteParametroErrado()
        {
            Status = "Não Aprovado";           
            Assert.False(_OrderVendas.Update(_orderVO, Status));
        }
    }
}
