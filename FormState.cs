using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDraw
{
    public static class FormState
    {
        public static void LoginForm()
        {
            Thread th = new Thread(() =>
            {
                Application.Run(new Login());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public static void MainMenuForm()
        {
            Thread th = new Thread(() =>
            {
                Application.Run(new MainMenu());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public static void HostRoomForm()
        {
            Thread th = new Thread(() =>
            {
                Application.Run(new HostRoom());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public static void WaitingRoomForm()
        {
            Thread th = new Thread(() =>
            {
                Application.Run(new WaitingRoom());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public static void GameRoomForm()
        {
            Thread th = new Thread(() =>
            {
                Application.Run(new GameRoom());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
