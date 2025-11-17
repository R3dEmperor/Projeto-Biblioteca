using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.DAL
{
    public class UsuarioDAL : Connection
    {

        public void Create(UsuarioDTO usuario)
        {
            Conectar();
            SqlTransaction transaction = conexao.BeginTransaction();
            try
            {
                command = new SqlCommand
                    (
                     @"INSERT INTO pessoa (Nome, Email,Telefone,CPF) VALUES
                     (@Nome,@Email,@Telefone,@CPF)SELECT CAST(SCOPE_IDENTITY() AS int);"
                     , conexao, transaction
                    );
                command.Parameters.AddWithValue("@Nome", usuario.Usuario);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@CPF", usuario.CPF);

                int idPessoa = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand(@"
                INSERT INTO Usuario (Id, Usuario, Senha, TpUsuario)
                VALUES (@Id, @Usuario, @Senha, @TpUsuario);", conexao, transaction);

                command.Parameters.AddWithValue("@Id", idPessoa);
                command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@TpUsuario", usuario.TipoUsuario);


                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception erro)
            {
                transaction.Rollback();
                throw new Exception($"Erro ao cadastrar usuario, Erro do sistema: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }
        public UsuarioDTO Autenticar(string login, string senha)
        {
            try
            {
                Conectar();
                command = new SqlCommand("SELECT * FROM Usuario WHERE Usuario " +
                    "= @Usuario AND Senha = @Senha", conexao);

                command.Parameters.AddWithValue("@Usuario", login);
                command.Parameters.AddWithValue("@Senha", senha);
                dataReader = command.ExecuteReader();

                UsuarioDTO usuario = null;
                if (dataReader.Read())
                {
                    {
                        usuario = new UsuarioDTO();
                        usuario.Usuario = dataReader["Usuario"].ToString();
                        usuario.Senha = dataReader["Senha"].ToString();
                        usuario.TipoUsuario.IdTipoUsuario = (int)dataReader["TpUsuario"];
                    }
                }
                return usuario;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
        public List<TipoUsuarioDTO> GetTipoUsuario()
        {
            List<TipoUsuarioDTO> tipos = new List<TipoUsuarioDTO>();

            try
            {
                Conectar();
                string sql = "SELECT IdTipoUsuario, DescricaoTipoUsuario FROM TipoUsuario";
                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    tipos.Add(new TipoUsuarioDTO
                    {
                        IdTipoUsuario = Convert.ToInt32(dataReader["IdTipoUsuario"]),
                        DescricaoTipoUsuario = dataReader["DescricaoTipoUsuario"].ToString()
                    });
                }

                return tipos;
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao listar tipos de usuário: {erro.Message}");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
