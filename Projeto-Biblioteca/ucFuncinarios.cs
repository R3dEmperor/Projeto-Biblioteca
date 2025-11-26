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
        private int? FuncionarioSelecionadoId = null;
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

            MessageBox.Show($"Usuário {funcionario.Nome} cadastrado com sucesso!");
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgUsuarios.Rows[e.RowIndex];
                var dataRow = row.DataBoundItem as DataRowView;

                if (dataRow != null)
                {
                    FuncionarioSelecionadoId = Convert.ToInt32(dataRow["Id"]);
                    txtNome.Text = dataRow["Nome"].ToString();
                    txtCPF.Text = dataRow["CPF"].ToString();
                    txtSenha.Text = dataRow["Senha"].ToString();
                    lblCaminhodaFoto.Text = dataRow["UrlFoto"].ToString();


                    string caminho = dataRow["UrlFoto"].ToString();


                    pbFoto.Image = (!string.IsNullOrWhiteSpace(caminho) && File.Exists(caminho))
                        ? Image.FromFile(caminho)
                        : Properties.Resources.Icone;

                    btnAtualizar.Enabled = true;
                }
            }
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
