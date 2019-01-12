using SFML.Graphics;
using SFML.System;
using System;

namespace MyTerraria
{
    class Program
    {
        public static RenderWindow Window { private set; get; }
        public static Game Game { private set; get; }
        public static float Delta { private set; get; }

        static void Main(string[] args)
        {
            Window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Моя Terraria!");
            Window.SetVerticalSyncEnabled(true);

            Window.Closed += Win_Closed;
            Window.Resized += Win_Resized;

            // Загрузка контента
            Content.Load();
            
            Game = new Game();      // Создаём новый объект класса игры
            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Delta = clock.Restart().AsSeconds();

                Window.DispatchEvents();

                Game.Update();

                Window.Clear(Color.Black);

                Game.Draw();

                Window.Display();
            }
        }

        private static void Win_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            Window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
