using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunDraw.Components
{
    public partial class PlayerCard : UserControl
    {
        public PlayerCard()
        {
            InitializeComponent();
        }

        public string PlayerName
        {
            get => lbl_playerName.Text;
            set => lbl_playerName.Text = value;
        }

        public int PlayerScore
        {
            get => int.Parse(lbl_playerScore.Text.Replace("Score: ",""));
            set => lbl_playerScore.Text = $"Score: {value}";
        }
    }
}
