using SFML.System;
using System;

namespace MyTerraria
{
    class MathHelper
    {
        // Возращает дистанцию между двумя точками
        public static float GetDistance(Vector2f v1, Vector2f v2)
        {
            float x = v2.X - v1.X;
            float y = v2.Y - v1.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            float x = x2 - x1;
            float y = y2 - y1;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static float GetDistance(Vector2f vec)   // Определяет длину вектора
        {
            return (float)Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        // Нормализация вектора
        public static Vector2f Normalize(Vector2f vec)
        {
            float len = GetDistance(vec);
            vec.X /= len;
            vec.Y /= len;
            return vec;
        }
    }
}
