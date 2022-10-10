using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Payment.API.Empregado.Data.ValueObjects
{
    public class FuncionarioVO
    {

        [Column("id")]
        public long Id { get; set; }

        [Column("Uniquekey")]
        public string Uniquekey { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("CPF")]
        [Required]
        [StringLength(15)]
        public string cpf { get; set; }

        [Column("E-Mail")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Column("Telefone")]
        [Required]
        [Phone]
        public string telefone { get; set; }

        [Column("CargoDescricao")]
        [Required]
        public string CargoDescricao { get; set; }

        [Column("cargoID")]
        public string cargoID { get; set; }
        public string UsuarioInclusao { get; set; }
        public string DataInclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string DataExclusao { get; set; }
    }
}
