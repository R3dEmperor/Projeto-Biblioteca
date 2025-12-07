using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
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

            dal.Create(registro);
        }
        public void AtualizarRegistro(RegistroDTO registro)
        {

            dal.Atualizar(registro);
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
    }
}
