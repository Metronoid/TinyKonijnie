using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    class Checkpoint : CollisionComponent
    {
        public Rectangle area;
        public Texture2D image;
        public Checkpoint(Rectangle area, Texture2D image, int number)
        {
            this.area = area;
            this.image = image;
            id = "Checkpoint" + number;
            CollisionSystem.triggers.Add(this);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, area, Color.Wheat);
        }
    }

}
