using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.WEB.Models
{
    public class Produto
    {
        [Key]
        public int Id_Produto { get; set; }
        public int Genero_Produto { get; set; }
        public virtual Genero? Genero { get; set; }
        public string Autor_Produto { get; set; }
    }
}
