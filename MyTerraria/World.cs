using SFML.Graphics;
using SFML.System;

namespace MyTerraria
{
    class World : Transformable, Drawable
    {
        // Кол-во чанков по ширине и высоте
        public const int WORLD_SIZE = 5;

        // Чанки
        Chunk[][] chunks;

        // Конструктор класса
        public World()
        {
            chunks = new Chunk[WORLD_SIZE][];

            for (int i = 0; i < WORLD_SIZE; i++)
                chunks[i] = new Chunk[WORLD_SIZE];
        }

        // Генерируем новый мир
        public void GenerateWorld()
        {
            // Трава
            for (int x = 3; x <= 46; x++)
                for (int y = 17; y <= 17; y++)
                    SetTile(TileType.GRASS, x, y);

            // Почва
            for (int x = 3; x <= 46; x++)
                for (int y = 18; y <= 32; y++)
                    SetTile(TileType.GROUND, x, y);

            for (int x = 3; x <= 4; x++)
                for (int y = 1; y <= 17; y++)
                    SetTile(TileType.GROUND, x, y);

            for (int x = 45; x <= 46; x++)
                for (int y = 1; y <= 17; y++)
                    SetTile(TileType.GROUND, x, y);
        }

        // Установить плитку
        public void SetTile(TileType type, int i, int j)
        {
            var chunk = GetChunk(i, j);
            var tilePos = GetTilePosFromChunk(i, j);    // Получаем позицию плитки в массиве чанка

            // Находим соседей
            Tile upTile = GetTile(i, j - 1);     // Верхний сосед
            Tile downTile = GetTile(i, j + 1);   // Нижний сосед
            Tile leftTile = GetTile(i - 1, j);   // Левый сосед
            Tile rightTile = GetTile(i + 1, j);  // Правый сосед

            chunk.SetTile(type, tilePos.X, tilePos.Y, upTile, downTile, leftTile, rightTile);
        }

        // Получить плитку по мировым координатам
        public Tile GetTileByWorldPos(float x, float y)
        {
            int i = (int)(x / Tile.TILE_SIZE);
            int j = (int)(y / Tile.TILE_SIZE);
            return GetTile(i, j);
        }
        public Tile GetTileByWorldPos(Vector2f pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }
        public Tile GetTileByWorldPos(Vector2i pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }

        // Получить плитку
        public Tile GetTile(int x, int y)
        {
            var chunk = GetChunk(x, y);
            if (chunk == null)  // Если чанк неопределён
                return null;    // то возвращаем null

            // Получаем позицию плитки в массиве чанка
            var tilePos = GetTilePosFromChunk(x, y);

            // Возвращаем плитку даже если она ровна null
            return chunk.GetTile(tilePos.X, tilePos.Y);
        }

        // Получить чанк
        public Chunk GetChunk(int x, int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            if (X >= WORLD_SIZE || Y >= WORLD_SIZE || X < 0 || Y < 0)
            {
                return null;
            }

            if (chunks[X][Y] == null)
            {
                chunks[X][Y] = new Chunk(new Vector2i(X, Y));
            }

            return chunks[X][Y];
        }

        // Получить позицию плитки внутри чанка
        public Vector2i GetTilePosFromChunk(int x, int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            return new Vector2i(x - X * Chunk.CHUNK_SIZE, y - Y * Chunk.CHUNK_SIZE);
        }

        // Нарисовать мир
        public void Draw(RenderTarget target, RenderStates states)
        {
            // Рисуем чанки
            for (int x = 0; x < WORLD_SIZE; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    if (chunks[x][y] == null) continue;

                    target.Draw(chunks[x][y]);
                }
            }
        }
    }
}
