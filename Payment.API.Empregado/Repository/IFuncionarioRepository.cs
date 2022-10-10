using Payment.API.Empregado.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Empregado.Repository
{
    public interface IFuncionarioRepository
    {
        IEnumerable<FuncionarioVO> FindAll();
        FuncionarioVO FindById(long id);
        FuncionarioVO Create(FuncionarioVO vo);
        FuncionarioVO Update(FuncionarioVO vo);
        bool Delete(long id);
    }
}
