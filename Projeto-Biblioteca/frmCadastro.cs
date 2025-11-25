using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca
{
    public partial class frmCadastro : Form
    {
        UsuarioBLL usuarioBLL = new();
        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\transformese\usuarios";
        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {


            var funcionario = new FuncionarioDTO
            {
                Nome = txtNome.Text,
                Senha = txtSenha.Text,
                Email = txtEmail.Text,

            };
            usuarioBLL.CadastrarUsuario(funcionario);
        }

        private void PbFoto_Click(object sender, EventArgs e)
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

                PbFoto.Image = Image.FromFile(nomeArquivoImagem);

                txtFotoCaminho.Text = nomeArquivoImagem;
            }

        }
    }
}
