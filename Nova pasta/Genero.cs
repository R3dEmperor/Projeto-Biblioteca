using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Biblioteca.WEB.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        public int Id_Genero { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome Genero")]
        [StringLength(50)]
        public string Descricao_Genero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Classificação indicativa do genero")]
        [StringLength(2)]
        public string Classificacao_Genero { get; set; }
    }
}
