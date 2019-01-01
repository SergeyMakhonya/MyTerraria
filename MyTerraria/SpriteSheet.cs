using SFML.Graphics;
using System;

namespace MyTerraria
{
    class SpriteSheet
    {
        public int SubWidth { get { return subW; } }
        public int SubHeight { get { return subH; } }

        int subW, subH;     // Ширина и высота одного фрагмента текстуры
        int borderSize;     // Толщина рамки между фрагментами

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="a">Кол-во фрагментов по X или размер одного фрагмента в пикселях по ширине</param>
        /// <param name="b">Кол-во фрагментов по Y или размер одного фрагмента в пикселях по высоте</param>
        /// <param name="borderSize">Толщина рамки между фрагментами</param>
        /// <param name="texW">Ширина текстуры</param>
        /// <param name="texH">Высота текстуры</param>
        public SpriteSheet(int a, int b, int borderSize, int texW=0, int texH=0)
        {
            if (borderSize > 0)
            {
                // Сразу увеличим значение на 1, что бы не делать это в просчёте
                this.borderSize = borderSize + 1;
            }
            else
                this.borderSize = 0;

            // Если в переменных a и b содержаться значения кол-ва фрагментов
            if (texW != 0 && texH != 0)
            {
                subW = (int)Math.Ceiling((float)texW / a);
                subH = (int)Math.Ceiling((float)texH / b);
            }
            else
            {
                subW = a;
                subH = b;
            }
        }

        // Получаем фрагмент текстуры по номеру столбца и строки
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * subW + i * borderSize;
            int y = j * subH + j * borderSize;
            return new IntRect(x, y, subW, subH);
        }
    }
}
