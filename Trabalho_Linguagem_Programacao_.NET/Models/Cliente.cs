using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [StringLength(50)]
        [Display(Name = "Endereço: ")]
        public String endereco { get; set; }

        [StringLength (20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }

        [StringLength (35)]
        [Display(Name = "Email: ")]
        public String email { get; set; }
    }
}
