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
    public partial class UcGenero : UserControl
    {
        GeneroBLL generoBLL = new GeneroBLL();
        private int? usuarioselecionadoid = null;
        public UcGenero()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            var genero = new GeneroDTO
            {
                NomeGenero = txtGenero.Text,
                ClassificacaoGenero = cboClassificacao.Text,
            };
            generoBLL.CadastrarGenero(genero);

            MessageBox.Show($"Genero {genero.NomeGenero} cadastrado com sucesso!");
            AtualizarDataGrid();
        }

        private void UcGenero_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {


            DgGenero.Columns.Clear();
            DgGenero.AutoGenerateColumns = false;
            DgGenero.RowTemplate.Height = 60;
            DgGenero.AllowUserToAddRows = false;

            DgGenero.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Genero", HeaderText = "ID", Name = "Id_Genero" });
            DgGenero.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descricao_Genero", HeaderText = "Nome", Name = "Descricao_Genero" });
            DgGenero.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Classificacao_Genero", HeaderText = "Genero", Name = "Classificacao_Genero" });

            var Generos = generoBLL.ListarGeneros();

            var dt = new DataTable();
            dt.Columns.Add("Id_Genero", typeof(int));
            dt.Columns.Add("Descricao_Genero", typeof(string));
            dt.Columns.Add("Classificacao_Genero", typeof(string));

            foreach (var u in Generos)
            {
                dt.Rows.Add(u.IdGenero, u.NomeGenero, u.ClassificacaoGenero);
            }
            DgGenero.DataSource = dt;
        }
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgGenero.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um usuário na tabela.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(DgGenero.CurrentRow.Cells["Id_Genero"].Value);

                GeneroDTO Genero = new GeneroDTO
                {
                    IdGenero = id,
                    NomeGenero = txtGenero.Text,
                    ClassificacaoGenero = cboClassificacao.Text,
                };

                generoBLL.AtualizarProduto(Genero);

                MessageBox.Show("Funcionario atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar Funcionario: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (DgGenero.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um genero para excluir");
                return;
            }

            int id = Convert.ToInt32(DgGenero.SelectedRows[0].Cells["Id_Genero"].Value);
            string nome = DgGenero.SelectedRows[0].Cells["Descricao_Genero"].Value.ToString();

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o genero {nome}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                generoBLL.RemoverGenero(id);
                MessageBox.Show($"Genero {nome} removido com sucesso!");
                AtualizarDataGrid();
            }
        }
        private void BuscarGenero()
        {
            string termo = txtPesquisa.Text.Trim().ToLower();

            var filtrado = generoBLL.ListarGeneros().Where(Genero => Genero.NomeGenero.Trim().ToLower().Contains(termo))
                .Select(Genero => new
                {
                    Genero.IdGenero,
                    Genero.NomeGenero,
                    Genero.ClassificacaoGenero
                }).ToList();
            DgGenero.DataSource = filtrado;
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            BuscarGenero();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarGenero();
        }

        private void DgGenero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgGenero.Rows[e.RowIndex];

                usuarioselecionadoid = Convert.ToInt32(row.Cells["Id_Genero"].Value);
                txtGenero.Text = row.Cells["Descricao_Genero"].Value.ToString();
                cboClassificacao.Text = row.Cells["Classificacao_Genero"].Value.ToString();
                BtnAtualizar.Enabled = true;
            }
        }
    }
}
