namespace FunDraw
{
    partial class HoSoNgChoi
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
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lbPlayer = new Label();
            label2 = new Label();
            Click_pic = new Label();
            label3 = new Label();
            label4 = new Label();
            lbChangePassword = new Label();
            lbID = new Label();
            lbJoin = new Label();
            lbEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.BackColor = SystemColors.ButtonHighlight;
            guna2CirclePictureBox1.FillColor = Color.LightGray;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(93, 63);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(163, 164);
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // lbPlayer
            // 
            lbPlayer.AutoSize = true;
            lbPlayer.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPlayer.Location = new Point(319, 63);
            lbPlayer.Name = "lbPlayer";
            lbPlayer.Size = new Size(105, 41);
            lbPlayer.TabIndex = 1;
            lbPlayer.Text = "Player";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(319, 112);
            label2.Name = "label2";
            label2.Size = new Size(35, 28);
            label2.TabIndex = 2;
            label2.Text = "ID:";
            // 
            // Click_pic
            // 
            Click_pic.AutoSize = true;
            Click_pic.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Click_pic.ForeColor = SystemColors.ButtonShadow;
            Click_pic.Location = new Point(52, 251);
            Click_pic.Name = "Click_pic";
            Click_pic.Size = new Size(231, 28);
            Click_pic.TabIndex = 3;
            Click_pic.Text = "Click vào ảnh để thay đổi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(318, 159);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 4;
            label3.Text = "Tham gia:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(318, 205);
            label4.Name = "label4";
            label4.Size = new Size(63, 28);
            label4.TabIndex = 5;
            label4.Text = "Email:";
            // 
            // lbChangePassword
            // 
            lbChangePassword.AutoSize = true;
            lbChangePassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChangePassword.ForeColor = Color.DodgerBlue;
            lbChangePassword.Location = new Point(319, 254);
            lbChangePassword.Name = "lbChangePassword";
            lbChangePassword.Size = new Size(131, 25);
            lbChangePassword.TabIndex = 7;
            lbChangePassword.Text = "Đổi mật khẩu";
            lbChangePassword.Click += lbChangePassword_Click;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Location = new Point(357, 119);
            lbID.Name = "lbID";
            lbID.Size = new Size(57, 20);
            lbID.TabIndex = 8;
            lbID.Text = "            ";
            // 
            // lbJoin
            // 
            lbJoin.AutoSize = true;
            lbJoin.Location = new Point(420, 167);
            lbJoin.Name = "lbJoin";
            lbJoin.Size = new Size(57, 20);
            lbJoin.TabIndex = 9;
            lbJoin.Text = "            ";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(378, 212);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(57, 20);
            lbEmail.TabIndex = 10;
            lbEmail.Text = "            ";
            // 
            // HoSoNgChoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(608, 384);
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
            Name = "HoSoNgChoi";
            Text = "HoSoNgChoi";
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
        private Label lbJoin;
        private Label lbEmail;
    }
}