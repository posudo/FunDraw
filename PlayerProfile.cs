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
        private Types.UserProfile userProfile;
        public PlayerProfile(Types.UserProfile? profile = null)
        {
            InitializeComponent();
            this.Resize += HoSoNgChoi_Resize;
            formOriginalSize = this.Size;
            circle = new Rectangle(guna2CirclePictureBox1.Location, guna2CirclePictureBox1.Size);
            click_pic = new Rectangle(Click_pic.Location, Click_pic.Size);
            player = new Rectangle(lbPlayer.Location, lbPlayer.Size);
            playerDisplay = new Rectangle(lbPlayer.Location, lbPlayer.Size);
            id = new Rectangle(label2.Location, label2.Size);
            IDDisplay = new Rectangle(lbID.Location, lbID.Size);
            tham_gia = new Rectangle(label3.Location, label3.Size);
            thamgiaDisplay = new Rectangle(lbJoin.Location, lbJoin.Size);
            email = new Rectangle(label4.Location, label4.Size);
            emailDisplay = new Rectangle(lbEmail.Location, lbEmail.Size);
            forgot_pass = new Rectangle(lbChangePassword.Location, lbChangePassword.Size);
            userProfile = profile ?? new Types.UserProfile
            {
                Username = "Người chơi mặc định",
                ID = "0000",
                JoinedDate = DateTime.Now,
                Email = "default@example.com"
            };
            LoadUserProfile();
        }
        private void LoadUserProfile()
        {
            lbPlayer.Text = $"{userProfile.Username}";
            lbID.Text = $"{userProfile.ID}";
            lbJoin.Text = $"{userProfile.JoinedDate:yyyy-MM-dd}";
            lbEmail.Text = $"{userProfile.Email}";
        }
        private async void UpdateUserProfile()
        {
            try
            {
                userProfile = await Session.GetUserProfile();
                LoadUserProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể cập nhật hồ sơ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HoSoNgChoi_Load(object sender, EventArgs e)
        {
            _ = InitializeUserProfileAsync();
        }
        private async Task InitializeUserProfileAsync()
        {
            await FetchUserProfile();
        }
        private void resize_control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
        private void HoSoNgChoi_Resize(object? sender, EventArgs e)
        {
            resize_control(guna2CirclePictureBox1, circle);
            resize_control(Click_pic, click_pic);
            resize_control(lbPlayer, player);
            resize_control(lbPlayer, playerDisplay);
            resize_control(label2, id);
            resize_control(lbID, IDDisplay);
            resize_control(label3, tham_gia);
            resize_control(lbJoin, thamgiaDisplay);
            resize_control(label4, email);
            resize_control(lbEmail, emailDisplay);
            resize_control(lbChangePassword, forgot_pass);
        }

        private async Task FetchUserProfile()
        {
            try
            {
                userProfile = await Session.GetUserProfile();
                //LoadUserProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể cập nhật hồ sơ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lbChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }
    }
}
