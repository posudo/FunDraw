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
    public partial class ForgotPassword : Form
    {
        private string _OTP = "";
        private string _Email = "";

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void btSend_Click(object sender, EventArgs e)
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
            try
            {
                if (await Session.ForgotPassword(user_email))
                {
                    _Email = user_email;
                    hideEmail.BringToFront();
                    hideOTP.SendToBack();
                }
                else MessageBox.Show($"Email not found. Please check the email address and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            _OTP = tbOTP.Text.Trim();

            hideOTP.BringToFront();
            hidePassword.SendToBack();
        }

        private async void btnPassword_Click(object sender, EventArgs e)
        {
            string password = tbPassword.Text;
            string confirm_password = tbConfirm.Text;

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm_password))
            {
                MessageBox.Show("Please enter your new password and confirm it.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (await Session.PasswordOTP(_Email, _OTP, password, confirm_password))
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("An error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tbOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
