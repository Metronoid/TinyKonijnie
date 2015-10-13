using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Konijn
    {
        public Vector2 location;
        public Texture2D image;
        public Vector2 velocity;
        public GameTime gameTime;
        public float angle = 0;
        public float speed = 160F;

        public Konijn(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
        }



        public void Update(float elapsed)
        {
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here

            velocity = new Vector2(0, 0);


            if (Keyboard.GetState().IsKeyDown(Keys.A))
                angle -= 0.1f;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                angle += 0.1f;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y -= (float)Math.Sin(angle) * speed;
                velocity.X -= (float)Math.Cos(angle) * speed;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y += (float)Math.Sin(angle) * speed;
                velocity.X += (float)Math.Cos(angle) * speed;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 origin = new Vector2(image.Width / 2, image.Height / 2);
            Rectangle sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);

            sb.Draw(image, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
        }


    }
}
