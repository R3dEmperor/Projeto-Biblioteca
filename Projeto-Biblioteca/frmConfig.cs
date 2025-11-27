using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DTO;

namespace Projeto_Biblioteca
{
    public partial class frmConfig : Form
    {
        private FuncionarioDTO funcionarioAtual;

        private readonly FuncionarioBLL funcionarioBLL = new();
        private readonly UsuarioBLL usuarioBLL = new();

        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\bibliot\usuarios";

        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmConfig()
        {
            InitializeComponent();
        }



        private void txtNome_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioBLL = new UsuarioBLL();

                var usuarioAtualizado = new FuncionarioDTO
                {
                    Nome = txtNome.Text,
                    Usuario = txtUser.Text,
                    Email = txtEmail.Text,
                    CPF = txtSenha.Text,
                    Telefone = txtSenha.Text,
                    Senha = txtSenha.Text,
                    UrlFoto = lblCaminhoFoto.Text
                };

                usuarioBLL.AtualizarUsuario(usuarioAtualizado);
                MessageBox.Show($"Usuário {usuarioAtualizado.Nome} atualizado com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
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

                
                guna2CirclePictureBox1.Image = Image.FromFile(nomeArquivoImagem);

               
                lblCaminhoFoto.Text = nomeArquivoImagem;
            }
        }

        private void btnExcluirConta_Click(object sender, EventArgs e)
        {

        }
    }
}
