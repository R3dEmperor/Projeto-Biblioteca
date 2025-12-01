using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projeto_Biblioteca;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.DAL
{
    public class UsuarioDAL : Connection
    {
       
        
         

            public void Excluir(int id)
            {
            try
            {
                Conectar();

                command = new SqlCommand(
                    "DELETE FROM Usuario WHERE Id = @Id",
                    conexao);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao remover usuario: {erro.Message}");
            }
          
        }
            
        

        public void Create(UsuarioDTO usuario)
        {



            Conectar();
            SqlTransaction transaction = conexao.BeginTransaction();
            try
            {
                command = new SqlCommand
                    (
                     @"INSERT INTO Usuario (Nome,Senha_Usuario,Email_Usuario,Endereco_Usuario,TipoUsuarioId,Atividade) VALUES
                     (@Nome,@Senha,@Email,@Endereço,@TipoUsuarioId,@Atividade)SELECT CAST(SCOPE_IDENTITY() AS int);"
                     , conexao, transaction
                    );
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Endereço", usuario.Endereco);
                command.Parameters.AddWithValue("@TipoUsuarioId", usuario.TipoUsuarioId);
                command.Parameters.AddWithValue("@Atividade", usuario.atividade);

                int idPessoa = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand(@"
                INSERT INTO Usuario ( Nome, Senha_Usuario, TipoUsuarioId,Atividade)
                VALUES ( @Nome, @Senha, @TipoUsuarioId,@Atividade);", conexao, transaction);

                command.Parameters.AddWithValue("@Nome", usuario.Usuario);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@TipoUsuarioId", usuario.TipoUsuarioId);
                command.Parameters.AddWithValue("@Atividade", usuario.atividade);


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
                        usuario.TipoUsuarioId = (int)dataReader["TpUsuario"];
                    }
                }
                return usuario;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
        public List<UsuarioDTO> GetTipoUsuario()
        {
            List<UsuarioDTO> tipos = new List<UsuarioDTO>();

            try
            {
                Conectar();
                string sql = "SELECT IdTipoUsuario, DescricaoTipoUsuario FROM TipoUsuario";
                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    tipos.Add(new FuncionarioDTO
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

        public List<UsuarioDTO> Listar()
        {
            List<UsuarioDTO> lista = new();

            try
            {
                Conectar();
                string sql = @"SELECT Id,Nome,Senha_Usuario,Endereco_Usuario,Email_Usuario,Atividade
                               FROM Usuario";

                command = new SqlCommand(sql, conexao);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new UsuarioDTO
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Nome = dataReader["Nome"].ToString(),
                        Senha = dataReader["Senha_Usuario"].ToString(),
                        Endereco = dataReader["Endereco_Usuario"].ToString(),
                        Email = dataReader["Email_Usuario"].ToString(),
                        atividade = dataReader["Atividade"].Equals(true),
                    });
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao listar tipos de usuário: " + erro.Message);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }

        public void Update(UsuarioDTO usuario)
        {
            Conectar();
            string sql = @"UPDATE Usuario 
                           SET Nome = @Nome, Usuario = @Usuario, Senha = @Senha, UrlFoto = @UrlFoto
                           WHERE Id = @Id";

            command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@UrlFoto", usuario.UrlFoto ?? "");

            int linhas = command.ExecuteNonQuery();

            Desconectar();

            if (linhas == 0)
                throw new Exception("Nenhum registro foi atualizado. Verifique o ID.");
        }

    }
}
