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

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string sql = @"INSERT INTO Livros (Titulo, Autor, Genero, Ano, ISBN)
                       VALUES (@titulo, @autor, @genero, @ano, @isbn)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", Produto);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@genero", genero);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Livro cadastrado com sucesso!");
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string Produto = txtProduto.Text;
            string autor = txtAutorProduto.Text;
            string genero = txtGenero.Text;

            string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                string sql = @"UPDATE Livros 
                       SET Titulo = @titulo, 
                           Autor = @autor, 
                           Genero = @genero, 
                           Ano = @ano, 
                           ISBN = @isbn
                       WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", Produto);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@genero", genero);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Livro atualizado com sucesso!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Produto = int.Parse(txtProduto.Text);

            string conexao = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                string sql = "DELETE FROM Livros WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Produto);
                    cmd.ExecuteNonQuery();
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

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                string sql = @"SELECT Id, Titulo, Autor, Genero, Ano, ISBN, CaminhoImagem
                       FROM Livros
                       WHERE Titulo LIKE @titulo + '%'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", texto);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataGridView.DataSource = dt;
                }
            }
        }
    }
}

