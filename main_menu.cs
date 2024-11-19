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
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(883, 500);
        }

        private void tbMaPhong_Enter(object sender, EventArgs e)
        {
            if (tbMaPhong.Text == "Mã phòng")
            {
                tbMaPhong.Text = "";
                tbMaPhong.ForeColor = Color.Black;
            }
        }

        private void tbMaPhong_Leave(object sender, EventArgs e)
        {
            if (tbMaPhong.Text == "")
            {
                tbMaPhong.Text = "Mã phòng";
                tbMaPhong.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
    }
}
