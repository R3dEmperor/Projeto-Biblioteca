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

                int id = Convert.ToInt32(DgGenero.CurrentRow.Cells["Id"].Value);

                GeneroDTO usuario = new GeneroDTO
                {
                    IdGenero = id,
                    NomeGenero = txtGenero.Text,
                    ClassificacaoGenero = cboClassificacao.Text,
                };

                generoBLL.CadastrarGenero(usuario);

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
                MessageBox.Show("Selecione um aluno para excluir");
                return;
            }

            int id = Convert.ToInt32(DgGenero.SelectedRows[0].Cells["Id"].Value);
            string nome = DgGenero.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o aluno {nome}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                generoBLL.RemoverGenero(id);
                MessageBox.Show($"Usuário {nome} removido com sucesso!");
                AtualizarDataGrid();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }
    }
}
