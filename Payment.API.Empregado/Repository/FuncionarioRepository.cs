using AutoMapper;
using Payment.API.Empregado.Data.ValueObjects;
using Payment.API.Empregado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Empregado.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private IMapper _mapper;

        public FuncionarioRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

      
        public IEnumerable<FuncionarioVO> FindAll()
        {
            try
            {
                List<Funcionario> func = Funcionario.listaFuncionarios;

                return _mapper.Map<List<FuncionarioVO>>(func);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public FuncionarioVO FindById(long id)
        {
            try
            {
                List<Funcionario> funcs = Funcionario.listaFuncionarios;

                var func = funcs.Where(x => x.Id == id).FirstOrDefault();

                return _mapper.Map<FuncionarioVO>(func);

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public FuncionarioVO Create(FuncionarioVO vo)
        {
            try
            {
                Funcionario func = _mapper.Map<Funcionario>(vo);

                func.UsuarioInclusao = "Usuario Admin";
                func.DataInclusao = DateTime.Now.ToString();

                func.Salvar();

                var products = _mapper.Map<FuncionarioVO>(func);

                return products;
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public FuncionarioVO Update(FuncionarioVO vo)
        {

            try
            {
                return AtualizaEmpregado(vo);

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private FuncionarioVO AtualizaEmpregado(FuncionarioVO vo)
        {
            Funcionario func = _mapper.Map<Funcionario>(vo);
            var id = func.Id;

            List<Funcionario> funcs = Funcionario.listaFuncionarios;

            var funcUp = funcs.Where(x => x.Id == id).FirstOrDefault();

            Funcionario funcionario = new Funcionario()
            {
                Id = funcUp.Id,
                Uniquekey = funcUp.Uniquekey,
                Name = funcUp.Name,
                cpf = funcUp.cpf,
                email = funcUp.email,
                telefone = funcUp.telefone,
                cargoID = funcUp.cargoID,
                CargoDescricao = funcUp.CargoDescricao,
                UsuarioExclusao = "Usuario Admin",
                DataExclusao = DateTime.Now.ToString(),
            };

            funcs.Add(funcionario);

            funcs.Remove(funcUp);

            Funcionario funcionarioUP = new Funcionario()
            {
                Id = func.Id,
                Uniquekey = Guid.NewGuid().ToString(),
                Name = func.Name,
                cpf = func.cpf,
                email = func.email,
                telefone = func.telefone,
                cargoID = func.cargoID,
                CargoDescricao = func.CargoDescricao,
                UsuarioInclusao = "Usuario Admin",
                UsuarioExclusao = "",
                DataInclusao = DateTime.Now.ToString(),
            };

            funcs.Add(funcionarioUP);

            return _mapper.Map<FuncionarioVO>(func);
        }

        public bool Delete(long id)
        {           
            try
            {
                return ExcluirLogico(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ExcluirLogico(long id)
        {
            List<Funcionario> funcionarios = Funcionario.listaFuncionarios;

            var funcUp = funcionarios.Where(x => x.Id == id).FirstOrDefault();

            Funcionario funcionario = new Funcionario()
            {
                Id = funcUp.Id,
                Uniquekey = funcUp.Uniquekey,
                Name = funcUp.Name,
                cpf = funcUp.cpf,
                email = funcUp.email,
                telefone = funcUp.telefone,
                cargoID = funcUp.cargoID,
                CargoDescricao = funcUp.CargoDescricao,
                UsuarioExclusao = "Usuario Admin",
                DataExclusao = DateTime.Now.ToString(),

            };

            funcionarios.Add(funcionario);

            funcionarios.Remove(funcUp);

            return true;
        }

    }
}
