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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
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
            guna2HtmlLabel2.Location = new Point(235, 79);
            guna2HtmlLabel2.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(276, 46);
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
            guna2HtmlLabel1.Location = new Point(157, 154);
            guna2HtmlLabel1.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(445, 24);
            guna2HtmlLabel1.TabIndex = 18;
            guna2HtmlLabel1.Text = "Một email sẽ được gửi về để bạn có thể đặt lại mật khẩu";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.None;
            tbEmail.BorderRadius = 12;
            tbEmail.Cursor = Cursors.IBeam;
            tbEmail.CustomizableEdges = customizableEdges5;
            tbEmail.DefaultText = "Email";
            tbEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbEmail.FillColor = Color.FromArgb(224, 224, 224);
            tbEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbEmail.Location = new Point(178, 207);
            tbEmail.Margin = new Padding(4, 5, 4, 5);
            tbEmail.Name = "tbEmail";
            tbEmail.PasswordChar = '\0';
            tbEmail.PlaceholderForeColor = Color.Gainsboro;
            tbEmail.PlaceholderText = "";
            tbEmail.SelectedText = "";
            tbEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbEmail.Size = new Size(410, 39);
            tbEmail.TabIndex = 19;
            tbEmail.Enter += tbEmail_Enter;
            tbEmail.Leave += tbEmail_Leave;
            // 
            // btSend
            // 
            btSend.Anchor = AnchorStyles.None;
            btSend.Animated = true;
            btSend.BorderRadius = 12;
            btSend.CustomizableEdges = customizableEdges7;
            btSend.DisabledState.BorderColor = Color.DarkGray;
            btSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSend.FillColor = Color.FromArgb(160, 210, 235);
            btSend.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btSend.ForeColor = Color.Black;
            btSend.Location = new Point(298, 288);
            btSend.Margin = new Padding(4, 3, 4, 3);
            btSend.Name = "btSend";
            btSend.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btSend.Size = new Size(166, 40);
            btSend.TabIndex = 20;
            btSend.Text = "Gửi";
            btSend.Click += btSend_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 408);
            Controls.Add(btSend);
            Controls.Add(tbEmail);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2HtmlLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ForgotPassword";
            Text = "Forgot Password";
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