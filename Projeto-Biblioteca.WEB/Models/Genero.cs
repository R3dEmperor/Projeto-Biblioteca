using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.WEB.Models
{
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
        public int Classificacao_Genero { get; set; }
    }
}
