using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca.DAL
{
    public class GeneroDAL : Connection
    {
    
        //        CADASTRAR GÊNERO
      
        public void Create(GeneroDTO genero)
        {
            try
            {
                Conectar();

                string sql = @"
                    INSERT INTO Genero (NomeGenero, ClassificacaoGenero)
                    VALUES (@NomeGenero, @ClassificacaoGenero);";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@NomeGenero", genero.NomeGenero);
                command.Parameters.AddWithValue("@ClassificacaoGenero", genero.ClassificacaoGenero);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao cadastrar gênero: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //        LISTAR GÊNEROS

        public List<GeneroDTO> Listar()
        {
            List<GeneroDTO> generos = new List<GeneroDTO>();

            try
            {
                Conectar();

                string sql = "SELECT * FROM Genero";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    generos.Add(new GeneroDTO
                    {
                        IdGenero = Convert.ToInt32(dataReader["IdGenero"]),
                        NomeGenero = dataReader["NomeGenero"].ToString(),
                        ClassificacaoGenero = dataReader["ClassificacaoGenero"].ToString()
                    });
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar gêneros: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }

            return generos;
        }

   
        //        BUSCAR POR ID
      
        public GeneroDTO BuscarPorId(int id)
        {
            try
            {
                Conectar();

                string sql = "SELECT * FROM Genero WHERE IdGenero = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new GeneroDTO
                    {
                        IdGenero = Convert.ToInt32(dataReader["IdGenero"]),
                        NomeGenero = dataReader["NomeGenero"].ToString(),
                        ClassificacaoGenero = dataReader["ClassificacaoGenero"].ToString()
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar gênero: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    
        //        ATUALIZAR GÊNERO
        
        public void Atualizar(GeneroDTO genero)
        {
            try
            {
                Conectar();

                string sql = @"
                    UPDATE Genero
                    SET NomeGenero = @NomeGenero,
                        ClassificacaoGenero = @ClassificacaoGenero
                    WHERE IdGenero = @IdGenero";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@NomeGenero", genero.NomeGenero);
                command.Parameters.AddWithValue("@ClassificacaoGenero", genero.ClassificacaoGenero);
                command.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar gênero: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //        REMOVER GÊNERO
      
        public void Remover(int id)
        {
            try
            {
                Conectar();

                string sql = "DELETE FROM Genero WHERE IdGenero = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao remover gênero: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
