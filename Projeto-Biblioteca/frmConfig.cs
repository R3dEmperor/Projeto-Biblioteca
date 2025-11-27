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
    }
}
