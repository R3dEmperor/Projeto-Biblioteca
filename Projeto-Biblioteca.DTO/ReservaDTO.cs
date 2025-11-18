using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca.DTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }

        public int UsuarioReserva { get; set; }

        public int ProdutoReserva { get; set; }

        public DateTime DataReserva { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
