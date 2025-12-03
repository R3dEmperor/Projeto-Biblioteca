// FormMain.cs refatorado
using Guna.UI2.WinForms;

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
            panelConteudo.Visible = true;
            panelConteudo.BringToFront();
            AbrirUserControl(new ucFuncinarios());
        }

        private void AbrirUserControl(UserControl uc)
        {
            panelConteudo.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(uc);
            uc.BringToFront();
        }

        private void AtualizarUsuarioLogado()
        {
            //if (AppContexto.LoginAtual != null)
            //{
            //    lblUsuario.Text = AppContexto.LoginAtual.Usuario;
            //}
            //else
            //{
            //    //lblUsuario.Text = "(desconhecido)";
            //}
        }

        private void MostrarMenu(Guna2Button button, Guna2CustomGradientPanel menu)
        {
            menu.Location = new Point(button.Left + button.Width, button.Top);
            menu.Visible = !menu.Visible;
        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            //MostrarMenu(btnCadastros, panelCadastros);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            //MostrarMenu(btnUsuario, panelUsuario);
        }

        private void btnFuncinarios_Click(object sender, EventArgs e)
        {
            AbrirUserControl(new ucFuncinarios());
        }

        private bool isDarkMode = false;

        private void AlternarTema()
        {
            isDarkMode = !isDarkMode;

            Color fundo = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.Bisque;
            Color texto = isDarkMode ? Color.White : Color.Black;

            this.BackColor = fundo;
            //lblUsuario.ForeColor = texto;
            //labelUsuario.ForeColor = texto;
            //btnUsuario.ForeColor = texto;
            //btnCadastros.ForeColor = texto;
            //btnHome.ForeColor = texto;
            //btnTemas.ForeColor = texto;
            //btnSair.ForeColor = texto;
        }

        private void btnTemas_Click(object sender, EventArgs e)
        {
            AlternarTema();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bntProduto_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new UcProduto());
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new ucFuncinarios());
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            var confirmacao = mdConfirma.Show("Tem certeza que deseja encerrar sua sessão?");
            if (confirmacao == DialogResult.Yes)
            {
                Close();
            }
        }

        private void pbConf_Click(object sender, EventArgs e)
        {
            frmConfig config = new();
            config.ShowDialog();
        }

        private void pbdarkmode_Click(object sender, EventArgs e)
        {
            bool isDarkMode = this.BackColor == Color.Bisque;

            if (isDarkMode)
            {
                // --- MODO ESCURO ---
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;

                if (panelConteudo != null)
                    panelConteudo.BackColor = Color.Black;

                pbdarkmode.Image = Properties.Resources.lightmodeprojeto; // ícone para voltar ao claro
            }
            else
            {
                // --- MODO CLARO ---
                this.BackColor = Color.Bisque;
                this.ForeColor = Color.Black;

                if (panelConteudo != null)
                    panelConteudo.BackColor = Color.Bisque;

                pbdarkmode.Image = Properties.Resources.darkmodeprojeto; // ícone para voltar ao escuro
            }

        }
    }
}