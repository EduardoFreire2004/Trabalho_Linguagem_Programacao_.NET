using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data: ")]
        public DateTime data { get; set; }
        
        [Display(Name = "Cliente: ")]
        [StringLength(35)]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteID { get; set; }

        [Display(Name = "Produto: ")]
        [StringLength(35)]
        public Produto produto { get; set; }
        [Display(Name = "Produto: ")]
        public int produtoID { get; set; }

        [Display(Name = "Quantidade: ")]
        public int quantidade { get; set; }

    }

}
