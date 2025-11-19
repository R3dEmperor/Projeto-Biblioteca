using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Projeto_Biblioteca.DAL
{
    public class ReservaDAL : Connection
    {
        public void Create(ReservaDTO reserva)
        {
            try
            {
                Conectar();

                string sql = @"
                INSERT INTO Reserva (UsuarioReserva, ProdutoReserva, DataReserva, DataDevolucao, Ativa)
                VALUES (@UsuarioReserva, @ProdutoReserva, @DataReserva, @DataDevolucao, @Ativa);";

                command = new SqlCommand(sql, conexao);

                command.Parameters.AddWithValue("@UsuarioReserva", reserva.UsuarioReserva);
                command.Parameters.AddWithValue("@ProdutoReserva", reserva.ProdutoReserva);
                command.Parameters.AddWithValue("@DataReserva", reserva.DataReserva);
                command.Parameters.AddWithValue("@DataDevolucao", reserva.DataDevolucao);
                command.Parameters.AddWithValue("@Ativa", reserva.Ativa);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao cadastrar reserva: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

       
        //  LISTAR TODAS
        
        public List<ReservaDTO> Listar()
        {
            List<ReservaDTO> lista = new();

            try
            {
                Conectar();

                command = new SqlCommand("SELECT * FROM Reserva", conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new ReservaDTO
                    {
                        IdReserva = Convert.ToInt32(dataReader["IdReserva"]),
                        UsuarioReserva = Convert.ToInt32(dataReader["UsuarioReserva"]),
                        ProdutoReserva = Convert.ToInt32(dataReader["ProdutoReserva"]),
                        DataReserva = Convert.ToDateTime(dataReader["DataReserva"]),
                        DataDevolucao = Convert.ToDateTime(dataReader["DataDevolucao"]),
                        Ativa = Convert.ToBoolean(dataReader["Ativa"])
                    });
                }

                return lista;
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao listar reservas: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //  BUSCAR POR ID
      
        public ReservaDTO BuscarPorId(int id)
        {
            try
            {
                Conectar();

                string sql = "SELECT * FROM Reserva WHERE IdReserva = @Id";
                command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@Id", id);

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    return new ReservaDTO
                    {
                        IdReserva = Convert.ToInt32(dataReader["IdReserva"]),
                        UsuarioReserva = Convert.ToInt32(dataReader["UsuarioReserva"]),
                        ProdutoReserva = Convert.ToInt32(dataReader["ProdutoReserva"]),
                        DataReserva = Convert.ToDateTime(dataReader["DataReserva"]),
                        DataDevolucao = Convert.ToDateTime(dataReader["DataDevolucao"]),
                        Ativa = Convert.ToBoolean(dataReader["Ativa"])
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao buscar reserva: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

  
        //  ATUALIZAR
     
        public void Atualizar(ReservaDTO r)
        {
            try
            {
                Conectar();

                string sql = @"
                UPDATE Reserva
                SET UsuarioReserva = @UsuarioReserva,
                    ProdutoReserva = @ProdutoReserva,
                    DataReserva = @DataReserva,
                    DataDevolucao = @DataDevolucao,
                    Ativa = @Ativa
                WHERE IdReserva = @IdReserva";

                command = new SqlCommand(sql, conexao);

                command.Parameters.AddWithValue("@IdReserva", r.IdReserva);
                command.Parameters.AddWithValue("@UsuarioReserva", r.UsuarioReserva);
                command.Parameters.AddWithValue("@ProdutoReserva", r.ProdutoReserva);
                command.Parameters.AddWithValue("@DataReserva", r.DataReserva);
                command.Parameters.AddWithValue("@DataDevolucao", r.DataDevolucao);
                command.Parameters.AddWithValue("@Ativa", r.Ativa);

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

        // ============================================================
        //  REMOVER
        // ============================================================
        public void Remover(int id)
        {
            try
            {
                Conectar();

                command = new SqlCommand(
                    "DELETE FROM Reserva WHERE IdReserva = @Id",
                    conexao);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao remover reserva: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
