using Humanizer;
using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using NuGet.Versioning;
using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Biblioteca
{
    public partial class UcReserva : UserControl
    {
        ProdutoBLL produtoBLL = new();
        ReservaBLL reservaBLL = new();
        RegistroBLL registroBLL = new();
        int idregistro;
        public UcReserva()
        {
            InitializeComponent();
        }
        int Reserva;

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Conversao();
            try
            {
                var reserva = new ReservaDTO()
                {
                    ProdutoReserva = Reserva,
                    UsuarioReserva = txtUser.Text,
                    DataDevolucao = dtDevolução.Value,
                    DataReserva = dtReserva.Value,       
                };
                reservaBLL.CriarReserva(reserva);

                MessageBox.Show("Registro criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar registro: " + ex.Message);
            }
            AtualizarGrid();
        }


        private void UcRegistro_Load(object sender, EventArgs e)
        {
            dtReserva.Value = DateTime.Today;
            Atualizarcbo();
            AtualizarGrid();
        }
        private void AtualizarGrid()
        {
            dgRegistro.Columns.Clear();
            dgRegistro.AutoGenerateColumns = false;
            dgRegistro.RowTemplate.Height = 60;
            dgRegistro.AllowUserToAddRows = false;

            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdReserva", HeaderText = "ID", Name = "IdReserva" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_CLiente", HeaderText = "Cliente", Name = "Nome_Cliente" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataReserva", HeaderText = "Data da reserva", Name = "DataReserva" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Devolução", Name = "DataDevolucao" });

            var Reservas = reservaBLL.ListarReservas();

            var dt = new DataTable();

            dt.Columns.Add("IdReserva", typeof(int));
            dt.Columns.Add("Nome_CLiente", typeof(string));
            dt.Columns.Add("DataReserva", typeof(DateTime));
            dt.Columns.Add("DataDevolucao", typeof(DateTime));

            foreach (var u in Reservas)
            {
                dt.Rows.Add(u.IdReserva, u.UsuarioReserva, u.DataReserva, u.DataDevolucao);
            }
            dgRegistro.DataSource = dt;
        }
        private void Conversao()
        {
            var produto = produtoBLL.ListarProdutos().FirstOrDefault(x => x.NomeProduto == cboLivro.Text).IdProduto;
            Reserva = produto;
        }
        private void Atualizarcbo()
        {
            var lista = produtoBLL.ListarProdutos().Select(x => x.NomeProduto).ToList();
            cboLivro.DataSource = lista;
            cboLivro.StartIndex = 0;
        }
        private void dgRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistro();
            if (txtPesquisa.Text == null)
            {
                AtualizarGrid();
            }
        }
        private void BuscarRegistro()
        {
            dgRegistro.Columns.Clear();
            string termo = txtPesquisa.Text.Trim().ToLower();

            var filtrados = reservaBLL.ListarReservas()
                                    .Where(funcionario => funcionario.UsuarioReserva.ToLower().Contains(termo))
                                    .Select(funcionario => new
                                    {
                                        funcionario.IdReserva,
                                        funcionario.UsuarioReserva,
                                        funcionario.DataReserva,
                                        funcionario.DataDevolucao,
                                    }).ToList();
            var dt = new DataTable();
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdReserva", HeaderText = "ID", Name = "IdReserva" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UsuarioReserva", HeaderText = "Cliente", Name = "UsuarioReserva" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataReserva", HeaderText = "Data da reserva", Name = "DataReserva" });
            dgRegistro.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Genero", Name = "DataDevolucao" });

            dt.Columns.Add("IdReserva", typeof(int));
            dt.Columns.Add("Nome_CLiente", typeof(string));
            dt.Columns.Add("DataReserva", typeof(DateTime));
            dt.Columns.Add("DataDevolucao", typeof(DateTime));

            foreach (var u in filtrados)
            {
                dt.Rows.Add(u.IdReserva, u.UsuarioReserva, u.DataReserva, u.DataDevolucao);
            }
            dgRegistro.DataSource = filtrados;
        }
        private void dtDevolução_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtReserva_ValueChanged(object sender, EventArgs e)
        {
            dtDevolução.Value = dtReserva.Value.AddDays(14);

        }
        private void dgRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgRegistro.Rows[e.RowIndex];

                idregistro = Convert.ToInt32(row.Cells["IdReserva"].Value);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (idregistro == null)
            {
                MessageBox.Show("Selecione uma reserva na tabela.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var atualizar = registroBLL.ListarRegistros().FirstOrDefault(x=>x.ReservaRegistro== idregistro);
            var registro = new RegistroDTO
            {
                IdRegistro = atualizar.IdRegistro,
                DevolucaoRegistro = DateTime.Today,
                Devolvido = true,
                ReservaRegistro = idregistro
            };
            registroBLL.AtualizarRegistro(registro);
        }
    }
}
