using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Biblioteca.WEB.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id_Produto { get; set; }
        public int Genero_Produto { get; set; }
        public virtual Genero? Genero { get; set; }
        public string Autor_Produto { get; set; }
    }
}
