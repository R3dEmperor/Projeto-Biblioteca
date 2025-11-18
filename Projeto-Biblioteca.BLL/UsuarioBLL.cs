using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;


namespace Projeto_Biblioteca.DAL
{
    public static class Database
    {
        public static List<UsuarioDTO> Usuarios { get; set; } = new();
    }
}


namespace Projeto_Biblioteca.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new();
       
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            
            usuarioDAL.Create(usuario);
        }

        public UsuarioDTO Login(string login, string senha)
        {
           
            return usuarioDAL.Autenticar(login, senha);
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            return Database.Usuarios.OrderBy(u => u.Nome).ToList();
        }

       
        public UsuarioDTO BuscarPorId(int id)
        {
            var usuario = Database.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");
            return usuario;
        }

        public void AtualizarUsuario(UsuarioDTO usuarioDTO)
        {
            ValidarCamposObrigatorios(usuarioDTO);

            var usuarios = Database.Usuarios;
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuarioDTO.Id);

            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado.");

            // Verifica duplicidade de login (outro usuário com o mesmo login)
            if (usuarios.Any(u =>
                    u.Usuario.Equals(usuarioDTO.Usuario, StringComparison.OrdinalIgnoreCase) &&
                    u.Id != usuarioDTO.Id))
                throw new Exception("Já existe outro usuário com este login.");

            // Atualiza dados
            usuarioExistente.Nome = usuarioDTO.Nome;
            usuarioExistente.Email = usuarioDTO.Email;
            usuarioExistente.Telefone = usuarioDTO.Telefone;
            usuarioExistente.CPF     = usuarioDTO.CPF;

            Database.Usuarios = usuarios; 

        }

        public void RemoverUsuario(int id)
        {
            var usuarios = Database.Usuarios;
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            usuarios.Remove(usuario);
            Database.Usuarios = usuarios;
        }
        private static void ValidarCamposObrigatorios(UsuarioDTO usuario)
        {
            if (usuario == null)
                throw new Exception("Objeto usuário inválido.");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Usuario))
                throw new Exception("Login é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Senha é obrigatória.");
        }
    }
}
