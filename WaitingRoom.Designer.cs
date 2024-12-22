namespace FunDraw
{
    partial class WaitingRoom
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingRoom));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            chatBox = new RichTextBox();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            lbWaiting = new Label();
            btInvite = new Guna.UI2.WinForms.Guna2Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            guna2Panel1.BorderRadius = 20;
            guna2Panel1.Controls.Add(chatBox);
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.FillColor = Color.Gainsboro;
            guna2Panel1.ForeColor = SystemColors.AppWorkspace;
            guna2Panel1.Location = new Point(496, 9);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(206, 487);
            guna2Panel1.TabIndex = 0;
            // 
            // chatBox
            // 
            chatBox.BackColor = Color.Gainsboro;
            chatBox.BorderStyle = BorderStyle.None;
            chatBox.Location = new Point(0, 24);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(206, 428);
            chatBox.TabIndex = 2;
            chatBox.Text = "";
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            guna2TextBox1.BorderRadius = 20;
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(76, 175, 80);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(0, 447);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderForeColor = Color.DarkGray;
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(206, 40);
            guna2TextBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 3;
            label1.Text = "ID: %id%";
            // 
            // lbWaiting
            // 
            lbWaiting.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbWaiting.AutoSize = true;
            lbWaiting.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWaiting.ForeColor = SystemColors.ActiveCaptionText;
            lbWaiting.Location = new Point(212, 23);
            lbWaiting.Name = "lbWaiting";
            lbWaiting.Size = new Size(267, 21);
            lbWaiting.TabIndex = 5;
            lbWaiting.Text = "Waiting for host to start the game";
            // 
            // btInvite
            // 
            btInvite.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btInvite.Animated = true;
            btInvite.BackColor = Color.Transparent;
            btInvite.BorderRadius = 12;
            btInvite.CustomizableEdges = customizableEdges5;
            btInvite.DisabledState.BorderColor = Color.DarkGray;
            btInvite.DisabledState.CustomBorderColor = Color.DarkGray;
            btInvite.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btInvite.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btInvite.FillColor = Color.FromArgb(160, 210, 235);
            btInvite.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btInvite.ForeColor = Color.Black;
            btInvite.Location = new Point(245, 61);
            btInvite.Margin = new Padding(4, 3, 4, 3);
            btInvite.Name = "btInvite";
            btInvite.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btInvite.Size = new Size(195, 38);
            btInvite.TabIndex = 26;
            btInvite.Text = "Invite";
            btInvite.Click += btInvite_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(12, 33);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(185, 463);
            flowLayoutPanel1.TabIndex = 38;
            // 
            // WaitingRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(713, 511);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btInvite);
            Controls.Add(lbWaiting);
            Controls.Add(label1);
            Controls.Add(guna2Panel1);
            ForeColor = SystemColors.ControlDark;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "WaitingRoom";
            Text = "Waiting Room";
            Load += WaitingRoom_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label label1;
        private Label lbWaiting;
        private Guna.UI2.WinForms.Guna2Button btInvite;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox chatBox;
    }
}