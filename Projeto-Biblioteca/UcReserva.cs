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
    public partial class UcReserva : UserControl
    {
        RegistroBLL registroBLL = new();
        ProdutoBLL produtoBLL = new();

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
                var registro = new RegistroDTO()
                {
                    DevolucaoRegistro = dtDevolução.Value,
                    ReservaRegistro = Reserva

                };

                registroBLL.CriarRegistro(registro);
                MessageBox.Show("Registro criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar registro: " + ex.Message);
            }
        }

        private void UcRegistro_Load(object sender, EventArgs e)
        {
            dtReserva.Value = DateTime.Today;
            Atualizarcbo();
        }
        private void Conversao()
        {
            var produto = produtoBLL.ListarProdutos().Find(x => x.NomeProduto == cboLivro.Text).IdProduto;
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

        }

        private void dtDevolução_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtReserva_ValueChanged(object sender, EventArgs e)
        {
            dtDevolução.Value = dtReserva.Value.AddDays(14);
        }
    }
}
