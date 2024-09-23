using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [StringLength(25)]
        [Display(Name = "Categoria: ")]
        public String categoria { get; set; }


        [Display(Name = "Preço: ")]
        public float preco { get; set; }


        [Display(Name = "Quantidade em Estoque: ")]
        public int qtde_estoque { get; set; }

    }
}
