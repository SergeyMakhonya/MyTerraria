using SFML.Graphics;

namespace MyTerraria
{
    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";
        public static readonly string FONT_DIR = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\";

        public static SpriteSheet ssTileGround; // Ground
        public static SpriteSheet ssTileGrass; // Grass

        // NPC
        public static SpriteSheet ssNpcSlime; // Слизень

        // Игрок
        public static SpriteSheet ssPlayerHead;        // Голова
        public static SpriteSheet ssPlayerHair;        // Волосы
        public static SpriteSheet ssPlayerShirt;       // Рубашка
        public static SpriteSheet ssPlayerUndershirt;  // Рукава
        public static SpriteSheet ssPlayerHands;       // Кисти
        public static SpriteSheet ssPlayerLegs;        // Ноги
        public static SpriteSheet ssPlayerShoes;       // Обувь

        // UI
        public static Texture texUIInvertoryBack;      // Инвертарь

        public static Font font;       // Шрифт

        public static void Load()
        {
            ssTileGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_0.png"));
            ssTileGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_1.png"));

            // NPC
            ssNpcSlime = new SpriteSheet(1, 2, true, 0, new Texture(CONTENT_DIR + "Textures\\npc\\slime.png"));

            // Игрок
            ssPlayerHead = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\head.png"));
            ssPlayerHair = new SpriteSheet(1, 14, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\hair.png"));
            ssPlayerShirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\shirt.png"));
            ssPlayerUndershirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\undershirt.png"));
            ssPlayerHands = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\hands.png"));
            ssPlayerLegs = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\legs.png"));
            ssPlayerShoes = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\player\\shoes.png"));

            // UI
            texUIInvertoryBack = new Texture(CONTENT_DIR + "Textures\\ui\\Inventory_Back.png");

            // Шрифт
            font = new Font(FONT_DIR + "brushtype.ttf");
        }
    }
}
