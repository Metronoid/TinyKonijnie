using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Water
    {
        public int water = 100;
        public int waterCounter = 0;
        public Vector2 position = new Vector2(10,30);
        public Water(Vector2 pos)
        {
            this.position = pos;
        }

        public void WaterChange()
        {
            if (waterCounter < 20)
                waterCounter++;
            else
            {
                if (water > 0)
                    water--;
                waterCounter = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(MainGame.font, "H20: " + water + "%", position, Color.Black);
        }
    }
}
