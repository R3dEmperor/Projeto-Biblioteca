using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca.DAL
{
    public class ProdutoDAL : Connection
    {

        //        CADASTRAR PRODUTO

        // CADASTRAR PRODUTO
        public void Create(ProdutoDTO livro)
        {
            Conectar();
            SqlTransaction transaction = conexao.BeginTransaction();
            try
            {
                   command = new SqlCommand
                    (
                       @"INSERT INTO Produto (Nome_Produto,Genero_Produto,GeneroId_Genero, Autor_Produto, Url_Foto)
                       VALUES (@Nome, @Genero,@Genero, @Autor,@url)", conexao , transaction
                    );
                
              command.Parameters.AddWithValue("@Nome", livro.NomeProduto);
              command.Parameters.AddWithValue("@Genero", livro.GeneroProduto);
              command.Parameters.AddWithValue("@Autor", livro.AutorProduto);
              command.Parameters.AddWithValue("@url", livro.UrlFoto);
              int idPproduto = Convert.ToInt32(command.ExecuteScalar());
              command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception erro)
            {
                transaction.Rollback();
                throw new Exception("Erro ao cadastrar produto: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

 
        //        LISTAR PRODUTOS
     
        public List<ProdutoDTO> Listar()
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                Conectar();
                string sql = "SELECT * FROM Produto";
                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    produtos.Add(new ProdutoDTO
                    {
                        IdProduto = Convert.ToInt32(dataReader["Id_Produto"]),
                        NomeProduto = dataReader["Nome_Produto"].ToString(),
                        GeneroProduto = int.Parse(dataReader["Genero_Produto"].ToString()),
                        AutorProduto = dataReader["Autor_Produto"].ToString()
                    });
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar produtos: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
            return produtos;
        }

  
        //        REMOVER PRODUTO
       
        public void Remover(int id)
        {
            try
            {
                Conectar();

                string sql = "DELETE FROM Produto WHERE Id_Produto = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao remover produto: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    
        //        BUSCAR POR ID
     
        public ProdutoDTO BuscarPorId(int id)
        {
            try
            {
                Conectar();

                string sql = "SELECT * FROM Produto WHERE IdProduto = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new ProdutoDTO
                    {
                        IdProduto = Convert.ToInt32(dataReader["Id_Produto"]),
                        NomeProduto = dataReader["Genero_Produto"].ToString(),
                        GeneroProduto = int.Parse(dataReader["Genero_Produto"].ToString()),
                        AutorProduto = dataReader["Autor_Produto"].ToString(),
                    };

                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar produto: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

      
        //        ATUALIZAR PRODUTO
   
        public void Atualizar(ProdutoDTO livro)
        {
            try
            {
                Conectar();

                string sql = @"
                    UPDATE Produto
                    SET Nome_Produto = @NomeProduto,
                        GeneroId_Genero = @Genero_Produto,
                        Autor_Produto = @Autor_Produto,
                        Url_Foto = @url,
                        Genero_Produto = @Genero_Produto
                    WHERE Id_Produto = @Id_Produto";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@NomeProduto", livro.NomeProduto);
                command.Parameters.AddWithValue("@Genero_Produto", livro.GeneroProduto);
                command.Parameters.AddWithValue("@Autor_Produto", livro.AutorProduto);
                command.Parameters.AddWithValue("@Id_Produto", livro.IdProduto);
                command.Parameters.AddWithValue("@url", livro.UrlFoto);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar produto: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
