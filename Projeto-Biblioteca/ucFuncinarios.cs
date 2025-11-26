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
using Projeto_Biblioteca.DAL;
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
            AtualizarGrid();
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

        private void AtualizarGrid()
        {

            dgUsuarios.Columns.Clear();
            dgUsuarios.AutoGenerateColumns = false;
            dgUsuarios.RowTemplate.Height = 60;
            dgUsuarios.AllowUserToAddRows = false;

            var colFoto = new DataGridViewImageColumn
            {
                HeaderText = "Foto",
                Name = "Foto",
                DataPropertyName = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
            };

            dgUsuarios.Columns.Add(colFoto);

            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescricaoTipoUsuario", HeaderText = "DescricaoTipoUsuario", Name = "DescricaoTipoUsuario" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF", Name = "CPF" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone", Name = "Telefone" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha", Name = "Senha" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UrlFoto", HeaderText = "UrlFoto", Name = "UrlFoto" });

            var funcionarios = funcionarioBLL.ListarFuncionarios();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Login", typeof(string));
            dt.Columns.Add("Senha", typeof(string));
            dt.Columns.Add("UrlFoto", typeof(string));

            foreach (var u in funcionarios)
            {
                Image? img = null;

                if (!string.IsNullOrEmpty(u.UrlFoto) && File.Exists(u.UrlFoto))
                {
                    try
                    {
                        using (var fs = new FileStream(u.UrlFoto, FileMode.Open, FileAccess.Read))
                        {
                            img = Image.FromStream(fs);
                        }
                    }
                    catch (Exception)
                    {
                        img = null;
                    }
                }
                dt.Rows.Add(img, u.Id, u.Nome, u.Usuario, u.Senha, u.UrlFoto);
            }
            dgUsuarios.DataSource = dt;
        }

        private void ucFuncinarios_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}
