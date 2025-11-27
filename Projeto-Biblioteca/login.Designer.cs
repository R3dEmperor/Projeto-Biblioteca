namespace Projeto_Biblioteca
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            btxClose = new Guna.UI2.WinForms.Guna2CircleButton();
            txtNome = new Guna.UI2.WinForms.Guna2TextBox();
            pbFotoLogin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            CaminhoFoto = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFotoLogin).BeginInit();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.Bisque;
            btnEntrar.BorderColor = Color.Bisque;
            btnEntrar.BorderRadius = 20;
            btnEntrar.CustomizableEdges = customizableEdges1;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEntrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEntrar.FillColor = Color.SaddleBrown;
            btnEntrar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(25, 334);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEntrar.Size = new Size(200, 45);
            btnEntrar.TabIndex = 1;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btxClose
            // 
            btxClose.DisabledState.BorderColor = Color.DarkGray;
            btxClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btxClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btxClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btxClose.FillColor = Color.SaddleBrown;
            btxClose.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btxClose.ForeColor = Color.White;
            btxClose.Location = new Point(242, 0);
            btxClose.Name = "btxClose";
            btxClose.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btxClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btxClose.Size = new Size(35, 32);
            btxClose.TabIndex = 2;
            btxClose.Text = "X";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.Bisque;
            txtEmail.BorderRadius = 20;
            txtEmail.CustomizableEdges = customizableEdges4;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(25, 214);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtEmail.Size = new Size(200, 36);
            txtEmail.TabIndex = 3;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.Bisque;
            txtNome.BorderRadius = 20;
            txtNome.CustomizableEdges = customizableEdges4;
            txtNome.DefaultText = "";
            txtNome.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNome.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNome.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNome.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNome.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Location = new Point(25, 207);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.SelectedText = "";
            txtNome.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtNome.Size = new Size(200, 36);
            txtNome.TabIndex = 3;
            // 
            // pbFotoLogin
            // 
            pbFotoLogin.BackColor = Color.Bisque;
            pbFotoLogin.ImageRotate = 0F;
            pbFotoLogin.Location = new Point(69, 42);
            pbFotoLogin.Name = "pbFotoLogin";
            pbFotoLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pbFotoLogin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pbFotoLogin.Size = new Size(116, 100);
            pbFotoLogin.TabIndex = 4;
            pbFotoLogin.TabStop = false;
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.Bisque;
            txtSenha.BorderRadius = 20;
            txtSenha.CustomizableEdges = customizableEdges7;
            txtSenha.DefaultText = "";
            txtSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Font = new Font("Segoe UI", 9F);
            txtSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Location = new Point(25, 271);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderText = "Senha";
            txtSenha.SelectedText = "";
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSenha.Size = new Size(200, 36);
            txtSenha.TabIndex = 3;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.TextChanged += txtSenha_TextChanged;
            // 
            // CaminhoFoto
            // 
            PbFundo.BackColor = Color.Bisque;
            PbFundo.Location = new Point(2, -3);
            PbFundo.Name = "PbFundo";
            PbFundo.Size = new Size(532, 415);
            PbFundo.TabIndex = 5;
            PbFundo.TabStop = false;
            PbFundo.Click += PbFundo_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(277, 415);
            Controls.Add(CaminhoFoto);
            Controls.Add(pbFotoLogin);
            Controls.Add(txtNome);
            Controls.Add(txtSenha);
            Controls.Add(btxClose);
            Controls.Add(btnEntrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "login";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbFotoLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
        private Guna.UI2.WinForms.Guna2CircleButton btxClose;
        private Guna.UI2.WinForms.Guna2TextBox txtNome;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbFotoLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;
        private Label CaminhoFoto;
    }
}
