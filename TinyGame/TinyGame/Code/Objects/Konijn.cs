using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Konijn : CollisionComponent
    {
        public Vector2 location;
        private Vector2 startLocation;
        public Texture2D image { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Texture2D boundsimage;
        public Vector2 velocity;
        public GameTime gameTime;
        public float angle = 0;
        public float startAngle = 0;
        public float speed = 0F;
        public int playerid;
        public float boost = 1;
        public float slow = 1;
        public int laps = 1;
        public int checks = 0;
        public int powercounter = 0;
        public int pitstops = 0;
        public bool pitstopsBool = false;
        public Water waterComponent;
        public Val valtrap; 


        /// <summary>
        /// Geeft aan welke variabelen Konijn met zich mee geeft. 
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="location"></param>
        /// <param name="image"></param>
        /// <param name="boundImage"></param>
        public Konijn(int playerid, Vector2 location, float ang, Texture2D image, Texture2D boundImage)
        {
            this.location = location;
            this.startLocation = location;
            this.startAngle = ang;
            this.angle = ang;
            this.image = image;
            rows = 4;
            columns = 1;
            currentFrame = 0;
            totalFrames = rows * columns;
            this.playerid = playerid;
            this.boundsimage = boundImage;
            if (playerid == 1) 
            this.waterComponent = new Water(new Vector2(10, 30));
            if (playerid == 2)
            this.waterComponent = new Water(new Vector2(760, 30));
            id = "Konijn";
            CollisionSystem.colliders.Add(this);
        }

        /// <summary>
        /// Geeft aan wat de Konijn per frame doet.
        /// </summary>
        /// <param name="elapsed"></param>
        public void Update(float elapsed)
        {
            // Update water
            waterComponent.WaterChange(); 
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here

            // Update de animatie indien het konijn beweegt
            if (speed > 0 || speed < 0)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
            else
            {
                currentFrame = 0;
            }

            // Neemt de collisionsystem en bekijkt of de powerup en dergelijke tegen komt, waar het konijn tegenaan knalt.
            if (!MainGame.backgroundbound.Contains(bounds))
            {
                location = startLocation;
                angle = startAngle;
            }

            CollisionComponent obj = CollisionSystem.TriggerDetection(this, "Val");
            if (obj != null)
            {
                obj.OnDestroy();
                speed = 10;
            }

            string trigger = CollisionSystem.TriggerDetection(this);
            if (trigger!="")
            {
                if (trigger == "Powerup")
                {
                    speed = 600;
                    powercounter = 0;
                }

                if (trigger == "trap" || !MainGame.backgroundbound.Contains(bounds))
                {
                      angle += 3;
                }

                if (trigger == "Finish" && checks == 3)
                {
                    laps++;
                    checks = 0;
                    startLocation = location;
                    startAngle = angle;
                }

                if (trigger == "Pitstop")
                {
                    if (waterComponent.water < 100)
                    {
                        waterComponent.water++;
                    }
            }

                if (trigger == ("Checkpoint" + (checks + 1)))
                {
                    checks ++;
                    startLocation = location;
                    startAngle = angle;
                }
                if (trigger == "heet")
                {
                    if (waterComponent.water < 100)
                    {
                        waterComponent.water++;
                    }
                }
            }
            // Neemt de collisionsystem en bekijkt of de twee konijnen tegen elkaar aan zit.
            string collision = CollisionSystem.CollisionDetection(this);
            if (collision != "")
            {
                if (collision == "Konijn")
                {
                    speed = -60;
                }

                if (collision == "Pitstop")
                {
                    if (waterComponent.water < 100)
                    {
                        waterComponent.water += 0.11f;
                    }
                    waterComponent.check = false;
                    pitstopsBool = true;
                }
            }

            if (collision == "heet")
            {
                if (waterComponent.water < 100)
                {
                    waterComponent.water -= 0.2f;
                }
            }

            if (collision != "Pitstop")
            { 
                if (pitstopsBool == true)
                {
                    pitstops++;
                    pitstopsBool = false;
                }
            }

            velocity = new Vector2(0, 0);
            if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.X))
            {
                valtrap = new Val(location,boundsimage,this);
                if (valtrap.bSpawnVal == false)
                {
                    valtrap.bSpawnVal = true;
                    valtrap.location = location;
                }
            }

                    
            //Als knop A en down wordt ingedrukt
                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.A) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Left))
                    angle -= speed / 3000;
                //Als knop D en right wordt ingedrukt
                if (playerid == 1 && Keyboard.GetState().IsKeyDown(Keys.D) || playerid == 2 && Keyboard.GetState().IsKeyDown(Keys.Right))
                    angle += speed / 3000;
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
                    if (speed < (waterComponent.water * 2.75f) + 120)
                        speed += boost;

                    if (speed > (waterComponent.water * 2.75f) + 120)
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

            velocity.Y += (float)Math.Sin(angle) * speed;
            velocity.X += (float)Math.Cos(angle) * speed;
            // geeft de speed en laps door aan de GUI per konijn.
            if (playerid == 1)
            {
                GUIM.speed1 = speed;
                GUIM.laps1 = laps;
                GUIM.checks1 = checks;
                GUIM.pitstops1 = pitstops;
            }

            if (playerid == 2)
            {
                GUIM.speed2 = speed;
                GUIM.laps2 = laps;
                GUIM.checks2 = checks;
                GUIM.pitstops2 = pitstops;
            }
        }

        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        { 
            int width = image.Width / columns;
            int height = image.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            bounds = new Rectangle((int)(location.X - width / 4), (int)(location.Y - height / 4), width / 2, height / 2);

            Vector2 origin = new Vector2(width / 2, height / 2);

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            sb.Draw(image, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            if (valtrap != null)
            {
                valtrap.Draw(sb);
            }        
            //sb.Draw(boundsimage, bounds, null, Color.Wheat);
            waterComponent.Draw(sb);
        }
    }
}
