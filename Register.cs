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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Tên đăng nhập")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Tên đăng nhập";
                tbUsername.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Mật khẩu")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Mật khẩu";
                tbPassword.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void tbComfirmPassword_Enter(object sender, EventArgs e)
        {
            if (tbComfirmPassword.Text == "Xác nhận mật khẩu")
            {
                tbComfirmPassword.Text = "";
                tbComfirmPassword.ForeColor = Color.Black;
            }
        }

        private void tbComfirmPassword_Leave(object sender, EventArgs e)
        {
            if (tbComfirmPassword.Text == "")
            {
                tbComfirmPassword.Text = "Xác nhận mật khẩu";
                tbComfirmPassword.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Email";
                tbEmail.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
    }
}
