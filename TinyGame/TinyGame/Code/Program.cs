using System;

namespace TinyGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // using (var intro = new Introscreen())
             //   intro.Run();
            using (var game = new MainGame())
                game.Run();

        }
    }
#endif
}
