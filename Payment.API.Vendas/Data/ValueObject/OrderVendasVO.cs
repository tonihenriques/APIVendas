using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.API.Vendas.Data.ValueObject
{
    public class OrderVendasVO
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("Uniquekey")]
        public string Uniquekey { get; set; }

        [Column("PedidoID")]
        public string PedidoID { get; set; }

        [Column("ProductID")]
        public long ProductID { get; set; }

        [Column("VendedorID")]          
        public string VendedorID { get; set; }

        [Column("VendedorNome")]
        [Required]
        [StringLength(150)]
        public string VendedorNome { get; set; }

        [Column("CPF")]
        [Required]
        [StringLength(15)]
        public string VendedorCPF { get; set; }

        [Column("Telefone")]
        [Required]
        [Phone]
        public string VendedorTel { get; set; }

        [Column("E-Mail")]
        [Required]
        [EmailAddress]
        public string VendedorEmail { get; set; }

        [Column("name")]
        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [Column("Price")]
        [Required]
        [Range(1, 10000)]
        public string Price { get; set; }

        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public long Quantidade { get; set; }

        [Column("PurchaseAmount")]
        [Required]
        [Range(1, 10000)]
        public Decimal PurchaseAmount { get; set; }

        [Column("Status")]
        [StringLength(50)]
        public string Status { get; set; }
        public string msgErro { get; set; }

        public string UsuarioInclusao { get; set; }
        public string DataInclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string DataExclusao { get; set; }
    }
}
