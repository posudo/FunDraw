using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunDraw.Types;
namespace FunDraw
{
    public partial class PlayerProfile : Form
    {
        private Size formOriginalSize;
        private Rectangle circle;
        private Rectangle click_pic;
        private Rectangle player;
        private Rectangle playerDisplay;
        private Rectangle id;
        private Rectangle IDDisplay;
        private Rectangle tham_gia;
        private Rectangle thamgiaDisplay;
        private Rectangle email;
        private Rectangle emailDisplay;
        private Rectangle forgot_pass;
 
        public PlayerProfile()
        {
            InitializeComponent();
            formOriginalSize = this.Size;
            circle = new Rectangle(guna2CirclePictureBox1.Location, guna2CirclePictureBox1.Size);
            // click_pic = new Rectangle(Click_pic.Location, Click_pic.Size);
            player = new Rectangle(lbPlayer.Location, lbPlayer.Size);
            playerDisplay = new Rectangle(lbPlayer.Location, lbPlayer.Size);
            id = new Rectangle(label2.Location, label2.Size);
            IDDisplay = new Rectangle(lbID.Location, lbID.Size);
            tham_gia = new Rectangle(label3.Location, label3.Size);
            thamgiaDisplay = new Rectangle(lbJoin.Location, lbJoin.Size);
            email = new Rectangle(label4.Location, label4.Size);
            emailDisplay = new Rectangle(lbEmail.Location, lbEmail.Size);
            forgot_pass = new Rectangle(lbChangePassword.Location, lbChangePassword.Size);

            GetUserProfile();
        }

        private async void GetUserProfile()
        {
            UserProfile userProfile = await Session.GetUserProfile();

            lbPlayer.Text = $"{userProfile.Username}";
            lbID.Text = $"{userProfile.ID}";
            lbJoin.Text = $"{userProfile.JoinedDate:yyyy-MM-dd}";
            lbEmail.Text = $"{userProfile.Email}";
        }

        private void lbChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }
    }
}
