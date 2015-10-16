using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Konijn : CollisionComponent
    {
        public Vector2 location;
        public Texture2D image;
        public Texture2D boundsimage;
        public Vector2 velocity;
        public GameTime gameTime;
        public float angle = 0;
        public float speed = 0F;
        public int playerid;
        public float boost = 1;
        public float slow = 1;
        public int laps = 0;
        public int checks = 0;
        public int powercounter = 0;
    
        public Konijn(int playerid, Vector2 location, Texture2D image, Texture2D boundImage)
        {
            this.location = location;
            this.image = image;
            this.playerid = playerid;
            this.boundsimage = boundImage;
            id = "Konijn";
            CollisionSystem.colliders.Add(this);
        }


        public void Update(float elapsed)
        {
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here

            string trigger = CollisionSystem.TriggerDetection(this);
            if (trigger!="")
            {
                if (trigger == "Powerup")
                {
                    speed = 600;
                    powercounter = 0;
                }
                if (trigger == "trap")
                {
                      angle += 3;
                }
                if (trigger == "Finish")
                {
                    laps++;
                    checks = 0;
                }
            }

            string collision = CollisionSystem.CollisionDetection(this);
            if (collision != "")
            {
                if (collision == "Konijn")
                {
                    speed = -100;
                }
            }

            velocity = new Vector2(0, 0);

                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.A) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Left))
                    angle -= speed/3000;

                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.D) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Right))
                    angle += speed/3000;

                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.S) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (speed > -80)
                        speed -= 2 * boost;
                    else if (speed == -80)
                        speed -= boost;
                }

                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.W) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (speed < 320)
                        speed += boost;

                    else if (speed > 320)
                        if (powercounter < 100)
                            powercounter++;
                        else
                            speed -= boost;

                }
                else
                {
                    if (speed > 0)
                        speed -= boost;

                    if (speed < 0)
                        speed += boost;
                }
            if (playerid == 1)
            {
                GUIM.speed1 = speed;
                GUIM.angle1 = angle;
            }
            if (playerid == 2)
            {
                GUIM.speed2 = speed;
                GUIM.angle2 = angle;
            }

            velocity.Y += (float)Math.Sin(angle) * speed;
            velocity.X += (float)Math.Cos(angle) * speed;
        }


        public void Draw(SpriteBatch sb)
        { 
            bounds = new Rectangle((int)(location.X - image.Width / 4), (int)(location.Y - image.Height / 2), image.Width/2, image.Height);
            Vector2 origin = new Vector2(image.Width / 2, image.Height / 2);
            Rectangle sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            sb.Draw(image, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            sb.Draw(boundsimage, bounds, null, Color.Wheat);
        }


    }
}
