using Moq;
using Payment.API.Empregado.Data.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TstFuncionario = Payment.API.Empregado;

namespace Payment.API.Empregado.Testes
{
    public class ITesteFindAll
    {
        private TstFuncionario.Repository.IFuncionarioRepository _funcionario;

        private Mock<TstFuncionario.Repository.IFuncionarioRepository> _mockFunc;

        List<FuncionarioVO> FuncionarioVOs = new List<FuncionarioVO>();

        FuncionarioVO _funcionarioVO = new FuncionarioVO();
        

        public ITesteFindAll()
        {
            _mockFunc = new Mock<TstFuncionario.Repository.IFuncionarioRepository>();
            _mockFunc.Setup(m => m.FindAll()).Returns(FuncionarioVOs);
            _funcionario = _mockFunc.Object;

        }

        [Fact]
        public void TesteFindAll()
        {
            Assert.Equal(FuncionarioVOs, _funcionario.FindAll());
        }
    }
}
