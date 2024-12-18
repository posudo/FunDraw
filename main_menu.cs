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

        private async void btDangXuat_Click(object sender, EventArgs e)
        {
            if (await Session.Logout())
            {
                MessageBox.Show("Đăng xuất thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Đăng xuất thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
