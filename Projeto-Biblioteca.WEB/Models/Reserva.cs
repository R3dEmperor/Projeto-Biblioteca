using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Biblioteca.WEB.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public int UsuarioReserva { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public int ProdutoReserva { get; set; }
        public virtual Produto? Produto { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
