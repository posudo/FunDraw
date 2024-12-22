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
            Gateway.Instance.On("startGame", startGameHandler);
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("playerList", new { roomId = GameManager.roomId });
        }

        private void updatePlayerList(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            var players = result.Split(",");
            Debug.WriteLine(result);

            Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Clear()));

            for (int i = 0; i < players.Length; i++)
            {
                PlayerCard pc = new PlayerCard();
                pc.PlayerName = $"{players[i]}";

                Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(pc)));
            }
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
            Invoke((MethodInvoker)(() => this.Close()));
        }

        private void btInvite_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GameManager.roomId.Insert(4, "-"));
            MessageBox.Show("Copied room code to clipboard!");
        }       
    }
}
