using SFML.Graphics;
using SFML.System;

namespace MyTerraria
{
    class Chunk : Transformable, Drawable
    {
        // Кол-во тайлов в одном чанке по ширине и высоте
        public const int CHUNK_SIZE = 25;

        Tile[][] tiles;     // Массив плиток
        Vector2i chunkPos;  // Позиция чанка в массиве мира

        // Конструктор класса
        public Chunk(Vector2i chunkPos)
        {
            // Выставляем позицию чанка
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * CHUNK_SIZE * Tile.TILE_SIZE, chunkPos.Y * CHUNK_SIZE * Tile.TILE_SIZE);

            // Создаём двумерный массив тайлов
            tiles = new Tile[CHUNK_SIZE][];

            for (int i = 0; i < CHUNK_SIZE; i++)
                tiles[i] = new Tile[CHUNK_SIZE];
        }

        // Установить плитку в чанке
        public void SetTile(TileType type, int i, int j, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            if (type != TileType.NONE)
            {
                tiles[i][j] = new Tile(type, upTile, downTile, leftTile, rightTile);
                tiles[i][j].Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
            }
            else
            {
                tiles[i][j] = null;

                // Присваиваем соседей, а соседям эту плитку
                if (upTile != null) upTile.DownTile = null;
                if (downTile != null) downTile.UpTile = null;
                if (leftTile != null) leftTile.RightTile = null;
                if (rightTile != null) rightTile.LeftTile = null;
            }
        }

        // Получить плитку из чанка
        public Tile GetTile(int x, int y)
        {
            // Если позиция плитки выходит за границу чанка
            if (x < 0 || y < 0 || x >= CHUNK_SIZE || y >= CHUNK_SIZE)
                return null;    // то возвращаем null

            // Иначе возвращаем плитку даже если она равна null
            return tiles[x][y];
        }

        // Рисуем чанк и его содержимое
        public void Draw(RenderTarget target, RenderStates states)
        {
            //states.Transform *= Transform;

            // Рисуем тайлы
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    if (tiles[x][y] == null) continue;

                    target.Draw(tiles[x][y]/*, states*/);
                }
            }
        }
    }
}
