using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca.DAL
{
    public class RegistroDAL : Connection
    {
     
        //        INSERIR REGISTRO
       
        public void Create(RegistroDTO registro)
        {
            Conectar();
            SqlTransaction transaction = conexao.BeginTransaction();
            try
            {
                
                string sql = @"
                    INSERT INTO Registro (ReservaIDReserva,Reserva_Genero,Devolucao_Registro,Devolvido)
                    VALUES (@ReservaRegistro,@Reserva,@Devolucao,@estado);";

                command = new SqlCommand(sql, conexao, transaction);
                command.Parameters.AddWithValue("@ReservaRegistro", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@Reserva", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@Devolucao", registro.DevolucaoRegistro);
                command.Parameters.AddWithValue("@Estado", registro.Devolvido);
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception erro)
            {
                transaction.Rollback();
                throw new Exception("Erro ao inserir registro: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Atualizar(RegistroDTO registro)
        {
            try
            {
                Conectar();

                string sql = @"
                UPDATE Registro
                SET Reserva_Genero = @ReservaRegistro,ReservaIdReserva = @Reserva,Devolucao_Registro = @Devolucao, Devolvido = @Devolvido
                WHERE Id_Genero = @IdRegistro";
                command = new SqlCommand(sql, conexao);

                command.Parameters.AddWithValue("@ReservaRegistro", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@Reserva", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@Devolucao", registro.DevolucaoRegistro);
                command.Parameters.AddWithValue("@IdRegistro", registro.IdRegistro);
                command.Parameters.AddWithValue("@Devolvido", registro.Devolvido);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao atualizar reserva: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //        LISTAR REGISTROS

        public List<RegistroDTO> Listar()
        {
            var lista = new List<RegistroDTO>();

            try
            {
                Conectar();

                string sql = "SELECT Id_Genero,ReservaIdReserva,Devolucao_Registro,Devolvido FROM Registro";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new RegistroDTO
                    {
                        IdRegistro = Convert.ToInt32(dataReader["Id_Genero"]),
                        ReservaRegistro = Convert.ToInt32(dataReader["ReservaIdReserva"]),
                        DevolucaoRegistro = Convert.ToDateTime(dataReader["Devolucao_Registro"]),
                        Devolvido = Convert.ToBoolean(dataReader["Devolvido"])
                    });
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar registros: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }

            return lista;
        }

    
        //        REMOVER REGISTRO
     
        public void Remover(int id)
        {
            try
            {
                Conectar();

                string sql = "DELETE FROM Registro WHERE IdGenero = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao remover registro: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }
      
        //        BUSCAR POR ID
    
        public RegistroDTO BuscarPorId(int id)
        {
            try
            {
                Conectar();

                string sql = "SELECT * FROM Registro WHERE Id_Genero = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new RegistroDTO
                    {
                        IdRegistro = Convert.ToInt32(dataReader["Id_Genero"]),
                        ReservaRegistro = Convert.ToInt32(dataReader["ReservaRegistro"]),
                        DevolucaoRegistro = Convert.ToDateTime(dataReader["DevolucaoRegistro"])
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar registro: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
