using System.ComponentModel.DataAnnotations;

namespace Projeto_Biblioteca.WEB.Models
{
    public class Registro
    {
        [Key]
        public int Id_Genero { get; set; }
        public string Reserva_Genero { get; set; }
        public virtual Reserva? Reserva { get; set; }
        public DateTime? Devolucao_Registro { get; set; }
    }
}
