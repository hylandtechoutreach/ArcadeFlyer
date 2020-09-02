using System;

namespace ArcadeFlyer2D
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ArcadeFlyerGame())
                game.Run();
        }
    }
}
