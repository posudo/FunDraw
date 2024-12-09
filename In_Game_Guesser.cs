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
namespace FunDraw

{
    public partial class In_Game_Guesser : Form
    {
        private ClientWebSocket webSocket;
        private CancellationTokenSource cancellationTokenSource;
        Bitmap? bm;
        Graphics? g;

        public In_Game_Guesser()
        {
            InitializeComponent();
            OnResize(EventArgs.Empty);
            ConnectToServer();
        }

        async void ConnectToServer()
        {
            webSocket = new ClientWebSocket();
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                // Replace with your WebSocket server URL
                await webSocket.ConnectAsync(new Uri("https://ws-test-fundraw.lt.id.vn/"), cancellationTokenSource.Token);

                // Start receiving messages
                _ = ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối với server! Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024 * 4];

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        cancellationTokenSource.Token);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        ProcessDrawingMessage(message);
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(
                            WebSocketCloseStatus.NormalClosure,
                            "Closing",
                            cancellationTokenSource.Token);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class DrawingData
        {
            public string Action { get; set; }
            public PointData Start { get; set; }
            public PointData End { get; set; }
            public string Color { get; set; }
        }

        private class PointData
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        void ProcessDrawingMessage(string jsonData)
        {
            try
            {
                var drawData = JsonConvert.DeserializeObject<DrawingData>(jsonData);

                // Invoke on UI thread to prevent cross-thread issues
                this.Invoke((MethodInvoker)delegate {
                    switch (drawData.Action)
                    {
                        case "line":
                            g.DrawLine(new Pen(ColorTranslator.FromHtml(drawData.Color)),
                                new Point(drawData.Start.X, drawData.Start.Y),
                                new Point(drawData.End.X, drawData.End.Y));
                            break;
                        case "erase":
                            g.DrawLine(new Pen(Color.White, 10),
                                new Point(drawData.Start.X, drawData.Start.Y),
                                new Point(drawData.End.X, drawData.End.Y));
                            break;
                        case "ellipse":
                            g.DrawEllipse(new Pen(ColorTranslator.FromHtml(drawData.Color)),
                                drawData.Start.X, drawData.Start.Y,
                                drawData.End.X, drawData.End.Y);
                            break;
                        case "rectangle":
                            g.DrawRectangle(new Pen(ColorTranslator.FromHtml(drawData.Color)),
                                drawData.Start.X, drawData.Start.Y,
                                drawData.End.X, drawData.End.Y);
                            break;
                        case "clear":
                            g.Clear(Color.White);
                            break;
                    }
                    guna2PictureBox1.Refresh();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void SendDrawData(string action, Point start, Point end, Color color)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                var drawData = new DrawingData
                {
                    Action = action,
                    Start = new PointData { X = start.X, Y = start.Y },
                    End = new PointData { X = end.X, Y = end.Y },
                    Color = ColorTranslator.ToHtml(color)
                };

                string jsonData = JsonConvert.SerializeObject(drawData);
                var buffer = Encoding.UTF8.GetBytes(jsonData);

                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    cancellationTokenSource.Token);
            }
        }

        void Receive(CancellationToken token)
        {
            // Implementation of the Receive method
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (guna2PictureBox1.Width > 0 && guna2PictureBox1.Height > 0)
            {
                bm = new Bitmap(guna2PictureBox1.Width, guna2PictureBox1.Height);
                g = Graphics.FromImage(bm);
                g.Clear(Color.White);
                guna2PictureBox1.Image = bm;
            }
        }

        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog colorDialog = new ColorDialog();
        Color new_Color;

        private void button1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void guna2PictureBox1_MouseMove(object sender, MouseEventArgs e)
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
            guna2PictureBox1.Refresh();

            x = e.X;
            y = e.Y;

            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void guna2PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
                SendDrawData("ellipse", new Point(cX, cY), new Point(sX, sY), p.Color);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
                SendDrawData("rectangle", new Point(cX, cY), new Point(sX, sY), p.Color);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
                SendDrawData("line", new Point(cX, cY), new Point(x, y), p.Color);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void Elipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void guna2PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            guna2PictureBox1.Image = bm;
            index = 0;
            SendDrawData("clear", Point.Empty, Point.Empty, Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            new_Color = colorDialog.Color;
            guna2PictureBox1.BackColor = new_Color;
            p.Color = new_Color;
        }

        // Cleanup method
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Close WebSocket connection
            if (webSocket != null && webSocket.State == WebSocketState.Open)
            {
                webSocket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    "Closing",
                    CancellationToken.None).Wait();
            }
        }
    }
}
