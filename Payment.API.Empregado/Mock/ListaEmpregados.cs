using Payment.API.Empregado.Model;
using System;
using System.Collections.Generic;

namespace Payment.API.Empregado.Mock
{
    public class ListaEmpregados
    {

        public static List<Funcionario> GetEmpregados()
        {

            var listfuncionario = new List<Funcionario>();

            Funcionario func01 = new Funcionario()
            {
                Id = 1,
                Uniquekey = "B49363B9-C1BD-4C43-B0C3-251CD710054E",
                Name = "Antonio Henriques",
                cpf = "245475518-13",
                email = "antonio@antonio.com.br",
                telefone = "031 9 8756-5254",
                CargoDescricao = "Vendedor",
                cargoID = "1",
                UsuarioInclusao = "Usuario admin",
                DataInclusao = "04/10/2022",
                DataExclusao = ""
                
            };
            listfuncionario.Add(func01);

            Funcionario func02 = new Funcionario()
            {
                Id = 2,
                Uniquekey = "0905B99F-592D-4AC3-A97A-ADEB45E49F0B",
                Name = "Geraldo Gerente",
                cpf = "386589789-11",
                email = "geraldo@geraldo.com.br",
                telefone = "031 9 8756-5254",
                CargoDescricao = "Gerente",
                cargoID = "10",
                UsuarioInclusao = "Usuario admin",
                DataInclusao = "04/10/2022",
                DataExclusao = ""

            };
            listfuncionario.Add(func02);





            return listfuncionario;

        }

    }
}
