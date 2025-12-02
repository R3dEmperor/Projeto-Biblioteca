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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();

                var usuario = usuarioBLL.Login(txtNome.Text, txtSenha.Text);

                MessageBox.Show($"Bem-vindo(a), {usuario.Nome}!", "Login realizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormMain main = new FormMain();
                main.Show();

                
                this.Hide();
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
    }
}
