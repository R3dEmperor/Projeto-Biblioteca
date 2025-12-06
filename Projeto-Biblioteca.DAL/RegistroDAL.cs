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
            try
            {
                Conectar();

                string sql = @"
                    INSERT INTO Registro (Reserva_Genero, Devolucao_Registro,ReservaIDReserva)
                    VALUES (@livro, @DevolucaoRegistro,@ReservaRegistro);";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@livro", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@ReservaRegistro", registro.ReservaRegistro);
                command.Parameters.AddWithValue("@DevolucaoRegistro", registro.DevolucaoRegistro);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao inserir registro: " + erro.Message);
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

                string sql = "SELECT * FROM Registro";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new RegistroDTO
                    {
                        IdRegistro = Convert.ToInt32(dataReader["IdRegistro"]),
                        ReservaRegistro = Convert.ToInt32(dataReader["ReservaRegistro"]),
                        DevolucaoRegistro = Convert.ToDateTime(dataReader["DevolucaoRegistro"])
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

                string sql = "DELETE FROM Registro WHERE IdRegistro = @Id";

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

                string sql = "SELECT * FROM Registro WHERE IdRegistro = @Id";

                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new RegistroDTO
                    {
                        IdRegistro = Convert.ToInt32(dataReader["IdRegistro"]),
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
