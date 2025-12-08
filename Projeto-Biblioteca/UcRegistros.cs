using Projeto_Biblioteca.BLL;
using Projeto_Biblioteca.DAL;
using Projeto_Biblioteca.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Biblioteca
{
    public partial class UcRegistros : UserControl
    {
        RegistroBLL registroBLL = new RegistroBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        ProdutoBLL produtoBLL = new ProdutoBLL();
        public UcRegistros()
        {
            InitializeComponent();
        }

        private void UcReserva_Load(object sender, EventArgs e)
        {
            criarregistros();
            AtualizarGrid();
        }
        private void criarregistros()
        {
            var reservas = reservaBLL.ListarReservas();
            foreach (var u in reservas)
            {
                var registros = registroBLL?.ListarRegistros()?.Find(x => x.ReservaRegistro == u.IdReserva)!?.ReservaRegistro ?? 0;
                    if (u.IdReserva != registros)
                    {
                        var registro = new RegistroDTO
                        {
                            ReservaRegistro = u.IdReserva,
                            DevolucaoRegistro = u.DataDevolucao,
                            Devolvido = false,
                        };
                        registroBLL.CriarRegistro(registro);
                    }
            }
        }
        private void AtualizarGrid()
        {
            dgRegistros.Columns.Clear();
            dgRegistros.AutoGenerateColumns = false;
            dgRegistros.RowTemplate.Height = 60;
            dgRegistros.AllowUserToAddRows = false;

            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Genero", HeaderText = "ID", Name = "Id_Genero" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Reserva_Genero", HeaderText = "Id Reserva", Name = "Reserva_Genero" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Devolucao_Registro", HeaderText = "Data de devolução", Name = "Devolucao_Registro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Cliente", HeaderText = "Cliente", Name = "Nome_Cliente" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Livro", HeaderText = "Livro", Name = "Nome_Livro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Autor", HeaderText = "Autor", Name = "Nome_Autor" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Devolvido", HeaderText = "Devolução", Name = "Devolvido" });

            var produtos = registroBLL.ListarRegistros();

            var dt = new DataTable();

            dt.Columns.Add("Id_Genero", typeof(int));
            dt.Columns.Add("Reserva_Genero", typeof(int));
            dt.Columns.Add("Nome_Cliente", typeof(string));
            dt.Columns.Add("Nome_Livro", typeof(string));
            dt.Columns.Add("Nome_Autor", typeof(string));
            dt.Columns.Add("Devolucao_Registro", typeof(DateTime));
            dt.Columns.Add("Devolvido", typeof(string));

            foreach (var u in produtos)
            {
                string devolucao = "Devendo devolução";
                if (u.Devolvido == true)
                {
                    devolucao = "Devolvido";
                }

                string Nome_Cliente;
                Nome_Cliente = reservaBLL.ListarReservas().Find(x => x.IdReserva == u.ReservaRegistro).UsuarioReserva;
                int Id_Livro;
                Id_Livro = reservaBLL.ListarReservas().Find(x => x.IdReserva == u.ReservaRegistro).ProdutoReserva;
                string Nome_Livro;
                Nome_Livro = produtoBLL.ListarProdutos().Find(x => x.IdProduto == Id_Livro).NomeProduto;
                string Nome_Autor;
                Nome_Autor = produtoBLL.ListarProdutos().Find(x => x.IdProduto == Id_Livro).AutorProduto;

                dt.Rows.Add(u.IdRegistro, u.ReservaRegistro, Nome_Cliente, Nome_Livro, Nome_Autor, u.DevolucaoRegistro, devolucao);
            }
            dgRegistros.DataSource = dt;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == null)
            {
                AtualizarGrid();
            }
        }
        private void BuscarRegistro()
        {
            dgRegistros.Columns.Clear();
            string termo = txtPesquisa.Text.Trim().ToLower();
            var filtro = reservaBLL.ListarReservas().Find(x => x.UsuarioReserva.ToString() == termo).IdReserva;
            var filtrados = registroBLL.ListarRegistros().Where(x => x.ReservaRegistro == filtro).ToList();

            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdRegistro", HeaderText = "ID", Name = "IdRegistro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReservaRegistro", HeaderText = "Id Reserva", Name = "ReservaRegistro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Cliente", HeaderText = "Cliente", Name = "Nome_Cliente" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Livro", HeaderText = "Livro", Name = "Nome_Livro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome_Autor", HeaderText = "Autor", Name = "Nome_Autor" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DevolucaoRegistro", HeaderText = "Data de devolução", Name = "DevolucaoRegistro" });
            dgRegistros.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Devolvido", HeaderText = "Devolução", Name = "Devolvido" });

            var dt = new DataTable();

            dt.Columns.Add("IdRegistro", typeof(int));
            dt.Columns.Add("ReservaRegistro", typeof(int));
            dt.Columns.Add("Nome_Cliente", typeof(string));
            dt.Columns.Add("Nome_Livro", typeof(string));
            dt.Columns.Add("Nome_Autor", typeof(string));
            dt.Columns.Add("DevolucaoRegistro", typeof(DateTime));
            dt.Columns.Add("Devolvido", typeof(bool));

            foreach (var u in filtrados)
            {
                string Nome_Cliente;
                Nome_Cliente = reservaBLL.ListarReservas().Find(x => x.IdReserva == u.ReservaRegistro).UsuarioReserva;
                int Id_Livro;
                Id_Livro = reservaBLL.ListarReservas().Find(x => x.IdReserva == u.ReservaRegistro).ProdutoReserva;
                string Nome_Livro;
                Nome_Livro = produtoBLL.ListarProdutos().Find(x => x.IdProduto == Id_Livro).NomeProduto;
                string Nome_Autor;
                Nome_Autor = produtoBLL.ListarProdutos().Find(x => x.IdProduto == Id_Livro).AutorProduto;

                dt.Rows.Add(u.IdRegistro, u.ReservaRegistro, Nome_Cliente, Nome_Livro, Nome_Autor, u.DevolucaoRegistro, u.Devolvido);
            }
            dgRegistros.DataSource = dt;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            BuscarRegistro();
        }

        private void btnFinalizar_Click_1(object sender, EventArgs e)
        {

        }

        private void dgRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
