using SFML.Graphics;
using SFML.System;

namespace MyTerraria.NPC
{
    class NpcFastSlime : NpcSlime
    {
        public NpcFastSlime(World world) : base(world)
        {
            rect.FillColor = new Color(255, 0, 0, 200);
        }

        public override Vector2f GetJumpVelocity()
        {
            return new Vector2f(Direction * World.Rand.Next(15, 100), -World.Rand.Next(8, 15));
        }
    }
}
