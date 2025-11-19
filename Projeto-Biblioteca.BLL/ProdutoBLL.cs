using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class ProdutoBLL
    {
        // Instancia o DAL, que acessa o banco de dados
        private readonly ProdutoDAL dal = new();


        // Método para cadastrar um livro
        public  void CadastrarProduto(ProdutoDTO produto)
        {
            // Verifica se os campos obrigatórios foram preenchidos
            ValidarCampos(produto);

            // Envia o produto para o banco através do DAL
            dal.Create(produto);
        }

        // Método para editar um livro já existente
        public void AtualizarProduto(ProdutoDTO produto)
        {
            ValidarCampos(produto);
            dal.Atualizar(produto);
        }

        // Método para remover um produto (livro)
        public void RemoverProduto(int id)
        {
            dal.Remover(id);
        }

        // Lista todos os livros cadastrados
        public List<ProdutoDTO> ListarProdutos()
        {
            return dal.Listar();
        }

        // Busca um livro pelo ID
        public ProdutoDTO BuscarPorId(int id)
        {
            return dal.BuscarPorId(id);
        }

        // ===== Validação dos campos (REGRAS DE NEGÓCIO) =====

        private void ValidarCampos(ProdutoDTO produto)
        {
            if (string.IsNullOrWhiteSpace(produto.NomeProduto))
                throw new Exception("O título do livro é obrigatório.");

            if (string.IsNullOrWhiteSpace(produto.AutorProduto))
                throw new Exception("O autor do livro é obrigatório.");

            if (string.IsNullOrWhiteSpace(produto.GeneroProduto))
                throw new Exception("O gênero é obrigatório.");
        }
    }
}
