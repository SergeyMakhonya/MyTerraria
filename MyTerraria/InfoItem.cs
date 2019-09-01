namespace MyTerraria
{
    class InfoItem
    {
        public static InfoItem ItemGround = new InfoItem().SetSprite(Content.ssTileGround, 9, 3);

        //------------------------

        public SpriteSheet SpriteSheet { get; private set; }
        public int SpriteI { get; private set; }
        public int SpriteJ { get; private set; }
        // Максимальное кол-во предметов в стеке
        public int MaxCountInStack { get; internal set; } = 64;

        public InfoItem SetSprite(SpriteSheet ss, int i, int j)
        {
            SpriteSheet = ss;
            SpriteI = i;
            SpriteJ = j;
            return this;
        }

        public InfoItem SetMaxCountInStack(int value)
        {
            MaxCountInStack = value;
            return this;
        }
    }
}
