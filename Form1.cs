using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace FunDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            await Session.Login(username, password);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            JObject result = await Session.GET("users/profile", "");
            Debug.WriteLine(result);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Session.RefreshToken();
        }
    }
}
