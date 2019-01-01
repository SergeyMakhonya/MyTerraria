using SFML.Graphics;
using SFML.System;

namespace MyTerraria.NPC
{
    class NpcSlime : Npc
    {
        const float TIME_WAIT_JUMP = 1f;

        SpriteSheet spriteSheet;
        float waitTimer = 0f;

        public NpcSlime(World world) : base(world)
        {
            spriteSheet = new SpriteSheet(1, 2, 0, (int)Content.texNpcSlime.Size.X, (int)Content.texNpcSlime.Size.Y);

            rect = new RectangleShape(new Vector2f(spriteSheet.SubWidth / 1.5f, spriteSheet.SubHeight / 1.5f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            rect.FillColor = new Color(0, 255, 0, 200);

            rect.Texture = Content.texNpcSlime;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
            Direction *= -1;
            velocity = new Vector2f(-velocity.X * 0.8f, velocity.Y);
        }

        public override void UpdateNPC()
        {
            if (!isFly)
            {
                if (waitTimer >= TIME_WAIT_JUMP)
                {
                    velocity = GetJumpVelocity();
                    waitTimer = 0f;
                }
                else
                {
                    waitTimer += 0.05f;
                    velocity.X = 0f;
                }

                rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
            }
            else
                rect.TextureRect = spriteSheet.GetTextureRect(0, 1);
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }

        public virtual Vector2f GetJumpVelocity()
        {
            return new Vector2f(Direction * Program.Rand.Next(1, 15), -Program.Rand.Next(8, 15));
        }
    }
}
