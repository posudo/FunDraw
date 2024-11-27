using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunDraw
{
    public partial class HoSoNgChoi : Form
    {
        private Size formOriginalSize;
        private Rectangle circle;
        private Rectangle click_pic;
        private Rectangle player;
        private Rectangle id;
        private Rectangle tham_gia;
        private Rectangle email;
        private Rectangle password;
        private Rectangle forgot_pass;
        public HoSoNgChoi()
        {
            InitializeComponent();
            this.Resize += HoSoNgChoi_Resize;
            formOriginalSize = this.Size;
            circle = new Rectangle(guna2CirclePictureBox1.Location, guna2CirclePictureBox1.Size);
            click_pic = new Rectangle(Click_pic.Location, Click_pic.Size);
            player = new Rectangle(Player.Location, Player.Size);
            id = new Rectangle(label2.Location, label2.Size);
            tham_gia = new Rectangle(label3.Location, label3.Size);
            email = new Rectangle(label4.Location, label4.Size);
            password = new Rectangle(label5.Location, label5.Size);
            forgot_pass = new Rectangle(label6.Location, label6.Size);
        }

        private void resize_control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void HoSoNgChoi_Resize(object sender, EventArgs e)
        {
            resize_control(guna2CirclePictureBox1, circle);
            resize_control(Click_pic, click_pic);
            resize_control(Player, player);
            resize_control(label2, id);
            resize_control(label3, tham_gia);
            resize_control(label4, email);
            resize_control(label5, password);
            resize_control(label6, forgot_pass);
        }

        private void HoSoNgChoi_Load(object sender, EventArgs e)
        {

        }
    }
}
