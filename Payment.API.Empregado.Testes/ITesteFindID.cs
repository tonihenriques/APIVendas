using Moq;
using Payment.API.Empregado.Data.ValueObjects;
using System.Collections.Generic;
using Xunit;
using TstFuncionario = Payment.API.Empregado;

namespace Payment.API.Empregado.Testes
{
    public class ITesteFindID
    {
        private TstFuncionario.Repository.IFuncionarioRepository _funcionario;

        private Mock<TstFuncionario.Repository.IFuncionarioRepository> _mockFunc;

        List<FuncionarioVO> FuncionarioVOs = new List<FuncionarioVO>();

        FuncionarioVO _funcionarioVO = new FuncionarioVO();
        

        public ITesteFindID()
        {
            long id = 1;
            _mockFunc = new Mock<TstFuncionario.Repository.IFuncionarioRepository>();
            _mockFunc.Setup(m => m.FindById(id)).Returns(_funcionarioVO);
            _funcionario = _mockFunc.Object;
        }

        [Fact]
        public void FindById()
        {
            long Id = 1;
            Assert.Equal(_funcionarioVO, _funcionario.FindById(Id));
        }
    }
}
