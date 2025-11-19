using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca.DAL
{
    public class FuncionarioDAL : Connection
    {
   
        //                     LISTAR
     
        public List<FuncionarioDTO> Listar()
        {
            List<FuncionarioDTO> lista = new();

            try
            {
                Conectar();
                string sql = @"SELECT IdTipoUsuario, DescricaoTipoUsuario 
                               FROM TipoUsuario";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new FuncionarioDTO
                    {
                        IdTipoUsuario = Convert.ToInt32(dataReader["IdTipoUsuario"]),
                        DescricaoTipoUsuario = dataReader["DescricaoTipoUsuario"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar tipos de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

      
        //                 BUSCAR POR ID

        public FuncionarioDTO BuscarPorId(int id)
        {
            try
            {
                Conectar();

                string sql = @"SELECT IdTipoUsuario, DescricaoTipoUsuario
                               FROM TipoUsuario
                               WHERE IdTipoUsuario = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new FuncionarioDTO
                    {
                        IdTipoUsuario = Convert.ToInt32(dataReader["IdTipoUsuario"]),
                        DescricaoTipoUsuario = dataReader["DescricaoTipoUsuario"].ToString()
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar tipo de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    
        //                      CREATE
      
        public void Create(FuncionarioDTO tipo)
        {
            try
            {
                Conectar();

                string sql = @"INSERT INTO TipoUsuario (DescricaoTipoUsuario)
                               VALUES (@Descricao)";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Descricao", tipo.DescricaoTipoUsuario);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar tipo de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //                      UPDATE
 
        public void Update(FuncionarioDTO tipo)
        {
            try
            {
                Conectar();

                string sql = @"UPDATE TipoUsuario 
                               SET DescricaoTipoUsuario = @Descricao
                               WHERE IdTipoUsuario = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Descricao", tipo.DescricaoTipoUsuario);
                command.Parameters.AddWithValue("@Id", tipo.IdTipoUsuario);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar tipo de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

       
        //                      DELETE
       
        public void Delete(int id)
        {
            try
            {
                Conectar();

                string sql = @"DELETE FROM TipoUsuario
                               WHERE IdTipoUsuario = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao remover tipo de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
