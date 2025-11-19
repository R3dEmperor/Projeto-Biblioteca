using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class RegistroBLL
    {
        RegistroDAL dal = new();

        // ======================================================
        //              CRIAR UM NOVO REGISTRO
        // ======================================================
        public void CriarRegistro(RegistroDTO registro)
        {
            ValidarCamposObrigatorios(registro);

            // define a data atual como data do registro
            registro.DevolucaoRegistro = DateTime.Now.AddDays(7);
            // exemplo: devolução prevista para daqui 7 dias

            dal.Criar(registro);
        }

        // ======================================================
        //                 LISTAR REGISTROS
        // ======================================================
        public List<RegistroDTO> ListarRegistros()
        {
            return dal.Listar();
        }

        // ======================================================
        //                 REMOVER REGISTRO
        // ======================================================
        public void RemoverRegistro(int id)
        {
            if (id <= 0)
                throw new Exception("Id do registro inválido.");

            dal.Remover(id);
        }

        // ======================================================
        //           VALIDA CAMPOS IMPORTANTES
        // ======================================================
        private void ValidarCamposObrigatorios(RegistroDTO registro)
        {
            if (registro.ReservaRegistro <= 0)
                throw new Exception("Reserva inválida para criar um registro.");
        }
    }
}
