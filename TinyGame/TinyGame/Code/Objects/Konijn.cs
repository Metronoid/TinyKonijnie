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

        /// <summary>
        /// Geeft aan welke variabelen Konijn met zich mee geeft. 
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="location"></param>
        /// <param name="image"></param>
        /// <param name="boundImage"></param>
        public Konijn(int playerid, Vector2 location, Texture2D image, Texture2D boundImage)
        {
            this.location = location;
            this.image = image;
            this.playerid = playerid;
            this.boundsimage = boundImage;
            id = "Konijn";
            CollisionSystem.colliders.Add(this);
        }

        /// <summary>
        /// Geeft aan wat de Konijn per frame doet.
        /// </summary>
        /// <param name="elapsed"></param>
        public void Update(float elapsed)
        {
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here
            // Neemt de collisionsystem en bekijkt of de powerup en dergelijke tegen komt, waar het konijn tegenaan knalt.
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
            // Neemt de collisionsystem en bekijkt of de twee konijnen tegen elkaar aan zit.
            string collision = CollisionSystem.CollisionDetection(this);
            if (collision != "")
            {
                if (collision == "Konijn")
                {
                    speed = -100;
                }
            }

            velocity = new Vector2(0, 0);
                //Als knop A en down wordt ingedrukt
                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.A) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Left))
                    angle -= speed/3000;
                //Als knop D en right wordt ingedrukt
                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.D) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Right))
                    angle += speed/3000;
                //Als knop S en down wordt ingedrukt
                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.S) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (speed > -80)
                        speed -= 2 * boost;
                    else if (speed == -80)
                        speed -= boost;
                }
                //Als knop W en up wordt ingedrukt
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
            if (playerid == 1)      // geeft de speed door aan de GUI per konijn.
                GUIM.speed1 = speed;
            if (playerid == 2)
                GUIM.speed2 = speed;

            velocity.Y += (float)Math.Sin(angle) * speed;  //geeft aan welke positie het konijn moet aannemen.
            velocity.X += (float)Math.Cos(angle) * speed;
        }

        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
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
