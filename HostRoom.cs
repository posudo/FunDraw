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
    public partial class HostRoom : Form
    {
        public HostRoom()
        {
            InitializeComponent();


        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void tbCustom_Enter(object sender, EventArgs e)
        {
            if (tbCustom.Text == "Minimum of 10 words. 1-32 characters per word! 20000 characters maximum. Separated by a, (comma)")
            {
                tbCustom.Text = "";
                tbCustom.ForeColor = Color.Black;
            }
        }

        private void tbCustom_Leave(object sender, EventArgs e)
        {
            if (tbCustom.Text == "")
            {
                tbCustom.Text = "Minimum of 10 words. 1-32 characters per word! 20000 characters maximum. Separated by a, (comma)";
                tbCustom.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void btInvite_Click(object sender, EventArgs e)
        {

        }
    }
}
