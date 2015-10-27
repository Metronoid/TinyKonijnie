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
            sb.DrawString(MainGame.font, "Speed: " + speed1 + " Bunnimeter", new Vector2(10, 0), Color.Yellow);
            sb.DrawString(MainGame.font, "Speed: " + speed2 + " Bunnimeter", new Vector2(760, 0), Color.Yellow);
            sb.DrawString(MainGame.font, "Laps:  " + laps1 + "/3", new Vector2(10, 50), Color.Yellow);
            sb.DrawString(MainGame.font, "Laps:  " + laps2 + "/3", new Vector2(760, 50), Color.Yellow);
            sb.DrawString(MainGame.font, "Checks: " + checks1, new Vector2(10, 70), Color.Yellow);
            sb.DrawString(MainGame.font, "Checks: " + checks2, new Vector2(760, 70), Color.Yellow);
            sb.DrawString(MainGame.font, "Pitstops: " + pitstops1, new Vector2(10, 90), Color.Yellow);
            sb.DrawString(MainGame.font, "Pitstops: " + pitstops2, new Vector2(760, 90), Color.Yellow);
        }
    }
}
