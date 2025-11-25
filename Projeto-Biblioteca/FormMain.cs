using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Projeto_Biblioteca
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AtualizarUsuarioLogado();
            AbrirUserControl(new UcProduto());
        }

        private void PanelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirUserControl(UserControl uc)
        {
            //Limpa o que tiver no painel
            PanelConteudo.Controls.Clear();

            // Configura o novo User Control
            uc.Dock = DockStyle.Fill;

            PanelConteudo.Controls.Add(uc);
        }
        private void FecharMain()
        {
            Close();
            login telaLogin = new();
            telaLogin.ShowDialog();
        }
        public void AtualizarUsuarioLogado()
        {
            //Centralizar Horizontalmente em relação a pbFoto
            lblFotoCaminho.Left = PbFoto.Left + 4 + (PbFoto.Width - lblFotoCaminho.Width) / 2;
            lblFotoCaminho.Top = PbFoto.Bottom + 4;
        }
    }
}
