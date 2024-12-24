namespace FunDraw
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lbForgetPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btLogin = new Guna.UI2.WinForms.Guna2Button();
            lbRegister = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Anchor = AnchorStyles.None;
            tbUsername.BorderRadius = 12;
            tbUsername.Cursor = Cursors.IBeam;
            tbUsername.CustomizableEdges = customizableEdges1;
            tbUsername.DefaultText = "";
            tbUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.FillColor = Color.FromArgb(224, 224, 224);
            tbUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.ForeColor = Color.Black;
            tbUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Location = new Point(299, 182);
            tbUsername.Margin = new Padding(4, 5, 4, 5);
            tbUsername.Name = "tbUsername";
            tbUsername.PasswordChar = '\0';
            tbUsername.PlaceholderForeColor = Color.Gainsboro;
            tbUsername.PlaceholderText = "";
            tbUsername.SelectedText = "";
            tbUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbUsername.Size = new Size(289, 39);
            tbUsername.TabIndex = 11;
            tbUsername.Enter += tbUsername_Enter;
            tbUsername.Leave += tbUsername_Leave;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.None;
            tbPassword.BorderRadius = 12;
            tbPassword.Cursor = Cursors.IBeam;
            tbPassword.CustomizableEdges = customizableEdges3;
            tbPassword.DefaultText = "";
            tbPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.FillColor = Color.FromArgb(224, 224, 224);
            tbPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.ForeColor = Color.Black;
            tbPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Location = new Point(299, 250);
            tbPassword.Margin = new Padding(4, 5, 4, 5);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.PlaceholderForeColor = Color.Gainsboro;
            tbPassword.PlaceholderText = "";
            tbPassword.SelectedText = "";
            tbPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbPassword.Size = new Size(289, 39);
            tbPassword.TabIndex = 12;
            // 
            // lbForgetPassword
            // 
            lbForgetPassword.Anchor = AnchorStyles.None;
            lbForgetPassword.BackColor = Color.Transparent;
            lbForgetPassword.Font = new Font("Microsoft Sans Serif", 10F);
            lbForgetPassword.ForeColor = SystemColors.Highlight;
            lbForgetPassword.Location = new Point(299, 304);
            lbForgetPassword.Margin = new Padding(4, 3, 4, 3);
            lbForgetPassword.Name = "lbForgetPassword";
            lbForgetPassword.Size = new Size(111, 18);
            lbForgetPassword.TabIndex = 13;
            lbForgetPassword.Text = "Forgot password?";
            lbForgetPassword.TextAlignment = ContentAlignment.MiddleCenter;
            lbForgetPassword.Click += lbForgetPassword_Click;
            // 
            // btLogin
            // 
            btLogin.Anchor = AnchorStyles.None;
            btLogin.Animated = true;
            btLogin.BorderRadius = 12;
            btLogin.CustomizableEdges = customizableEdges5;
            btLogin.DisabledState.BorderColor = Color.DarkGray;
            btLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btLogin.FillColor = Color.FromArgb(160, 210, 235);
            btLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btLogin.ForeColor = Color.Black;
            btLogin.Location = new Point(373, 353);
            btLogin.Margin = new Padding(4, 3, 4, 3);
            btLogin.Name = "btLogin";
            btLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btLogin.Size = new Size(158, 40);
            btLogin.TabIndex = 14;
            btLogin.Text = "Submit";
            btLogin.Click += btLogin_Click;
            // 
            // lbRegister
            // 
            lbRegister.Anchor = AnchorStyles.None;
            lbRegister.BackColor = Color.Transparent;
            lbRegister.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbRegister.ForeColor = SystemColors.Highlight;
            lbRegister.Location = new Point(484, 412);
            lbRegister.Margin = new Padding(4, 3, 4, 3);
            lbRegister.Name = "lbRegister";
            lbRegister.Size = new Size(63, 22);
            lbRegister.TabIndex = 15;
            lbRegister.Text = "Register";
            lbRegister.TextAlignment = ContentAlignment.MiddleCenter;
            lbRegister.Click += lbRegister_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = SystemColors.WindowText;
            guna2HtmlLabel2.Location = new Point(331, 412);
            guna2HtmlLabel2.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(149, 22);
            guna2HtmlLabel2.TabIndex = 16;
            guna2HtmlLabel2.Text = "Don't have account?";
            guna2HtmlLabel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.fundrawLogo;
            pictureBox1.Location = new Point(0, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(894, 131);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(299, 156);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 18;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(299, 224);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 19;
            label2.Text = "Password";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(894, 440);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(lbRegister);
            Controls.Add(btLogin);
            Controls.Add(lbForgetPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbForgetPassword;
        private Guna.UI2.WinForms.Guna2Button btLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbRegister;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}