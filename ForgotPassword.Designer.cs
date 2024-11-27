namespace FunDraw
{
    partial class ForgotPassword
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
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            tbEmail = new Guna.UI2.WinForms.Guna2TextBox();
            btSend = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Microsoft Sans Serif", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = SystemColors.WindowText;
            guna2HtmlLabel2.Location = new Point(269, 105);
            guna2HtmlLabel2.Margin = new Padding(5, 4, 5, 4);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(335, 56);
            guna2HtmlLabel2.TabIndex = 17;
            guna2HtmlLabel2.Text = "Quên mật khẩu\r\n";
            guna2HtmlLabel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.None;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.WindowText;
            guna2HtmlLabel1.Location = new Point(142, 205);
            guna2HtmlLabel1.Margin = new Padding(5, 4, 5, 4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(592, 31);
            guna2HtmlLabel1.TabIndex = 18;
            guna2HtmlLabel1.Text = "Một email sẽ được gửi về để bạn có thể đặt lại mật khẩu";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.None;
            tbEmail.BorderRadius = 12;
            tbEmail.Cursor = Cursors.IBeam;
            tbEmail.CustomizableEdges = customizableEdges1;
            tbEmail.DefaultText = "Email";
            tbEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbEmail.FillColor = Color.FromArgb(224, 224, 224);
            tbEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbEmail.Location = new Point(204, 276);
            tbEmail.Margin = new Padding(5, 7, 5, 7);
            tbEmail.Name = "tbEmail";
            tbEmail.PasswordChar = '\0';
            tbEmail.PlaceholderForeColor = Color.Gainsboro;
            tbEmail.PlaceholderText = "";
            tbEmail.SelectedText = "";
            tbEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbEmail.Size = new Size(468, 52);
            tbEmail.TabIndex = 19;
            // 
            // btSend
            // 
            btSend.Anchor = AnchorStyles.None;
            btSend.Animated = true;
            btSend.BorderRadius = 12;
            btSend.CustomizableEdges = customizableEdges3;
            btSend.DisabledState.BorderColor = Color.DarkGray;
            btSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSend.FillColor = Color.FromArgb(160, 210, 235);
            btSend.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btSend.ForeColor = Color.Black;
            btSend.Location = new Point(341, 384);
            btSend.Margin = new Padding(5, 4, 5, 4);
            btSend.Name = "btSend";
            btSend.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btSend.Size = new Size(190, 53);
            btSend.TabIndex = 20;
            btSend.Text = "Gửi";
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 544);
            Controls.Add(btSend);
            Controls.Add(tbEmail);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2HtmlLabel2);
            Name = "ForgotPassword";
            Text = "ForgotPasswordcs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox tbEmail;
        private Guna.UI2.WinForms.Guna2Button btSend;
    }
}