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

        private async void btRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbComfirmPassword.Text)
            {
                await Session.Register(tbUsername.Text, tbPassword.Text, tbEmail.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Password and Confirm Password do not match");
                return;
            }
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
