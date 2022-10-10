using Payment.API.Empregado.Mock;
using Payment.API.Empregado.Model.Base;
using System.Collections.Generic;

namespace Payment.API.Empregado.Model
{
    public class Funcionario: BaseEntity
    {
        public string Name { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string CargoDescricao { get; set; }
        public string cargoID { get; set; }

        public static List<Funcionario> listaFuncionarios = ListaEmpregados.GetEmpregados();

        public List<Funcionario> Todos()
        {
            return Funcionario.listaFuncionarios;
        }

        public void Salvar()
        {
            Funcionario.listaFuncionarios.Add(this);
        }



    }
}
