using Payment.API.Vendas.Mock;
using Payment.API.Vendas.Model.Base;
using System;
using System.Collections.Generic;

namespace Payment.API.Vendas.Model
{
    public class OrderVendas : BaseEntity
    {
        public string Id { get; set; }
        public string Uniquekey { get; set; }
        public string PedidoID { get; set; }
        public long ProductID { get; set; }
        public string VendedorID { get; set; } 
        public string VendedorNome { get; set; } 
        public string VendedorCPF { get; set; } 
        public string VendedorTel { get; set; } 
        public string VendedorEmail { get; set; } 
        public string name { get; set; }
        public string Price { get; set; }       
        public string Description { get; set; } 
        public string CategoryName { get; set; }
        public long Quantidade { get; set; }
        public Decimal PurchaseAmount { get; set; }
        public string Status { get; set; }
        public string msgErro { get; set; }


        public static List<OrderVendas> listaOrderVendas = ListaVendas.GetVendas();

        public static List<OrderVendas> Todos()
        {
            return OrderVendas.listaOrderVendas;
        }

        public void Salvar()
        {
            OrderVendas.listaOrderVendas.Add(this);
        }


    }

    
}
