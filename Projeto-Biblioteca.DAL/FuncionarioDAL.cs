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
                string sql = @"SELECT IdTipoUsuario, Descricao_Tipo 
                               FROM Funcionario";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new FuncionarioDTO
                    {
                        IdCargo = Convert.ToInt32(dataReader["IdTipoUsuario"]),
                        NomeCargo = dataReader["Descricao_Tipo"].ToString()
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

                string sql = @"SELECT IdTipoUsuario,Descricao_Tipo
                               FROM Funcionario
                               WHERE IdCargo = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new FuncionarioDTO
                    {
                        IdCargo = Convert.ToInt32(dataReader["IdTipoUsuario"]),
                        NomeCargo = dataReader["Descricao_Tipo"].ToString()
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

                string sql = @"INSERT INTO TipoUsuario (NomeCargo)
                               VALUES (@Descricao)";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Descricao", tipo.NomeCargo);

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
                               SET NomeCargo = @Descricao
                               WHERE IdCargo = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Descricao", tipo.NomeCargo);
                command.Parameters.AddWithValue("@Id", tipo.IdCargo);

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
                               WHERE IdCargo = @Id";

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
