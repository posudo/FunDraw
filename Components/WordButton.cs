using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunDraw.Components
{
    public partial class WordButton : UserControl
    {
        public WordButton()
        {
            InitializeComponent();
        }

        public string Word
        {
            get => wordBtn.Text;
            set => wordBtn.Text = value;
        }

        public event EventHandler WordButtonClick
        {
            add => wordBtn.Click += value;
            remove => wordBtn.Click -= value;
        }

        private void wordBtn_Click(object sender, EventArgs e)
        {
            Gateway.Instance.Emit("chooseWord", new { roomId = GameManager.roomId, word = this.Word });
            Debug.WriteLine(this.Word);
        }
    }
}
