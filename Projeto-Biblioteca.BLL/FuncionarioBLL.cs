using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class FuncionarioBLL
    {
        // Instância da DAL que conversa com o banco ou lista
        private readonly FuncionarioDAL dal = new();

        //                    LISTAR FUNCIONÁRIOS

        public List<FuncionarioDTO> ListarCargos()
        {
            return dal.Listar();
        }



        //                    BUSCAR POR ID

        public FuncionarioDTO BuscarPorId(int id)
        {
            var func = dal.BuscarPorId(id);
            return func;
        }
    }
}
