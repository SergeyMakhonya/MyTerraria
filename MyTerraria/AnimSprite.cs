using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria
{
    // Кадр
    class AnimationFrame
    {
        public int i, j;
        public float time;

        public AnimationFrame(int i, int j, float time)
        {
            this.i = i;
            this.j = j;
            this.time = time;
        }
    }

    // Анимация
    class Animation
    {
        // Кадры
        public AnimationFrame[] frames;

        float timer;
        AnimationFrame currFrame;
        int currFrameIndex;

        public Animation(params AnimationFrame[] frames)
        {
            this.frames = frames;
            Reset();
        }

        // Начать проигрывание анимации сначала
        public void Reset()
        {
            timer = 0f;
            currFrameIndex = 0;
            currFrame = frames[currFrameIndex];
        }

        // Следующий кадр
        public void NextFrame()
        {
            timer = 0f;
            currFrameIndex++;

            if (currFrameIndex == frames.Length)
                currFrameIndex = 0;

            currFrame = frames[currFrameIndex];
        }

        // Получить текущий кадр
        public AnimationFrame GetFrame(float speed)
        {
            timer += speed;

            if (timer >= currFrame.time)
                NextFrame();

            return currFrame;
        }
    }

    // Спрайт с анимацией
    class AnimSprite : Transformable, Drawable
    {
        public float Speed = 0.05f;

        RectangleShape rectShape;
        SpriteSheet ss; // Набор спрайтов
        SortedDictionary<string, Animation> animations = new SortedDictionary<string, Animation>(); // Список анимаций
        Animation currAnim; // Текущая анимация
        string currAnimName;        // Имя текущей анимации

        // Цвет спрайта
        public Color Color
        {
            set { rectShape.FillColor = value; }
            get { return rectShape.FillColor; }
        }

        // Конструктор
        public AnimSprite(SpriteSheet ss)
        {
            this.ss = ss;

            rectShape = new RectangleShape(new Vector2f(ss.SubWidth, ss.SubHeight));
            rectShape.Origin = new Vector2f(ss.SubWidth / 2, ss.SubHeight / 2);
            rectShape.Texture = ss.Texture;
        }

        // Добавить анимацию
        public void AddAnimation(string name, Animation animation)
        {
            animations[name] = animation;
            currAnim = animation;
            currAnimName = name;
        }

        // Проигрывает указанную анимацию
        public void Play(string name)
        {
            if (currAnimName == name)
                return;

            currAnim = animations[name];
            currAnimName = name;
            currAnim.Reset();
        }

        public IntRect GetTextureRect()
        {
            var currFrame = currAnim.GetFrame(Speed);
            return ss.GetTextureRect(currFrame.i, currFrame.j);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            rectShape.TextureRect = GetTextureRect();

            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }
    }
}
