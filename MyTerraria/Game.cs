using MyTerraria.NPC;
using SFML.System;
using System.Collections.Generic;

namespace MyTerraria
{
    class Game
    {
        World world;    // Мир
        Player player;  // Игрок
        NpcFastSlime slime; // Слизень

        // Слизни
        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            // Создаём новый мир и выполняем его генерацию
            world = new World();
            world.GenerateWorld();

            // Создаём игрока
            player = new Player(world);
            player.StartPosition = new Vector2f(300, 150);
            player.Spawn();

            // Создаём быстрого слизня
            slime = new NpcFastSlime(world);
            slime.StartPosition = new Vector2f(500, 150);
            slime.Spawn();

            for (int i = 0; i < 5; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(150, 600), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();
                slimes.Add(s);
            }

            // Включаем прорисовку объектов для визуальной отладки
            DebugRender.Enabled = true;
        }

        // Обновление логики игры
        public void Update()
        {
            player.Update();
            slime.Update();

            foreach (var s in slimes)
                s.Update();
        }

        // Прорисовка игры
        public void Draw()
        {
            Program.Window.Draw(world);
            Program.Window.Draw(player);
            Program.Window.Draw(slime);

            foreach (var s in slimes)
                Program.Window.Draw(s);

            DebugRender.Draw(Program.Window);
        }
    }
}
