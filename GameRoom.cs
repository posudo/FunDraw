using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using FunDraw.Components;
using SocketIOClient;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
namespace FunDraw

{
    public partial class GameRoom : Form
    {
        Bitmap? bm;
        Graphics? g;

        Bitmap bmP;
        Graphics gP;

        public GameRoom()
        {
            InitializeComponent();
            OnResize(EventArgs.Empty);

            bmP = new Bitmap(canvasP.Width, canvasP.Height);
            gP = Graphics.FromImage(bmP);
            gP.Clear(Color.White);
            canvasP.Image = bmP;

            Gateway.Instance.On("playerScore", updatePlayerList);
            Gateway.Instance.On("gameInfo", gameInfoHandler);
            Gateway.Instance.On("chooseWord", chooseWordHandler);
            Gateway.Instance.On("drawEvent", drawEventHandler);
        }

        private void GameRoom_Load(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("playerScore", new { roomId = GameManager.roomId });
        }

        private void updatePlayerList(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            var players = result.Split(",");

            Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Clear()));

            for (int i = 0; i < players.Length; i++)
            {
                PlayerCard pc = new PlayerCard();
                pc.PlayerName = $"{players[i]}";

                Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(pc)));
            }
        }

        private void gameInfoHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            Debug.WriteLine(result);
        }

        private void chooseWordHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            GameManager.isDrawer = true;
            Debug.WriteLine(result);
            if (result == "word_selected")
            {
                Invoke((MethodInvoker)(() =>
                {
                    wordSelectorGroup.SendToBack();
                    wordSelectorFlow.Controls.Clear();
                    canvas.BringToFront();
                    canvasP.SendToBack();
                    hideTool.SendToBack();
                }));
                return;
            }

            var words = result.Split(",");

            Invoke((MethodInvoker)(() =>
            {
                wordSelectorFlow.Controls.Clear();

                foreach (var word in words)
                {
                    WordButton wb = new WordButton();
                    wb.Word = word;
                    wordSelectorFlow.Controls.Add(wb);
                }

                wordSelectorGroup.BringToFront();
            }));
        }

        private void drawEventHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            ProcessDrawingMessage(result.ToString());
        }

        private class DrawingData
        {
            public string action { get; set; }
            public PointData start { get; set; }
            public PointData end { get; set; }
            public string color { get; set; }
        }

        private class PointData
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        void ProcessDrawingMessage(string jsonData)
        {
            if (GameManager.isDrawer) return;
            Invoke((MethodInvoker)(() => canvasP.BringToFront()));
            Debug.WriteLine(jsonData);
            var drawData = JsonConvert.DeserializeObject<DrawingData>(jsonData);

            this.Invoke((MethodInvoker)delegate
            {
                switch (drawData.action)
                {
                    case "line":
                        gP.DrawLine(new Pen(ColorTranslator.FromHtml(drawData.color), 2),
                            new Point(drawData.start.X, drawData.start.Y),
                            new Point(drawData.end.X, drawData.end.Y));
                        break;
                    case "erase":
                        gP.DrawLine(new Pen(Color.White, 10),
                            new Point(drawData.start.X, drawData.start.Y),
                            new Point(drawData.end.X, drawData.end.Y));
                        break;
                    case "clear":
                        gP.Clear(Color.White);
                        break;
                }
                canvasP.Invalidate();
            });
        }

        void SendDrawData(string action, Point start, Point end, Color color)
        {
            var drawData = new DrawingData
            {
                action = action,
                start = new PointData { X = start.X, Y = start.Y },
                end = new PointData { X = end.X, Y = end.Y },
                color = ColorTranslator.ToHtml(color)
            };

            Gateway.Instance.Emit("drawEvent", new { roomId = GameManager.roomId, payload = drawData });
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (canvas.Width > 0 && canvas.Height > 0)
            {
                bm = new Bitmap(canvas.Width, canvas.Height);
                g = Graphics.FromImage(bm);
                g.Clear(Color.White);
                canvas.Image = bm;
            }
        }

        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 2);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog colorDialog = new ColorDialog();
        Color new_Color;

        private void button1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                    SendDrawData("line", px, py, p.Color);
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                    SendDrawData("erase", px, py, erase.Color);
                }
            }
            canvas.Refresh();

            x = e.X;
            y = e.Y;

            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            canvas.Image = bm;
            SendDrawData("clear", Point.Empty, Point.Empty, Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            new_Color = colorDialog.Color;
            canvas.BackColor = new_Color;
            p.Color = new_Color;
        }

        private void canvasP_Paint(object sender, PaintEventArgs e)
        {
            Graphics gP = e.Graphics;
        }

        // Cleanup method
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

        }
    }
}
