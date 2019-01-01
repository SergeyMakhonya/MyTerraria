using SFML.Graphics;

namespace MyTerraria
{
    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";

        public static Texture texTile0; // Ground
        public static Texture texTile1; // Grass

        // NPC
        public static Texture texNpcSlime; // Слизень

        // Игрок
        public static Texture texPlayerHead;        // Голова
        public static Texture texPlayerHair;        // Волосы
        public static Texture texPlayerShirt;       // Рубашка
        public static Texture texPlayerUndershirt;  // Рукава
        public static Texture texPlayerHands;       // Кисти
        public static Texture texPlayerLegs;        // Ноги
        public static Texture texPlayerShoes;       // Обувь

        public static void Load()
        {
            texTile0 = new Texture(CONTENT_DIR + "Textures\\Tiles_0.png");
            texTile1 = new Texture(CONTENT_DIR + "Textures\\Tiles_1.png");

            // NPC
            texNpcSlime = new Texture(CONTENT_DIR + "Textures\\npc\\slime.png");

            // Игрок
            texPlayerHead = new Texture(CONTENT_DIR + "Textures\\player\\head.png");
            texPlayerHair = new Texture(CONTENT_DIR + "Textures\\player\\hair.png");
            texPlayerShirt = new Texture(CONTENT_DIR + "Textures\\player\\shirt.png");
            texPlayerUndershirt = new Texture(CONTENT_DIR + "Textures\\player\\undershirt.png");
            texPlayerHands = new Texture(CONTENT_DIR + "Textures\\player\\hands.png");
            texPlayerLegs = new Texture(CONTENT_DIR + "Textures\\player\\legs.png");
            texPlayerShoes = new Texture(CONTENT_DIR + "Textures\\player\\shoes.png");
        }
    }
}
