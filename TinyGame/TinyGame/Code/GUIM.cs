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
        public static float angle1;
        public static float angle2;
        Konijn Player;


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

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(MainGame.font, "Speed: " + speed1 + " Bunnimeter", new Vector2(10, 0), Color.Black);
            sb.DrawString(MainGame.font, "Speed: " + speed2 + " Bunnimeter", new Vector2(760, 0), Color.Black);
            sb.DrawString(MainGame.font, "Angle: " + angle1, new Vector2(10, 20), Color.Black);
            sb.DrawString(MainGame.font, "Angle: " + angle2, new Vector2(760, 20), Color.Black);
        }
    }
}
