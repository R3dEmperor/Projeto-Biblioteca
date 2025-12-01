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
            try
            {
                Conectar();

                string sql = @"
                    INSERT INTO Produto (Genero_Produto, GeneroId_Genero, Autor_Produto)
                    VALUES (@NomeProduto, @GeneroProduto, @AutorProduto);";

                using (command = new SqlCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Nome", livro.NomeProduto);
                    command.Parameters.AddWithValue("@Genero", livro.GeneroProduto);
                    command.Parameters.AddWithValue("@Autor", livro.AutorProduto);

                }
            }
            catch (Exception erro)
            {
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
                        NomeProduto = dataReader["Genero_Produto"].ToString(),
                        GeneroProduto = int.Parse(dataReader["GeneroId_Genero"].ToString()),
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
                    SET Genero_Produto = @NomeProduto,
                        GeneroId_Genero = @GeneroId_Genero,
                        Autor_Produto = @Autor_Produto
                    WHERE Id_Produto = @Id_Produto";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@NomeProduto", livro.NomeProduto);
                command.Parameters.AddWithValue("@GeneroId_Genero", livro.GeneroProduto);
                command.Parameters.AddWithValue("@Autor_Produto", livro.AutorProduto);
                command.Parameters.AddWithValue("@Id_Produto", livro.IdProduto);

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
