using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria.UI
{
    class UIInvertoryCell : UIBase
    {
        public UIInvertory Invertory { get; private set; }

        bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                rectShape.FillColor = isSelected ? new Color(255, 255, 0, 255) : new Color(100, 100, 255, 127);
            }
        }

        UIItemStack itemStack;
        public UIItemStack ItemStack
        {
            get { return itemStack; }
            set
            {
                if (itemStack != null && value != null && itemStack.InfoItem == value.InfoItem)
                {
                    itemStack.ItemCount += value.ItemCount;
                    return;
                }

                itemStack = value;

                if (itemStack != null)
                {
                    itemStack.Parent = this;
                    itemStack.Position = new Vector2i();
                    Childs.Add(itemStack);
                }
            }
        }

        public UIInvertoryCell(UIInvertory invertory)
        {
            Invertory = invertory;

            rectShape = new RectangleShape((Vector2f)Content.texUIInvertoryBack.Size);
            rectShape.Texture = Content.texUIInvertoryBack;

            IsSelected = false;
        }

        public override void OnDrop(UIBase ui)
        {
            if (ui is UIItemStack)
                ItemStack = ui as UIItemStack;
        }
    }
}
