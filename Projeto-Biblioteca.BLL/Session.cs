using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca.BLL
{
    public class Session
    {
        public static UsuarioDTO UsuarioLogado { get; set; }

        private static string _user;

        public static string user
        {
            get { return Session._user; }
            set { Session._user = value; }
        }
    }
}