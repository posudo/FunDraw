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
    public partial class In_Game_Guesser : Form
    {
        public In_Game_Guesser()
        {
            InitializeComponent();
            OnResize(null);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (guna2PictureBox1.Width > 0 && guna2PictureBox1.Height > 0)
            {
                bm = new Bitmap(guna2PictureBox1.Width, guna2PictureBox1.Height);
                g = Graphics.FromImage(bm);
                g.Clear(Color.White);
                guna2PictureBox1.Image = bm;
            }
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog colorDialog = new ColorDialog();
        Color new_Color;
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void guna2PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }

            }
            guna2PictureBox1.Refresh();

            x = e.X;
            y = e.Y;

            sX = e.X - cX;
            sY = e.Y - cY;

        }

        private void guna2PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void Elipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void guna2PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            guna2PictureBox1.Image = bm;
            index = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            new_Color = colorDialog.Color;
            guna2PictureBox1.BackColor = new_Color;
            p.Color = new_Color;
        }
    }
}
