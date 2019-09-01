using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria.UI
{
    class UIItemStack : UIBase
    {
        public int itemCount = 0;
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                itemCount = value;
                textCount.DisplayedString = itemCount.ToString();
                var textRect = textCount.GetGlobalBounds();
                textCount.Position = new Vector2f((int)(rectShape.Size.X / 2 - textRect.Width / 2), (int)(rectShape.Size.Y - textCount.CharacterSize - 5));
            }
        }
        public int ItemCountMax
        {
            get
            {
                return InfoItem.MaxCountInStack;
            }
        }
        public bool IsFull
        {
            get { return ItemCount >= ItemCountMax; }
        }

        public InfoItem InfoItem { get; private set; }

        RectangleShape rectShapeImage;
        Text textCount;

        public UIItemStack(InfoItem infoItem, int count)
        {
            InfoItem = infoItem;
            IsAllowDrag = true;

            var rectSize = (Vector2f)Content.texUIInvertoryBack.Size;
            rectShape = new RectangleShape(rectSize);
            rectShape.FillColor = Color.Transparent;

            var imgSize = new Vector2f(infoItem.SpriteSheet.SubWidth, infoItem.SpriteSheet.SubHeight);
            rectShapeImage = new RectangleShape(imgSize);
            rectShapeImage.Position = rectSize / 2 - imgSize / 2;
            rectShapeImage.Texture = infoItem.SpriteSheet.Texture;
            rectShapeImage.TextureRect = infoItem.SpriteSheet.GetTextureRect(infoItem.SpriteI, infoItem.SpriteJ);

            textCount = new Text("0", Content.font, 15);

            ItemCount = count;
        }

        public override void OnDragBegin()
        {
            if (Parent != null && Parent is UIInvertoryCell)
                (Parent as UIInvertoryCell).ItemStack = null;

            base.OnDragBegin();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            states.Transform *= Transform;

            target.Draw(rectShapeImage, states);
            target.Draw(textCount, states);
        }

        public override void OnDrop(UIBase ui)
        {
            if (ui is UIItemStack)
            {
                var itemSrc = ui as UIItemStack;
                var itemDest = this;

                if (itemSrc.InfoItem == itemDest.InfoItem && !itemDest.IsFull && itemDest.ItemCount + itemSrc.ItemCount < itemDest.ItemCountMax)
                    itemDest.ItemCount += itemSrc.ItemCount;
                else
                    ui.OnCancelDrag();
            }
        }
    }
}
