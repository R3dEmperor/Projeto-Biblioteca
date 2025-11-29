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
            bool isDarkMode = this.BackColor == Color.Bisque;

            if (isDarkMode)
            {
                // --- MODO ESCURO ---
                this.BackColor = Color.FromArgb(12, 13, 10);
                this.ForeColor = Color.White;

                if (panelConteudo != null)
                    panelConteudo.BackColor = Color.FromArgb(12, 13, 10);

                pbdarkmode.Image = Properties.Resources.lightmodeprojeto; // ícone para voltar ao claro
            }
            else
            {
                // --- MODO CLARO ---
                this.BackColor = Color.Bisque;
                this.ForeColor = Color.FromArgb(12, 13, 10);

                if (panelConteudo != null)
                    panelConteudo.BackColor = Color.Bisque;

                pbdarkmode.Image = Properties.Resources.darkmodeprojeto; // ícone para voltar ao escuro
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
            frmConfig config = new();
            config.ShowDialog();
        }
    }
}
