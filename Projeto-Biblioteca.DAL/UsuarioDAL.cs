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
                     @"INSERT INTO Usuario (Nome,Senha_Usuario,Email_Usuario,Endereco_Usuario,TipoUsuarioId,Atividade,CPF,Telefone,URL_Usuario) VALUES
                     (@Nome,@Senha,@Email,@Endereço,@TipoUsuarioId,@Atividade,@CPF,@Telefone,@URL)", conexao, transaction
                    );

                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Endereço", usuario.Endereco);
                command.Parameters.AddWithValue("@TipoUsuarioId", usuario.TipoUsuarioId);
                command.Parameters.AddWithValue("@Atividade", usuario.atividade);
                command.Parameters.AddWithValue("@CPF", usuario.CPF);
                command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@URL", usuario.UrlFoto);
                int idPessoa = Convert.ToInt32(command.ExecuteScalar());
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
        public SqlDataReader GetDataReader()
        {
            return dataReader;
        }
        public UsuarioDTO Autenticar(string login, string senha, SqlDataReader dataReader)
        {
            try
            {
                Conectar();
                command = new SqlCommand(
            "SELECT * FROM Usuario WHERE Nome = @Usuario AND Senha_Usuario = @Senha", conexao);

                command.Parameters.AddWithValue("@Usuario", login);
                command.Parameters.AddWithValue("@Senha", senha);
                dataReader = command.ExecuteReader();

                UsuarioDTO usuario = null;
                if (dataReader.Read())
                {
                    {
                        usuario = new UsuarioDTO();
                        usuario.Usuario = dataReader["Nome"].ToString();
                        usuario.Senha = dataReader["Senha_Usuario"].ToString();
                        //usuario.TipoUsuario = (string)dataReader["TipoUsuario"];
                    }
                }
                return usuario;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public List<UsuarioDTO> Listar()
        {
            List<UsuarioDTO> lista = new();

            try
            {
                Conectar();
                string sql = @"SELECT Id,Nome,Senha_Usuario,Email_Usuario,Endereco_Usuario,TipoUsuarioId,Atividade,CPF,Telefone,URL_Usuario
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
                        atividade = Convert.ToInt32(dataReader["Atividade"]),
                        TipoUsuarioId = Convert.ToInt32(dataReader["TipoUsuarioId"]),
                        CPF = dataReader["CPF"].ToString(),
                        Telefone = dataReader["Telefone"].ToString(),
                        UrlFoto = dataReader["URL_Usuario"].ToString()
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
                           SET Nome = @Nome, Usuario_Usuario = @Usuario, Senha_Usuario = @Senha,Endereco_Usuario = @Endereco,Email_Usuario = @Email,Atividade = @Atividade,
                           CPF=@CPF,Telefone=@Telefone,URL_Usuario = @URL,TipoUsuarioId=@Cargo
                           WHERE Id = @Id";

            command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@URL", usuario.UrlFoto ?? "");
            command.Parameters.AddWithValue("@Endereco", usuario.Endereco);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Atividade", usuario.atividade);
            command.Parameters.AddWithValue("@CPF", usuario.CPF);
            command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            command.Parameters.AddWithValue("@Cargo", usuario.TipoUsuarioId);

            int linhas = command.ExecuteNonQuery();

            Desconectar();

            if (linhas == 0)
                throw new Exception("Nenhum registro foi atualizado. Verifique o ID.");
        }

    }
}
