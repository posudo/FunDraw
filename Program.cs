namespace FunDraw
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());

            if (GameManager.roomId != "" && !GameManager.gameStart)
            {
                if (GameManager.isHost)
                {
                    Application.Run(new HostRoom());
                }
                else
                {
                    Application.Run(new WaitingRoom());
                }
            }

            if (GameManager.roomId != "" && GameManager.gameStart)
            {
                Application.Run(new GameRoom());
            }
        }
    }
}