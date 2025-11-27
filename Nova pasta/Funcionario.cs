using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Biblioteca.WEB.Models
{
    [Table("Funcionario")]
    public class Funcionario 
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Cargo Funcionario")]
        [StringLength(150)]
        public string Descricao_Tipo { get; set; }
    }
}
