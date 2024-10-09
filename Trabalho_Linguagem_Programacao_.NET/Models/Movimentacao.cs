using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    public enum Tipo { Entrada, Saida};

    [Table("Movimentacoes")]
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Data ")]
        public DateTime data { get; set; }

        [Display(Name = "Tipo: ")]
        public Tipo tipo { get; set; }
        
        [Display(Name = "Produto: ")]
        [StringLength(35)]
        public Produto produto { get; set; }
        [Display(Name = "Produto: ")]
        public int produtoID { get; set; }

        [Display(Name = "Quantidade: ")]
        public int quantidade { get; set; }

        [Display(Name = "Cliente: ")]
        [StringLength(35)]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int? clienteID { get; set; }

        [Display(Name = "Fornecedor: ")]
        [StringLength(35)]
        public Fornecedor fornecedor { get; set; }
        [Display(Name = "Fornecedor: ")]
        public int? fornecedorID { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(35)]
        public string descricao { get; set; }
        
    }
}
