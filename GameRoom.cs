using SkiaSharp;
using FunDraw.Types;
namespace FunDraw

{
    public partial class GameRoom : Form
    {
        public GameRoom()
        {
            InitializeComponent();
            OnResize(EventArgs.Empty);

            Gateway.Instance.On("playerList", updatePlayerList);
            Gateway.Instance.On("gameProgress", gameProgressHandler);
            Gateway.Instance.On("chooseWord", chooseWordHandler);
            Gateway.Instance.On("chatMessage", chatMessageHandler);
            Gateway.Instance.On("chatGuessed", chatGuessedHandler);
            Gateway.Instance.On("drawEvent", drawEventHandler);
        }

        private void GameRoom_Load(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("playerList", new { roomId = GameManager.roomId });

            bitmap = new Bitmap(canvas.Width, canvas.Height);
            var info = new SKImageInfo(bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            surface = SKSurface.Create(info, bitmapData.Scan0, bitmapData.Stride);
            skcanvas = surface.Canvas;
            skcanvas.Clear(SKColors.White);

            color = SKColors.Black;
            command = DrawCommand.PENCIL;

            paint = new SKPaint
            {
                Color = SKColors.Black,
                StrokeWidth = 5,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke
            };

            bitmap.UnlockBits(bitmapData);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void pencil_Click(object sender, EventArgs e)
        {
            SetPaint(color, 5);
            command = DrawCommand.PENCIL;
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            SetPaint(SKColors.White, 10);
            command = DrawCommand.ERASER;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            skcanvas.Clear(SKColors.White);
            canvas.Invalidate();
            SendDrawData("clear", new SKPoint(0, 0), new SKPoint(0, 0), SKColors.White);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (!GameManager.isDrawer) return;
            lastPoint = new SKPoint(e.X, e.Y);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastPoint.HasValue)
            {
                var currentPoint = new SKPoint(e.X, e.Y);
                skcanvas.DrawLine(lastPoint.Value, currentPoint, paint);
                SendDrawData(command.ToString().ToLower(), lastPoint.Value, currentPoint, color);
                lastPoint = currentPoint;

                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = null;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, Point.Empty);
        }

        ColorDialog colorDialog = new ColorDialog();
        Color new_Color;

        private void colourPalette_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            new_Color = colorDialog.Color;
            color = GetSKColor(new_Color);

            SetPaint(color, 5);
        }

        // Cleanup method
        protected override void OnFormClosing(FormClosingEventArgs e)
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

        private void mainMenuBtn_Click(object sender, EventArgs e)
        {
            FormState.MainMenuForm();
            this.Close();
        }
    }
}
