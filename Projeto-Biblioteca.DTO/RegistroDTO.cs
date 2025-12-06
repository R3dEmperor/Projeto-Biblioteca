using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca.DTO
{
    public class RegistroDTO 
    {

        public int IdRegistro { get; set; }

        public string Cliente { get; set; }
        public int ReservaRegistro { get; set; }

        public DateTime DevolucaoRegistro { get; set; }
    }
}
