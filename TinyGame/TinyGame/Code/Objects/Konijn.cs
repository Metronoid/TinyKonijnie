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
        private Controls controls;
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


        /// <summary>
        /// Geeft aan welke variabelen Konijn met zich mee geeft. 
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="location"></param>
        /// <param name="image"></param>
        /// <param name="boundImage"></param>
        public Konijn(int playerid,Controls controlScheme, Vector2 location, float ang, Texture2D image, Texture2D boundImage)
        {
            this.location = location;
            this.startLocation = location;
            this.startAngle = ang;
            this.angle = ang;
            this.image = image;
            controls = controlScheme;
            rows = 4;
            columns = 1;
            currentFrame = 0;
            totalFrames = rows * columns;
            this.playerid = playerid;
            this.boundsimage = boundImage;
            if (playerid == 1) 
            this.waterComponent = new Water(new Vector2(85, -3));
            if (playerid == 2)
            this.waterComponent = new Water(new Vector2(600, -3));
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

                     if (laps == 2)
                    {
                        Endscreen.winner = playerid;
                        SceneManager.state = SceneManager.Scenes.end;
                    }
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

            Keys[] allKeys = Keyboard.GetState().GetPressedKeys();
            KeyboardState keyState = new KeyboardState();
            Keys[] commands = new Keys[4];
            foreach (Keys k in allKeys)
            {
                    Console.WriteLine(k);
                    if (k == controls.up)
                {
                    commands[0] = k;
                }
                if (k == controls.left)
                {
                        commands[1] = k;
                }
                if (k == controls.right)
                {
                        commands[2] = k;
                }
                if (k == controls.down)
                {
                        commands[3] = k;
                }
            }
            keyState = new KeyboardState(commands);

            if (keyState != null) { 
            //Als knop A en down wordt ingedrukt
                if (keyState.IsKeyDown(controls.left))
                    angle -= speed / 3000;
                //Als knop D en right wordt ingedrukt
                if (keyState.IsKeyDown(controls.right))
                    angle += speed / 3000;
                //Als knop S en down wordt ingedrukt
                if (keyState.IsKeyDown(controls.down))
                {
                    if (speed > -80)
                        speed -= 2 * boost;
                    else if (speed == -80)
                        speed -= boost;
                }
                //Als knop W en up wordt ingedrukt
                if (keyState.IsKeyDown(controls.up))
                {
                    if (speed < (waterComponent.water * 2.5f) + 150)
                        speed += boost;

                    if (speed > (waterComponent.water * 2.5f) + 150)
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
  
            //sb.Draw(boundsimage, bounds, null, Color.Wheat);
            waterComponent.Draw(sb);
        }
    }
}
