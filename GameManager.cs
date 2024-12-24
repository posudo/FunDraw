using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDraw
{
    public class GameManager
    {
        static string _roomId = "";
        static bool _isHost = false;
        static bool _gameStarted = false;
        static bool _isDrawer = false;

        public static string roomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public static bool isHost
        {
            get { return _isHost; }
            set { _isHost = value; }
        }

        public static bool gameStart
        {
            get { return _gameStarted; }
            set { _gameStarted = value; }
        }

        public static bool isDrawer
        {
            get { return _isDrawer; }
            set { _isDrawer = value; }
        }
    }
}
