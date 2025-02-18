﻿using System;
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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            string new_pass = tbNewPass.Text;
            string confirm = tbConfirm.Text;

            if (string.IsNullOrWhiteSpace(new_pass)|| string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(new_pass!=confirm)
            {
                MessageBox.Show("The passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (await Session.ChangePassword(new_pass))
            {
                MessageBox.Show("Changed password successfully! Please start the app again.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            else MessageBox.Show($"An error has occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
