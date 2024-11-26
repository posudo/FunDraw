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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            Player = new Label();
            label2 = new Label();
            Click_pic = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
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
            // Player
            // 
            Player.AutoSize = true;
            Player.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Player.Location = new Point(279, 47);
            Player.Name = "Player";
            Player.Size = new Size(85, 32);
            Player.TabIndex = 1;
            Player.Text = "Player";
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
            Click_pic.AutoSize = true;
            Click_pic.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Click_pic.ForeColor = SystemColors.ButtonShadow;
            Click_pic.Location = new Point(72, 188);
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(278, 188);
            label5.Name = "label5";
            label5.Size = new Size(78, 21);
            label5.TabIndex = 6;
            label5.Text = "Mật khẩu:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DodgerBlue;
            label6.Location = new Point(369, 190);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 7;
            label6.Text = "Đổi mật khẩu";
            // 
            // HoSoNgChoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(584, 283);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Click_pic);
            Controls.Add(label2);
            Controls.Add(Player);
            Controls.Add(guna2CirclePictureBox1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label Player;
        private Label label2;
        private Label Click_pic;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}