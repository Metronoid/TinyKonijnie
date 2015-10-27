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
        public float water = 100;
        public Vector2 position = new Vector2(10,30);
        public bool check = true;
        public Water(Vector2 pos)
        {
            this.position = pos;
        }

        public void WaterChange()
        {
            if (check == true)
            {
                if (Math.Round(water) > 0)
                    water -= 0.05f;
                else
                    water = 0;
            }
            else
                check = true;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(MainGame.font, "H20: " + Math.Round(water) + "%", position, Color.Yellow);
        }
    }
}
