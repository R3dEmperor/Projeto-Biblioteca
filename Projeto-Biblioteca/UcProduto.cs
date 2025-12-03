using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using NuGet.Packaging.Signing;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto_Biblioteca
{
    public partial class UcProduto : UserControl
    {
        ProdutoBLL produtoBLL = new ProdutoBLL();
        GeneroBLL generoBLL = new GeneroBLL();

        public UcProduto()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var idGenero = 0;
            var listaGeneros = generoBLL.ListarGeneros().Find(x => x.NomeGenero == cboGeneros.Text);
            var listaIds = generoBLL.ListarGeneros().FirstOrDefault(x => x.IdGenero.Equals(listaGeneros.IdGenero));
            idGenero = listaIds.IdGenero;

            var produto = new ProdutoDTO
            {
               NomeProduto = txtProduto.Text,
               AutorProduto = txtProduto.Text,
               GeneroProduto = idGenero,
            };
            produtoBLL.CadastrarProduto(produto);

            MessageBox.Show("Livro cadastrado com sucesso!");
            AtualizarGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            var idgenero = 0;
            var listaGeneros = generoBLL.ListarGeneros().Find(x => x.NomeGenero == cboGeneros.Text);
            var listaIDS = listaGeneros.IdGenero;
            idgenero = listaIDS;
            int id = dgProdutos.SelectedRows[0].Cells["Id_Produto"].Value.GetHashCode();
            try
            {
                if (dgProdutos.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um livro para atualizar.", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                produtoBLL.AtualizarProduto(new ProdutoDTO
                {
                    IdProduto = id,
                    NomeProduto = txtProduto.Text,
                    AutorProduto = txtAutorProduto.Text,
                    GeneroProduto = idgenero,
                });
                MessageBox.Show("Livro atualizado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o livro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Livro atualizado com sucesso!");

            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um livro para excluir");
                return;
            }
            int id = dgProdutos.SelectedRows[0].Cells["Id_Produto"].Value.GetHashCode();

            var Confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o livro " +
                $"{dgProdutos.SelectedRows[0].Cells["Genero_Produto"].Value.ToString()}", "Confirmação", MessageBoxButtons.YesNo);
            if (Confirmacao == DialogResult.Yes)
            {
                produtoBLL.RemoverProduto(id);
                MessageBox.Show("Livro excluido");
            }
            AtualizarGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbCaminhodaFoto.Image = Image.FromFile(ofd.FileName);
                txtCaminhodaFoto.Text = ofd.FileName; // salva o caminho no textbox
            }
        }

        private void txtPesquisarTitulo_TextChanged(object sender, EventArgs e)
        {
            string texto = txtPesquisarTitulo.Text;

            string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conexao))
            {

                string sql = @"SELECT Id, Titulo, Autor, Genero, Ano, ISBN, CaminhoImagem
                       FROM Livros
                       WHERE Titulo LIKE @titulo + '%'";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@titulo", texto);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    dgProdutos.DataSource = dt;
                }
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgProdutos.Rows[e.RowIndex];

            txtProduto.Text = row.Cells["Genero_Produto"].Value?.ToString();
            txtAutorProduto.Text = row.Cells["Autor_Produto"].Value?.ToString();
            cboGeneros.Text = row.Cells["GeneroId_Genero"].Value?.ToString();
        }

        private void AtualizarGrid()
        {


            dgProdutos.Columns.Clear();
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.RowTemplate.Height = 60;
            dgProdutos.AllowUserToAddRows = false;

            var colFoto = new DataGridViewImageColumn
            {
                HeaderText = "Foto",
                Name = "Foto",
                Width = 60,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };

            dgProdutos.Columns.Add(colFoto);
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Produto", HeaderText = "ID", Name = "Id_Produto" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genero_Produto", HeaderText = "Titulo", Name = "Genero_Produto" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Autor_Produto", HeaderText = "Autor", Name = "Autor_Produto" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GeneroId_Genero", HeaderText = "Genero", Name = "GeneroId_Genero" });

            var produtos = produtoBLL.ListarProdutos();

            var dt = new DataTable();

            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Id_Produto", typeof(int));
            dt.Columns.Add("Genero_Produto", typeof(string));
            dt.Columns.Add("Autor_Produto", typeof(string));
            dt.Columns.Add("GeneroId_Genero", typeof(string));

            foreach (var u in produtos)
            {
                var generoid = generoBLL.ListarGeneros().Find(x => x.IdGenero == u.GeneroProduto);
                var genero = generoid.NomeGenero;

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
                dt.Rows.Add(img, u.IdProduto, u.NomeProduto, u.AutorProduto, genero);
            }
            dgProdutos.DataSource = dt;
        }

        private void UcProduto_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
            Atualizarcbo();
        }
        private void Atualizarcbo()
        {
            var lista = generoBLL.ListarGeneros().Select(x => x.NomeGenero).ToList();
            cboGenero.DataSource = lista;
        }
    }
}

