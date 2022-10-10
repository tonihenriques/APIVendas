using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Payment.API.Product.Mock;
using System;
using Payment.API.Product.Model.Base;

namespace Payment.API.Product.Model
{
    public class Produto : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public string Price { get; set; }       
        public string Description { get; set; } 
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        

        public static List<Produto> listaProdutos = ListaProdutos.GetProduto();

        public List<Produto> Todos()
        {
            return Produto.listaProdutos;
        }

        public void Salvar()
        {
            Produto.listaProdutos.Add(this);
        }


    }

    
}
