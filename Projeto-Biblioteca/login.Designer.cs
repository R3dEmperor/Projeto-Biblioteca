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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            btxClose = new Guna.UI2.WinForms.Guna2CircleButton();
            txtNome = new Guna.UI2.WinForms.Guna2TextBox();
            pbFotoLogin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            CaminhoFoto = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)pbFotoLogin).BeginInit();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.Bisque;
            btnEntrar.BorderColor = Color.Bisque;
            btnEntrar.BorderRadius = 20;
            btnEntrar.CustomizableEdges = customizableEdges9;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEntrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEntrar.FillColor = Color.SaddleBrown;
            btnEntrar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(25, 334);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges10;
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
            btxClose.Location = new Point(245, 0);
            btxClose.Name = "btxClose";
            btxClose.ShadowDecoration.CustomizableEdges = customizableEdges11;
            btxClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btxClose.Size = new Size(30, 23);
            btxClose.TabIndex = 2;
            btxClose.Text = "X";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.Bisque;
            txtNome.BorderRadius = 20;
            txtNome.CustomizableEdges = customizableEdges12;
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
            txtNome.ShadowDecoration.CustomizableEdges = customizableEdges13;
            txtNome.Size = new Size(200, 36);
            txtNome.TabIndex = 3;
            // 
            // pbFotoLogin
            // 
            pbFotoLogin.BackColor = Color.Bisque;
            pbFotoLogin.ImageRotate = 0F;
            pbFotoLogin.Location = new Point(69, 42);
            pbFotoLogin.Name = "pbFotoLogin";
            pbFotoLogin.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pbFotoLogin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pbFotoLogin.Size = new Size(112, 106);
            pbFotoLogin.TabIndex = 4;
            pbFotoLogin.TabStop = false;
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.Bisque;
            txtSenha.BorderRadius = 20;
            txtSenha.CustomizableEdges = customizableEdges15;
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
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtSenha.Size = new Size(200, 36);
            txtSenha.TabIndex = 3;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.TextChanged += txtSenha_TextChanged;
            // 
            // CaminhoFoto
            // 
            CaminhoFoto.Location = new Point(0, 0);
            CaminhoFoto.Name = "CaminhoFoto";
            CaminhoFoto.Size = new Size(100, 23);
            CaminhoFoto.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
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
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
        private Guna.UI2.WinForms.Guna2CircleButton btxClose;
        private Guna.UI2.WinForms.Guna2TextBox txtNome;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbFotoLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;
        private Label CaminhoFoto;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
