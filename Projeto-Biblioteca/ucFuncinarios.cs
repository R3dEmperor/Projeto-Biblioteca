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
    public partial class ucFuncinarios : UserControl
    {
        FuncionarioBLL funcionarioBLL = new();
        public ucFuncinarios()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var funcionario = new FuncionarioDTO
            {
                Nome = txtNome.Text,
                DescricaoTipoUsuario = txtTipoUsuario.Text,
                CPF = txtCPF.Text,
                Telefone = txtTelefone.Text,
                Senha = txtSenha.Text,
            };
            funcionarioBLL.CadastrarFuncionario(funcionario);
        }
    }
}
