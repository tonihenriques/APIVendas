using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Payment.API.Product.Model;
using System.Collections.Generic;

namespace Payment.API.Product.Mock
{
    public static class ListaProdutos
    {
        public static List<Produto> GetProduto()
        {

            var listproduto = new List<Produto>();

            Produto prod01 = new Produto()
            {
                Id = 1,
                Name = "Calça Jeans",
                Price = "60",
                Description = "Calça Jeans tamanho GG",
                CategoryName = "Calça",
                ImageURL = "www.calcajeans.com.br",
                UsuarioInclusao = "Admin Usuario",
                DataInclusao= "10/02/2022",
                UsuarioExclusao = "",
                DataExclusao = ""
             };

            listproduto.Add(prod01);

            Produto prod02 = new Produto()
            {
                Id = 2,
                Name = "Calça tergal",
                Price = "120",
                Description = "Calça tergal tamanho M",
                CategoryName = "Calça",
                ImageURL = "www.calcatergal.com.br",
                UsuarioInclusao = "Admin Usuario",
                DataInclusao = "12/05/2022",
                UsuarioExclusao = "",
                DataExclusao = ""

            };

            listproduto.Add(prod02);

            Produto prod03 = new Produto()
            {
                Id = 3,
                Name = "Camisa Social",
                Price = "145",
                Description = "Camisa Social tamanho M",
                CategoryName = "Camisa",
                ImageURL = "www.camisasocial.com.br",
                UsuarioInclusao = "Admin Usuario",
                DataInclusao = "17/03/2022",
                UsuarioExclusao = "",
                DataExclusao = ""

            };

            listproduto.Add(prod03);

            return listproduto;

        }


        


    }
}
