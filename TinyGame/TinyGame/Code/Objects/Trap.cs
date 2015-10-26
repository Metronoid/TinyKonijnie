using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    class trap : CollisionComponent
    {
        public Texture2D image;
        public Vector2 location;
        public Vector2 size; 

        /// <summary>
        /// Geeft aan welke variabelen trap met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public trap(Vector2 location, Vector2 size)
        {
            this.location = location;
            this.size = size;
            id = "trap";
            CollisionSystem.triggers.Add(this);
        }


        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X), (int)(location.Y), (int)size.X, (int)size.Y);
            Vector2 origin = new Vector2(bounds.Width / 2, bounds.Height / 2);
           // sb.Draw(image, location, bounds, Color.White, 1, origin, 1.0f, SpriteEffects.None, 1);
        }
    }

}