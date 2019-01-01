using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace MyTerraria
{
    public class DebugRender
    {
        public static bool Enabled = false;

        static List<Drawable> objects = new List<Drawable>();

        public static void AddRectangle(float x, float y, float w, float h, Color color)
        {
            if (!Enabled) return;

            var obj = new RectangleShape(new Vector2f(w, h));
            obj.Position = new Vector2f(x, y);
            obj.FillColor = Color.Transparent;
            obj.OutlineColor = color;
            obj.OutlineThickness = 1;
            objects.Add(obj);
        }

        public static void AddRectangle(FloatRect rect, Color color)
        {
            AddRectangle(rect.Left, rect.Top, rect.Width, rect.Height, color);
        }

        public static void Draw(RenderTarget target)
        {
            if (!Enabled) return;

            foreach (var obj in objects)
                target.Draw(obj);

            objects.Clear();
        }
    }
}
