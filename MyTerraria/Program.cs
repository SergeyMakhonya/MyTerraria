using SFML.Graphics;
using System;

namespace MyTerraria
{
    class Program
    {
        static RenderWindow win;

        public static RenderWindow Window { get { return win; } }
        public static Game Game { private set; get; }
        public static Random Rand { private set; get; }

        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Моя Terraria!");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;
            win.Resized += Win_Resized;

            // Загрузка контента
            Content.Load();

            Rand = new Random();    // Создаём новый объект рандома
            Game = new Game();      // Создаём новый объект класса игры

            while (win.IsOpen)
            {
                win.DispatchEvents();

                Game.Update();

                win.Clear(Color.Black);

                Game.Draw();

                win.Display();
            }
        }

        private static void Win_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
