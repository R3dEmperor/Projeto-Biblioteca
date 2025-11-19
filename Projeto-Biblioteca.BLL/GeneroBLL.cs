using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class GeneroBLL
    {
        // Instância da DAL para acessar os dados
        private readonly GeneroDAL dal = new();

        // =====================================================
        //                CADASTRAR GÊNERO
        // =====================================================
        public void CadastrarGenero(GeneroDTO genero)
        {
            ValidarCampos(genero);

            dal.Create(genero);
        }

        // =====================================================
        //                LISTAR GÊNEROS
        // =====================================================
        public List<GeneroDTO> ListarGeneros()
        {
            return dal.Listar();
        }

        // =====================================================
        //                REMOVER GÊNERO
        // =====================================================
        public void RemoverGenero(int id)
        {
            if (id <= 0)
                throw new Exception("Id de gênero inválido.");

            dal.Remover(id);
        }

        // =====================================================
        //           VALIDAÇÃO DE CAMPOS (REGRAS)
        // =====================================================
        private void ValidarCampos(GeneroDTO genero)
        {
            if (string.IsNullOrWhiteSpace(genero.NomeGenero))
                throw new Exception("O nome do gênero é obrigatório.");

            if (string.IsNullOrWhiteSpace(genero.ClassificacaoGenero))
                throw new Exception("A classificação do gênero é obrigatória.");
        }
    }
}
