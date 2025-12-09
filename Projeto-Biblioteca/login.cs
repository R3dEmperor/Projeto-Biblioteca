using System.Diagnostics.Eventing.Reader;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca
{
    public partial class login : Form
    {
        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Biblioteca\usuarios";

        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
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
                var user = usuarioBLL.ListarUsuarios().FirstOrDefault(x => x.Nome == txtNome.Text);
                Session.UsuarioLogado = user;
                MessageBox.Show($"Bem-vindo(a), {Session.UsuarioLogado.Usuario}!", "Login realizado",
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
            frmIntro frmIntro = new frmIntro();
            frmIntro.ShowDialog();
        }

        private void pbFotoLogin_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = diretorioImagens;
            openFileDialog.Filter = "Arquivos de imagens |*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Escolha a imagem e se transforme";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = openFileDialog.FileName;

                pbFotoLogin.Image = Image.FromFile(nomeArquivoImagem);


                lblFotoCaminhoLogin.Text = nomeArquivoImagem;
            }
        }
    }
}
