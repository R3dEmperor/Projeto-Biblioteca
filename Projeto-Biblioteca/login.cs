using System.Diagnostics.Eventing.Reader;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private readonly UsuarioBLL usuarioBLL = new();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {

                var usuario = usuarioBLL.Login(txtNome.Text, txtSenha.Text);
                Session.UsuarioLogado = usuario;
                MessageBox.Show($"Bem-vindo(a), {Session.UsuarioLogado.Nome}!", "Login realizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormMain main = new();
                main.Show();


                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro ao entrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }



        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void PbFundo_Click(object sender, EventArgs e)
        {

        }

        private void btxClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
