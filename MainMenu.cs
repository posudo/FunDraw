using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SocketIOClient;
using System.Text.RegularExpressions;

namespace FunDraw
{
    public partial class MainMenu : Form
    {
        static string roomId = "";
        public MainMenu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(883, 500);
            Gateway.Instance.Connect();

            Gateway.Instance.On("roomCreated", createRoomEvent);
            Gateway.Instance.On("joinRoom", joinRoomEvent);
        }
        private void createRoomEvent(SocketIOResponse response)
        {
            var data = response.GetValue<string>();
            var result = JsonConvert.DeserializeObject<JObject>(data);
            if (result != null)
            {
                GameManager.roomId = result["id"].ToString();
                GameManager.isHost = true;
                Invoke((MethodInvoker)(() => this.Close()));
            }
        }

        private void joinRoomEvent(SocketIOResponse response)
        {
            var data = response.GetValue<string>();
            var result = JsonConvert.DeserializeObject<JObject>(data);
            if (result != null)
            {
                if (result.ContainsKey("error"))
                {
                    MessageBox.Show($"Unable to find a room with code: {roomId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    GameManager.roomId = result["id"].ToString();
                    Invoke((MethodInvoker)(() => this.Close()));
                }
            }
        }

        private void tbMaPhong_Enter(object sender, EventArgs e)
        {
            if (tbMaPhong.Text == "Room code")
            {
                tbMaPhong.Text = "";
                tbMaPhong.ForeColor = Color.Black;
            }
        }

        private void tbMaPhong_Leave(object sender, EventArgs e)
        {
            if (tbMaPhong.Text == "")
            {
                tbMaPhong.Text = "Room code";
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

        private void btTaoPhong_Click(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("createRoom");
        }

        private void tbMaPhong_TextChanged(object sender, EventArgs e)
        {
            roomId = tbMaPhong.Text.Replace("-", "");
        }

        private void btThamGia_Click(object sender, EventArgs e)
        {
            if (roomId != "" && (Regex.IsMatch(roomId, @"^[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}$") || Regex.IsMatch(roomId, @"^[a-zA-Z0-9]{8}$")))
            {
                Gateway.Instance.Emit("joinRoom", new { roomId = roomId });
            }
            else
            {
                MessageBox.Show("Invalid Room code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
