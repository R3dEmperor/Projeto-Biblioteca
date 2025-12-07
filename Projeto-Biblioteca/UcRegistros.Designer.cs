namespace Projeto_Biblioteca
{
    partial class UcRegistros
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgRegistros = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            BtnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgRegistros).BeginInit();
            SuspendLayout();
            // 
            // dgRegistros
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgRegistros.ColumnHeadersHeight = 15;
            dgRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgRegistros.DefaultCellStyle = dataGridViewCellStyle3;
            dgRegistros.GridColor = Color.FromArgb(231, 229, 255);
            dgRegistros.Location = new Point(17, 125);
            dgRegistros.Name = "dgRegistros";
            dgRegistros.RowHeadersVisible = false;
            dgRegistros.Size = new Size(745, 293);
            dgRegistros.TabIndex = 3;
            dgRegistros.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgRegistros.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgRegistros.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgRegistros.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgRegistros.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgRegistros.ThemeStyle.BackColor = Color.White;
            dgRegistros.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgRegistros.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgRegistros.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgRegistros.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgRegistros.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgRegistros.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgRegistros.ThemeStyle.HeaderStyle.Height = 15;
            dgRegistros.ThemeStyle.ReadOnly = false;
            dgRegistros.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgRegistros.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgRegistros.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgRegistros.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgRegistros.ThemeStyle.RowsStyle.Height = 25;
            dgRegistros.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgRegistros.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgRegistros.CellContentClick += dgRegistros_CellContentClick;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.SaddleBrown;
            guna2HtmlLabel1.Location = new Point(280, 16);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(215, 57);
            guna2HtmlLabel1.TabIndex = 18;
            guna2HtmlLabel1.Text = "Registros";
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderRadius = 15;
            txtPesquisa.CustomizableEdges = customizableEdges1;
            txtPesquisa.DefaultText = "";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Location = new Point(17, 83);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(584, 36);
            txtPesquisa.TabIndex = 19;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            // 
            // BtnPesquisar
            // 
            BtnPesquisar.BorderRadius = 15;
            BtnPesquisar.CustomizableEdges = customizableEdges3;
            BtnPesquisar.DisabledState.BorderColor = Color.DarkGray;
            BtnPesquisar.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnPesquisar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnPesquisar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnPesquisar.FillColor = Color.SaddleBrown;
            BtnPesquisar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            BtnPesquisar.ForeColor = Color.White;
            BtnPesquisar.Location = new Point(607, 83);
            BtnPesquisar.Name = "BtnPesquisar";
            BtnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            BtnPesquisar.Size = new Size(155, 36);
            BtnPesquisar.TabIndex = 20;
            BtnPesquisar.Text = "Pesquisar";
            BtnPesquisar.Click += btnFinalizar_Click;
            // 
            // UcRegistros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(BtnPesquisar);
            Controls.Add(txtPesquisa);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(dgRegistros);
            Name = "UcRegistros";
            RightToLeft = RightToLeft.No;
            Size = new Size(784, 431);
            Load += UcReserva_Load;
            ((System.ComponentModel.ISupportInitialize)dgRegistros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dgRegistros;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnPesquisa;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button BtnPesquisar;
    }
}
