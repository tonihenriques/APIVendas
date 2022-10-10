using Moq;
using Payment.API.Empregado.Data.ValueObjects;
using System.Collections.Generic;
using Xunit;
using TstFuncionario = Payment.API.Empregado;

namespace Payment.API.Empregado.Testes
{
    public class ITesteDelete
    {

        private TstFuncionario.Repository.IFuncionarioRepository _funcionario;

        private Mock<TstFuncionario.Repository.IFuncionarioRepository> _mockFunc;

        List<FuncionarioVO> FuncionarioVO = new List<FuncionarioVO>();

        FuncionarioVO _funcionarioVO = new FuncionarioVO();
       

        public ITesteDelete()
        {
            long id = 1;
            bool valor = true;
            _mockFunc = new Mock<TstFuncionario.Repository.IFuncionarioRepository>();
            _mockFunc.Setup(m => m.Delete(id)).Returns(valor);
            _funcionario = _mockFunc.Object;

        }

        [Fact]
        public void Delete()
        {
            bool valor = true;
            long Id = 1;
            Assert.Equal(valor, _funcionario.Delete(Id));
        }
    }
}
