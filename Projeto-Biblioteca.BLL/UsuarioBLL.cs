using System;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL dal = new();

        // CADASTRAR
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            ValidarUsuario(usuario);
            dal.Create(usuario);
        }

        // LISTAR
        public List<UsuarioDTO> ListarUsuarios()
        {
            return dal.Listar();
        }

        // LOGIN
        public UsuarioDTO Login(string login, string senha)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
                throw new Exception("Login e senha são obrigatórios.");

            return usuarioDAL.Autenticar(login, senha, usuarioDAL.GetDataReader());          
        }

        // ATUALIZAR USUÁRIO
        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            ValidarUsuario(usuario);

            if (usuario.Id <= 0)
                throw new Exception("ID inválido para atualização.");

            dal.Update(usuario);
        }

        // VALIDAÇÃO
        private void ValidarUsuario(UsuarioDTO usuario)
        {
            if (usuario == null)
                throw new Exception("Usuário inválido.");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Senha é obrigatória.");
        }

       
        
            private UsuarioDAL usuarioDAL = new UsuarioDAL();

            public void Excluir(int id)
            {
                usuarioDAL.Excluir(id);
            }
        


    }
}
