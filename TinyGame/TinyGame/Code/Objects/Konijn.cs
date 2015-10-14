﻿using System;
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
        public Rectangle bounds;
        public float angle = 0;
        public float speed = 0F;
        public int playerid;
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

            if (CollisionSystem.CollisionDetection(bounds))
            {


            }

            velocity = new Vector2(0, 0);

            if (playerid == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                    angle -= speed/3000;

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    angle += speed/3000;

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (speed > -80)
                        speed -= 2 * boost;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (speed < 320)
                        speed += boost;


                    velocity.Y += (float)Math.Sin(angle) * speed;
                    velocity.X += (float)Math.Cos(angle) * speed;
                }
                else
                {
                    if (speed > 0)
                        speed -= boost;

                    if (speed < 0)
                        speed += boost;

                    velocity.Y += (float)Math.Sin(angle) * speed;
                    velocity.X += (float)Math.Cos(angle) * speed;
                }
            }

            else if (playerid == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    angle -= speed / 3000;

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    angle += speed / 3000;

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (speed > -80)
                        speed -= 2 * boost;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (speed < 320)
                        speed += boost;


                    velocity.Y += (float)Math.Sin(angle) * speed;
                    velocity.X += (float)Math.Cos(angle) * speed;
                }
                else
                {
                    if (speed > 0)
                        speed -= boost;

                    if (speed < 0)
                        speed += boost;

                    velocity.Y += (float)Math.Sin(angle) * speed;
                    velocity.X += (float)Math.Cos(angle) * speed;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X - image.Width / 2), (int)(location.Y - image.Height / 2), image.Width, image.Height);
            Vector2 origin = new Vector2(image.Width / 2, image.Height / 2);
            Rectangle sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);

            sb.Draw(image, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
        }


    }
}
