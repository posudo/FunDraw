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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace FunDraw
{
    public partial class HostRoom : Form
    {
        private int playersCount = 8;
        private int drawTime = 120;
        private int rounds = 3;
        private int wordsCount = 3;
        private int hints = 2;      

        public HostRoom()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();

            cobPlayers.SelectedIndex = 6;
            cobDrawtime.SelectedIndex = 10; // 10
            cobRounds.SelectedIndex = 2;
            cobHints.SelectedIndex = 1;
            cobWordsCount.SelectedIndex = 2;

            label1.Text = $"ID: {GameManager.roomId.Insert(4, "-")}";

            Gateway.Instance.On("roomInfo", roomInfoHandler);
            Gateway.Instance.On("playerList", updatePlayerList);
            Gateway.Instance.On("chatMessage", chatMessageHandler);
            Gateway.Instance.On("startGame", startGameHandler);
        }

        private void HostRoom_Load(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("roomInfo", new { roomId = GameManager.roomId });
            Gateway.Instance.Emit("playerList", new { roomId = GameManager.roomId });
        }

        private void roomInfoHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            var data = JsonConvert.DeserializeObject<JObject>(result);
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
                MessageBox.Show($"{data["error"]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GameManager.gameStart = true;
            FormState.GameRoomForm();
            Invoke((MethodInvoker)(() => this.Close()));
        }

        //private void tbCustom_Enter(object sender, EventArgs e)
        //{
        //    if (tbCustom.Text == "Minimum of 10 words. 1-32 characters per word! 20000 characters maximum. Separated by a, (comma)")
        //    {
        //        tbCustom.Text = "";
        //        tbCustom.ForeColor = Color.Black;
        //    }
        //}

        //private void tbCustom_Leave(object sender, EventArgs e)
        //{
        //    if (tbCustom.Text == "")
        //    {
        //        tbCustom.Text = "Minimum of 10 words. 1-32 characters per word! 20000 characters maximum. Separated by a, (comma)";
        //        tbCustom.ForeColor = Color.FromArgb(125, 137, 149);
        //    }
        //}

        private void btInvite_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GameManager.roomId.Insert(4, "-"));
            MessageBox.Show("Copied room code to clipboard!");
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            var payload = new
            {
                roomId = GameManager.roomId,
                playersCount = playersCount,
                drawTime = drawTime,
                roundsCount = rounds,
                wordsCount = wordsCount,
                hintsCount = hints,
                customWords = new string[0],
            };
            Gateway.Instance.Emit("startGame", payload);
        }

        private void cobPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            playersCount = int.Parse(cobPlayers.SelectedItem.ToString());
        }

        private void cobDrawtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawTime = int.Parse(cobDrawtime.SelectedItem.ToString());
        }

        private void cobRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            rounds = int.Parse(cobRounds.SelectedItem.ToString());
        }

        private void cobHints_SelectedIndexChanged(object sender, EventArgs e)
        {
            hints = int.Parse(cobHints.SelectedItem.ToString());
        }

        private void chatInput_TextChanged(object sender, EventArgs e)
        {

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
