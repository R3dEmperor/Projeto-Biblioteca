using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto_Biblioteca
{
    public partial class UcProduto : UserControl
    {
        ProdutoBLL produtoBLL = new ProdutoBLL();
        public UcProduto()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string Produto = txtProduto.Text;
            string autor = txtAutorProduto.Text;
            string genero = txtGenero.Text;

            string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                string sql = @"INSERT INTO Livros (Titulo, Autor, Genero, Ano, ISBN)
                       VALUES (@titulo, @autor, @genero, @ano, @isbn)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@titulo", Produto);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@genero", genero);
                   
                }
            }

            MessageBox.Show("Livro cadastrado com sucesso!");
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgProdutos.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um livro para atualizar.", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgProdutos.CurrentRow.Cells["Id"].Value);

                string diretorio = Path.Combine(Application.StartupPath, "Imagens");
                if (!Directory.Exists(diretorio))

                    Directory.CreateDirectory(diretorio);



                string Produto = txtProduto.Text;
                string autor = txtAutorProduto.Text;
                string genero = txtGenero.Text;

                string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(conexao))
                {

                    string sql = @"UPDATE Livros 
                       SET Titulo = @titulo, 
                           Autor = @autor, 
                           Genero = @genero, 
                           Ano = @ano, 
                           ISBN = @isbn
                       WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@titulo", Produto);
                        cmd.Parameters.AddWithValue("@autor", autor);
                        cmd.Parameters.AddWithValue("@genero", genero);

                    }
                }

               produtoBLL.AtualizarProduto(new ProdutoDTO
               {
                   IdProduto = id,
                   NomeProduto = Produto,
                   AutorProduto = autor,
                   GeneroProduto = genero
               });

                produtoBLL.AtualizarProduto();

                MessageBox.Show("Livro atualizado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o livro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Livro atualizado com sucesso!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string produto = txtProduto.Text;
            string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(conexao))
            {

                string sql = "DELETE FROM Livros WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", produto);
                }
            }

            MessageBox.Show("Livro excluído com sucesso!");
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

            txtProduto.Text = row.Cells["Titulo"].Value?.ToString();
            txtAutorProduto.Text = row.Cells["Autor"].Value?.ToString();
            txtGenero.Text = row.Cells["Genero"].Value?.ToString();
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

            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Titulo", Name = "Titulo" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Autor", HeaderText = "Autor", Name = "Autor" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genero", HeaderText = "Genero", Name = "Genero" });

            var produtos = produtoBLL.ListarProdutos();

            var dt = new DataTable();

            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Titulo", typeof(string));
            dt.Columns.Add("Autor", typeof(string));
            dt.Columns.Add("Genero", typeof(string));

           dgProdutos.DataSource = dt;

        }
    }
}

