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

        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\bibliot\usuarios";

        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmConfig()
        {
            InitializeComponent();
        }



        private void txtNome_Click(object sender, EventArgs e)
        {
            txtNome.Text = string.Empty;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioAtualizado = new FuncionarioDTO
                {
                    Id =
                    Nome = txtNome.Text,
                    Usuario = txtUser.Text,
                    Email = txtEmail.Text,
                    CPF = txtSenha.Text,
                    Telefone = txtSenha.Text,
                    Senha = txtSenha.Text,
                    UrlFoto = lblCaminhoFoto.Text
                };

                funcionarioBLL.AtualizarFuncionario(usuarioAtualizado);
                MessageBox.Show($"Usuário {usuarioAtualizado.Nome} atualizado com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Text = string.Empty;
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Text = string.Empty;
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;
        }
    }
}
