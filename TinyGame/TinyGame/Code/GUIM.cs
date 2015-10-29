using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{

    class GUIM
    {
        public static float speed1;
        public static float speed2;
        public static int laps1;
        public static int laps2;
        public static int checks1;
        public static int checks2;
        public static int pitstops1;
        public static int pitstops2;
 //       public Color fontcolor = new Color(0,42,90);

        Konijn Player;
        Water water;


        public void FuelMeter()
        { 

        }
        public void SpeedMeter()
        {

        }
        public void PitMeter()
        {

        }
        public void RoundCounter()
        {

        }
        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(MainGame.font, "Speed: " + speed1 + " Bunnimeter", new Vector2(225, -3), Color.DarkBlue);
            sb.DrawString(MainGame.font, "Speed: " + speed2 + " Bunnimeter", new Vector2(740, -3), Color.DarkBlue);
            sb.DrawString(MainGame.font, "Laps: " + laps1 + "/5", new Vector2(85, 27), Color.DarkBlue);
            sb.DrawString(MainGame.font, "Laps: " + laps2 + "/5", new Vector2(600, 27), Color.DarkBlue);
            sb.DrawString(MainGame.font, "Pitstops: " + pitstops1, new Vector2(225, 27), Color.DarkBlue);
            sb.DrawString(MainGame.font, "Pitstops: " + pitstops2, new Vector2(740, 27), Color.DarkBlue);
        }
    }
}
