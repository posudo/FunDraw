namespace FunDraw
{
    partial class PlayerProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerProfile));
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lbPlayer = new Label();
            label2 = new Label();
            Click_pic = new Label();
            label3 = new Label();
            label4 = new Label();
            lbChangePassword = new Label();
            lbID = new Label();
            lbEmail = new Label();
            lbJoin = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.BackColor = SystemColors.ButtonHighlight;
            guna2CirclePictureBox1.FillColor = Color.LightGray;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(81, 47);
            guna2CirclePictureBox1.Margin = new Padding(3, 2, 3, 2);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(143, 123);
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // lbPlayer
            // 
            lbPlayer.AutoSize = true;
            lbPlayer.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPlayer.Location = new Point(279, 47);
            lbPlayer.Name = "lbPlayer";
            lbPlayer.Size = new Size(85, 32);
            lbPlayer.TabIndex = 1;
            lbPlayer.Text = "Player";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(279, 84);
            label2.Name = "label2";
            label2.Size = new Size(28, 21);
            label2.TabIndex = 2;
            label2.Text = "ID:";
            // 
            // Click_pic
            // 
            Click_pic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Click_pic.AutoSize = true;
            Click_pic.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Click_pic.ForeColor = SystemColors.ButtonShadow;
            Click_pic.Location = new Point(63, 189);
            Click_pic.Name = "Click_pic";
            Click_pic.Size = new Size(183, 21);
            Click_pic.TabIndex = 3;
            Click_pic.Text = "Click vào ảnh để thay đổi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(278, 119);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 4;
            label3.Text = "Tham gia:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(278, 154);
            label4.Name = "label4";
            label4.Size = new Size(51, 21);
            label4.TabIndex = 5;
            label4.Text = "Email:";
            // 
            // lbChangePassword
            // 
            lbChangePassword.AutoSize = true;
            lbChangePassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChangePassword.ForeColor = Color.DodgerBlue;
            lbChangePassword.Location = new Point(279, 190);
            lbChangePassword.Name = "lbChangePassword";
            lbChangePassword.Size = new Size(103, 20);
            lbChangePassword.TabIndex = 7;
            lbChangePassword.Text = "Đổi mật khẩu";
            lbChangePassword.Click += lbChangePassword_Click;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbID.Location = new Point(313, 85);
            lbID.Name = "lbID";
            lbID.Size = new Size(25, 20);
            lbID.TabIndex = 8;
            lbID.Text = "ID";
            // 
            // lbEmail
            // 
            lbEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(361, 120);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(92, 21);
            lbEmail.TabIndex = 0;
            lbEmail.Text = "Day";
            // 
            // lbJoin
            // 
            lbJoin.AutoSize = true;
            lbJoin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbJoin.ForeColor = SystemColors.ActiveCaptionText;
            lbJoin.Location = new Point(335, 155);
            lbJoin.Name = "lbJoin";
            lbJoin.Size = new Size(47, 20);
            lbJoin.TabIndex = 7;
            lbJoin.Text = "Email";
            // 
            // HoSoNgChoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(536, 274);
            Controls.Add(lbEmail);
            Controls.Add(lbJoin);
            Controls.Add(lbID);
            Controls.Add(lbChangePassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Click_pic);
            Controls.Add(label2);
            Controls.Add(lbPlayer);
            Controls.Add(guna2CirclePictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "HoSoNgChoi";
            Text = "User Profile";
            Load += HoSoNgChoi_Load;
            Resize += HoSoNgChoi_Resize;
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Label lbPlayer;
        private Label label2;
        private Label Click_pic;
        private Label label3;
        private Label label4;
        private Label lbChangePassword;
        private Label lbID;
        private Label lbEmail;
        private Label lbJoin;
    }
}