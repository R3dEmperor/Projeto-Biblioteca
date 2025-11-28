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

        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Biblioteca\usuarios";

        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";


        FuncionarioBLL funcionarioBLL = new();
        UsuarioBLL usuarioBLL = new();
        private int? FuncionarioSelecionadoId = null;
        int tipousuario;
        public ucFuncinarios()
        {
            InitializeComponent();
        }
        public void conversao()
        {
            if (cboTipoUsuario.Text == "Administrador")
            {
                tipousuario = 1;
            }
            tipousuario = 2;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            conversao();
            var funcionario = new FuncionarioDTO
            {
                Nome = txtNome.Text,
                TipoUsuarioId = tipousuario,
                CPF = txtCPF.Text,
                Telefone = txtTelefone.Text,
                Senha = txtSenha.Text,
            };
            usuarioBLL.CadastrarUsuario(funcionario);

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
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TipoUsuarioId", HeaderText = "Cargo", Name = "TipoUsuarioId" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Endereco_Usuario", HeaderText = "Endereço", Name = "Endereco_Usuario" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone", Name = "Telefone" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Senha_Usuario", HeaderText = "Senha", Name = "Senha_Usuario" });
            dgUsuarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email_Usuario", HeaderText = "Email", Name = "Email_Usuario" });

            var funcionarios = usuarioBLL.ListarUsuarios();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("TipoUsuarioId", typeof(string));
            dt.Columns.Add("Endereco_Usuario", typeof(string));
            dt.Columns.Add("Senha", typeof(string));
            dt.Columns.Add("Email_Usuario", typeof(string));

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
                dt.Rows.Add(img, u.Id, u.Nome,u.TipoUsuarioId, u.Endereco, u.Senha, u.Email);
            }
            dgUsuarios.DataSource = dt;
        }
        private void Atualizarcbo()
        {
            var lista = funcionarioBLL.ListarFuncionarios().Select(x => x.DescricaoTipoUsuario).ToList();
            cboTipoUsuario.DataSource = lista;
        }
        private void ucFuncinarios_Load(object sender, EventArgs e)
        {
            Atualizarcbo();
            AtualizarGrid();
        }
        private void BuscarFuncionarios()
        {
            string termo = txtPesquisa.Text.Trim().ToLower();

            var filtrados = funcionarioBLL.ListarFuncionarios()
                                    .Where(funcionario => funcionario.Nome.ToLower().Contains(termo))
                                    .Select(funcionario => new
                                    {
                                        funcionario.Id,
                                        funcionario.Nome,
                                        funcionario.Senha,
                                        funcionario.Email,
                                        funcionario.Telefone,
                                        funcionario.CPF,
                                        funcionario.UrlFoto

                                    }).ToList();

            dgUsuarios.DataSource = filtrados;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            BuscarFuncionarios();
        }

        private void cboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pbFoto_Click(object sender, EventArgs e)
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

                pbFoto.Image = Image.FromFile(nomeArquivoImagem);

              
                lblCaminhodaFoto.Text = nomeArquivoImagem;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
