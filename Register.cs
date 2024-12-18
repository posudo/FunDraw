using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            string user_email = tbEmail.Text;

            if (string.IsNullOrWhiteSpace(user_email))
            {
                MessageBox.Show("Please enter your email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(user_email, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassword.Text == tbComfirmPassword.Text)
            {
                try
                {
                    if (await Session.Register(tbUsername.Text, tbPassword.Text, tbEmail.Text))
                    {
                        MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
