using System;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL usuarioDAL = new();

        
        //                CADASTRAR USUÁRIO
  
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            ValidarCamposObrigatorios(usuario);

            usuarioDAL.Create(usuario);
        }

     
        //                       LOGIN
  
        public UsuarioDTO Login(string login, string senha)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
                throw new Exception("Login e senha são obrigatórios.");

            var usuario = usuarioDAL.Autenticar(login, senha);

            if (usuario == null)
                throw new Exception("Usuário ou senha inválidos.");

            return usuario;
        }
   
      
        //                VALIDAÇÃO DE CAMPOS
        private void ValidarCamposObrigatorios(UsuarioDTO usuario)
        {
            if (usuario == null)
                throw new Exception("Usuário inválido.");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Usuario))
                throw new Exception("Login é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Senha é obrigatória.");
        }
    }
}
