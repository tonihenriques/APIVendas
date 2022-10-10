using Moq;
using Payment.API.Empregado.Data.ValueObjects;
using Payment.API.Empregado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TstFuncionario = Payment.API.Empregado;

namespace Payment.API.Empregado.Testes
{
    public class ITesteCreate
    {

        private TstFuncionario.Repository.IFuncionarioRepository _funcionario;

        private Mock<TstFuncionario.Repository.IFuncionarioRepository> _mockFunc;

        List<FuncionarioVO> FuncionarioVO = new List<FuncionarioVO>();

        FuncionarioVO _funcionarioVO = new FuncionarioVO();
       

        public ITesteCreate()
        {
            _mockFunc = new Mock<TstFuncionario.Repository.IFuncionarioRepository>();
            _mockFunc.Setup(m => m.Create(_funcionarioVO)).Returns(_funcionarioVO);
            _funcionario = _mockFunc.Object;

        }

        [Fact]
        public void TesteCreate()
        {
            Assert.Equal(_funcionarioVO, _funcionario.Create(_funcionarioVO));
        }
    }
}
