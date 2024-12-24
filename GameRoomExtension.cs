using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FunDraw.Components;
using FunDraw.Types;
using Newtonsoft.Json;
using SkiaSharp;
using SocketIOClient;

namespace FunDraw
{
    public partial class GameRoom
    {
        private Bitmap bitmap;
        private SKSurface surface;
        private SKCanvas skcanvas;
        private SKPaint paint;
        private SKColor color;
        private SKPoint? lastPoint = null;
        private DrawCommand command;
        private static System.Timers.Timer _timer = new System.Timers.Timer(1000);

        private class PointData
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        private class DrawingData
        {
            public string action { get; set; }
            public PointData start { get; set; }
            public PointData end { get; set; }
            public string color { get; set; }
        }

        private class GameProgress
        {
            public string state { get; set; }
            public string word { get; set; }
            public int timeLeft { get; set; }
            public PlayerList[] players { get; set; }
        }

        private class ChatMessage
        {
            public string sender { get; set; }
            public string message { get; set; }
        }

        private class ChooseWord
        {
            public string state { get; set; }
            public string drawer { get; set; }
            public string[] words { get; set; }
            public long timeLeft { get; set; }
            public int round { get; set; }
            public int totalRounds { get; set; }
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

        private void gameProgressHandler(SocketIOResponse response)
        {
            GameProgress data = response.GetValue<GameProgress>();

            if (data.state == "ending")
            {
                Invoke((MethodInvoker)(() =>
                {
                    wordHint.Clear();
                    Label[] podium = new Label[] { podium1, podium2, podium3 };
                    for (int i = 0; i < data.players.Length; i++)
                    {
                        podium[i].Text = $"{data.players[i].id} - {data.players[i].score}";
                    }
                    
                    endGameGroup.BringToFront();                 
                }));
            }

            if (data.state == "end")
            {
                GameManager.roomId = "";
                GameManager.isHost = false;
                GameManager.gameStart = false;
                GameManager.isDrawer = false;

                FormState.MainMenuForm();
                Invoke((MethodInvoker)(() => this.Close()));
                return;
            }

            if (data.state == "changing_turn")
            {
                Invoke((MethodInvoker)(() =>
                {
                    hideCanvas.BringToFront();
                    hideTool.BringToFront();
                }));
                return;
            }

            if (data.state == "end_turn")
            {
                if (GameManager.isDrawer) GameManager.isDrawer = false;
                Invoke((MethodInvoker)(() =>
                {
                    hideTool.BringToFront();
                    endTurnText.Text = $"The word was: {data.word}";
                    endTurnBox.BringToFront();
                }));
                return;
            }

            if (data.state == "playing")
            {
                int minutes = (int)Math.Floor((float)data.timeLeft / 60);
                int seconds = data.timeLeft % 60;

                Debug.WriteLine(data.word);

                Invoke((MethodInvoker)(() =>
                {
                    timer.Text = $"{minutes}:{(seconds < 10 ? "0" : "")}{seconds}";
                    wordHint.Text = data.word;
                }));
                return;
            }
            
        }

        private void chooseWordHandler(SocketIOResponse response)
        {
            ChooseWord? result = response.GetValue<ChooseWord>();
            Invoke((MethodInvoker)(() =>
            {
                hideCanvas.BringToFront();
                endTurnBox.SendToBack();         
                skcanvas.Clear(SKColors.White);
                canvas.Invalidate();
            }));

            if (_timer.Enabled)
            {
                _timer.Stop();
            }

            if (result.state == "you-selected")
            {
                Invoke((MethodInvoker)(() =>
                {
                    wordSelectorFlow.Controls.Clear();
                    canvas.BringToFront();
                    hideTool.SendToBack();
                }));
                return;
            }

            if (result.state == "selected")
            {
                Invoke((MethodInvoker)(() =>
                {
                    wordSelectorFlow.Controls.Clear();
                    canvas.BringToFront();
                    hideTool.BringToFront();
                }));
                return;
            }
            
            // Initialize word select timer without websocket   
            _timer.Elapsed += (sender, e) =>
            {
                long time = (result.timeLeft - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()) / 1000;
                string timerString = "0:" + (time < 10 ? "0" : "") + (time > 0 ? time : 0).ToString();

                Invoke((MethodInvoker)(() => timer.Text = timerString));
            };
            _timer.Start();

            if (result.drawer == "#you")
            {
                GameManager.isDrawer = true;
                Invoke((MethodInvoker)(() =>
                {
                    wordSelectorFlow.Controls.Clear();

                    foreach (var word in result.words)
                    {
                        WordButton wb = new WordButton();
                        wb.Word = word;
                        wordSelectorFlow.Controls.Add(wb);
                    }

                    wordSelector.BringToFront();
                    roundLabel.Text = $"Round {result.round}/{result.totalRounds}";
                }));
                return;
            } else
            {
                Invoke((MethodInvoker)(() =>
                {
                    wordChooseText.Text = $"{result.drawer} is choosing a word...";
                    wordChooseBox.BringToFront();
                    roundLabel.Text = $"Round {result.round}/{result.totalRounds}";
                }));
            }       
        }

        private void drawEventHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            ProcessDrawingMessage(result.ToString());
        }

        void ProcessDrawingMessage(string jsonData)
        {
            if (GameManager.isDrawer) return;
            var drawData = JsonConvert.DeserializeObject<DrawingData>(jsonData);

            this.Invoke((MethodInvoker)delegate
            {
                switch (drawData.action)
                {
                    case "pencil":
                        skcanvas.DrawLine(
                            new SKPoint(drawData.start.X, drawData.start.Y),
                            new SKPoint(drawData.end.X, drawData.end.Y),
                            new SKPaint
                            {
                                Color = GetSKColor(ColorTranslator.FromHtml(drawData.color)),
                                StrokeWidth = 5,
                                IsAntialias = true,
                                Style = SKPaintStyle.Stroke
                            }
                        );
                        canvas.Invalidate();
                        break;
                    case "eraser":
                        skcanvas.DrawLine(
                            new SKPoint(drawData.start.X, drawData.start.Y),
                            new SKPoint(drawData.end.X, drawData.end.Y),
                            new SKPaint
                            {
                                Color = SKColors.White,
                                StrokeWidth = 10,
                                IsAntialias = true,
                                Style = SKPaintStyle.Stroke
                            }
                        );
                        canvas.Invalidate();
                        break;
                    case "clear":
                        skcanvas.Clear(SKColors.White);
                        canvas.Invalidate();
                        break;
                }
            });
        }

        void SendDrawData(string action, SKPoint start, SKPoint end, SKColor color)
        {
            var drawData = new DrawingData
            {
                action = action,
                start = new PointData { X = start.X, Y = start.Y },
                end = new PointData { X = end.X, Y = end.Y },
                color = ColorTranslator.ToHtml(GetColor(color))
            };

            Gateway.Instance.Emit("drawEvent", new { roomId = GameManager.roomId, payload = drawData });
        }

        void chatMessageHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            ChatMessage? data = JsonConvert.DeserializeObject<ChatMessage>(result);
            Invoke((MethodInvoker)(() => chatBox.AppendText($"{data.sender}: {data.message}\n")));
        }

        void chatGuessedHandler(SocketIOResponse response)
        {
            var result = response.GetValue<string>();
            ChatMessage? data = JsonConvert.DeserializeObject<ChatMessage>(result);
            
            Invoke((MethodInvoker)(() =>
            {
                if (data.message == "guessed")
                {
                    chatBox.SelectionColor = Color.Green;
                    chatBox.AppendText($"{data.sender} guessed the word!\n");
                } else
                {
                    chatBox.SelectionColor = Color.LightSlateGray;
                    chatBox.AppendText($"{data.sender}: {data.message}\n");
                }             
            }));
        }

        private void SetPaint(SKColor color, int? stroke)
        {
            paint = new SKPaint
            {
                Color = color,
                StrokeWidth = 5,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke
            };
        }

        private static SKColor GetSKColor(Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        private static Color GetColor(SKColor color)
        {
            return Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        }

    }
}
