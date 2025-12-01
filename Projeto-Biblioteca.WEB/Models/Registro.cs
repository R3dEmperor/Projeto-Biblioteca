using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Biblioteca.WEB.Models
{
    [Table("Registro")]
    public class Registro
    {
        [Key]
        public int Id_Genero { get; set; }
        public int Reserva_Genero { get; set; }
        public virtual Reserva Reserva { get; set; }
        public DateTime? Devolucao_Registro { get; set; }
    }
}
