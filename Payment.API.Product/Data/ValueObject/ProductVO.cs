using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Payment.API.Product.Data.ValueObject
{
    public class ProductVO
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("Uniquekey")]
        public string Uniquekey { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

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
        public string ImageURL { get; set; }

        public string UsuarioInclusao { get; set; }
        public string DataInclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string DataExclusao { get; set; }
    }
}
