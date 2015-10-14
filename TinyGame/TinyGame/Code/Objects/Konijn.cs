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
        public int playerId = 0;
        public float angle = 0;
        public float speed = 160F;
        public int playerid;
        public float speed = 80F;
        public float boost = 1;
        public float slow = 1;

        public Konijn(int playerid, Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            this.playerid = playerid;
            
        }


        public void Update(float elapsed)
        {
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here

            velocity = new Vector2(0, 0);

            if (playerid == 1)
            {
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
                if(speed < 320)
                speed += boost;
              

                velocity.Y += (float)Math.Sin(angle) * speed;
                velocity.X += (float)Math.Cos(angle) * speed;
            }
            else
            {
                if (speed >80)
                    speed -= boost;
            }
        }

            else if (playerid == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    angle -= 0.1f;

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    angle += 0.1f;

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    velocity.Y -= (float)Math.Sin(angle) * speed;
                    velocity.X -= (float)Math.Cos(angle) * speed;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    velocity.Y += (float)Math.Sin(angle) * speed;
                    velocity.X += (float)Math.Cos(angle) * speed;
                }
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
