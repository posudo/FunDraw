using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using FunDraw;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
namespace FunDraw
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            AuthenticateCheck();
        }

        private async void AuthenticateCheck()
        {
            string accessToken = LocalStorage.GetAccessToken();
            if (accessToken != null && accessToken != string.Empty)
            {
                Types.UserProfile profile = await Session.GetUserProfile();
                if (profile != null)
                {
                    Session.username = profile.Username;
                    Session.accessToken = accessToken;

                    FormState.MainMenuForm();
                    this.Close();
                    return;
                }
            }

            LocalStorage.SetAccessToken(string.Empty);
        }

        private void lbForgetPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
        }

        private async void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool login = await Session.Login(username, password);
            if (login)
            {
                FormState.MainMenuForm();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {

        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {

        }
    }
}