using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SocketIOClient;
using System.Diagnostics;
using FunDraw.Components;
using FunDraw.Types;
namespace FunDraw
{
    public partial class WaitingRoom : Form
    {
        public WaitingRoom()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();

            label1.Text = $"ID: {GameManager.roomId.Insert(4, "-")}";

            Gateway.Instance.On("playerList", updatePlayerList);
            Gateway.Instance.On("chatMessage", chatMessageHandler);
            Gateway.Instance.On("roomClosed", gameStateHandler);
            Gateway.Instance.On("startGame", startGameHandler);
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("playerList", new { roomId = GameManager.roomId });
        }

        private void updatePlayerList(SocketIOResponse response)
        {
            PlayerList[] data = response.GetValue<PlayerList[]>();

            Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Clear()));

            for (int i = 0; i < data.Length; i++)
            {
                PlayerCard pc = new PlayerCard();
                pc.PlayerName = $"{data[i].name}";
                pc.PlayerScore = data[i].score;

                Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(pc)));
            }
        }

        private void gameStateHandler(SocketIOResponse response)
        {
            MessageBox.Show("Room is closed because host left the room!", "Room Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormState.MainMenuForm();
            Invoke((MethodInvoker)(() => this.Close()));
        }

        private void chatMessageHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            var data = JsonConvert.DeserializeObject<JObject>(result);

            Invoke((MethodInvoker)(() => chatBox.AppendText($"{data["sender"]}: {data["message"]}\n")));
        }

        private void startGameHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            var data = JsonConvert.DeserializeObject<JObject>(result);
            if (data.ContainsKey("error"))
            {
                GameManager.gameStart = false;
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GameManager.gameStart = true;
            FormState.GameRoomForm();
            Invoke((MethodInvoker)(() => this.Close()));
        }

        private void btInvite_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GameManager.roomId.Insert(4, "-"));
            MessageBox.Show("Copied room code to clipboard!");
        }

        private void chatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chatInput.Focused)
            {
                Gateway.Instance.Emit("chatMessage", new { roomId = GameManager.roomId, message = chatInput.Text });
                chatInput.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
