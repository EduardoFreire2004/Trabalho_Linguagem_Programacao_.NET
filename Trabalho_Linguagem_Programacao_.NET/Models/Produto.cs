using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    public enum Categoria { Insumo,Agrotoxico,Semente  };

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

        
        [Display(Name = "Categoria: ")]
        public Categoria categoria { get; set; }


        [Display(Name = "Preço: ")]
        public float preco { get; set; }


        [Display(Name = "Quantidade em Estoque: ")]
        public int qtde_estoque { get; set; }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
