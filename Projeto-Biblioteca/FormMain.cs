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
    public partial class FormMAin : Form
    {
        public FormMAin()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AtualizarUsuarioLogado();
            AbrirUserControl(new ucFuncinarios());
        }

        private void PanelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirUserControl(UserControl uc)
        {

            panelConteudo.Controls.Clear();


            uc.Dock = DockStyle.Fill;

            panelConteudo.Controls.Add(uc);
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

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();

            AbrirUserControl(new ucFuncinarios());
        }



        private void bntProduto_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new UcProduto());
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelConteudo_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pbdarkmode_Click(object sender, EventArgs e)
        {

            bool isDarkMode = this.BackColor == Color.FromArgb(32, 32, 32);

            if (isDarkMode)
            {
                // Modo Claro
                this.BackColor = SystemColors.ButtonHighlight;
                this.ForeColor = Color.Black;

                if (PanelConteudo != null)
                    PanelConteudo.BackColor = Color.Bisque;

                pbdarkmode.Image = Properties.Resources.lightmodeprojeto;
            }
            else
            {
                // Modo Escuro
                Color darkBackColor = Color.FromArgb(32, 32, 32);
                Color darkPanelColor = Color.FromArgb(45, 45, 45);

                this.BackColor = darkBackColor;
                this.ForeColor = Color.White;

                if (PanelConteudo != null)
                    PanelConteudo.BackColor = darkPanelColor;

                pbdarkmode.Image = Properties.Resources.darkmodeprojeto;
            }

        }

        private void pbNot_Click(object sender, EventArgs e)
        {

            try
            {
                if (int.TryParse(npNotifica.Text, out int qtdNotifica))
                {
                    if (qtdNotifica > 0)
                    {
                        qtdNotifica--;
                        npNotifica.Text = qtdNotifica > 0 ?
                            qtdNotifica.ToString() : string.Empty;

                        npNotifica.FillColor = qtdNotifica > 0 ?
                            npNotifica.FillColor : Color.Transparent;

                        string mensagem = qtdNotifica > 0 ?
                            "Aqui serão exibidas as notificações" : "Não há notificações";

                        mdNotifica.Show(mensagem);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void pbConf_Click(object sender, EventArgs e)
        {
            //frmConfig config = new();
            //config.ShowDialog();
        }
    }
}
