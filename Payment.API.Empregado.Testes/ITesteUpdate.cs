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
    public class ITesteUpdate
    {
        private TstFuncionario.Repository.IFuncionarioRepository _funcionario;

        private Mock<TstFuncionario.Repository.IFuncionarioRepository> _mockFunc;

        List<FuncionarioVO> FuncionarioVO = new List<FuncionarioVO>();

        FuncionarioVO _funcionarioVO = new FuncionarioVO();
        

        public ITesteUpdate()
        {
            _mockFunc = new Mock<TstFuncionario.Repository.IFuncionarioRepository>();
            _mockFunc.Setup(m => m.Update(_funcionarioVO)).Returns(_funcionarioVO);
            _funcionario = _mockFunc.Object;
        }

        [Fact]
        public void TesteUpdate()
        {
            Assert.Equal(_funcionarioVO, _funcionario.Update(_funcionarioVO));
        }
    }
}
