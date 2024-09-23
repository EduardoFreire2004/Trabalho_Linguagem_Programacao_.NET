using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public String nome { get; set; }

        [Display(Name = "Produto: ")]
        [StringLength(35)]
        public Produto produto { get; set; }
        [Display(Name = "Produto: ")]
        public int produtoID { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular: ")]
        public String celular { get; set; }

        [StringLength(35)]
        [Display(Name = "Email: ")]
        public String email { get; set; }

    }
}
