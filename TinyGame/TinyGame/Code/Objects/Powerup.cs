using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TinyGame
{
    class Powerup : CollisionComponent
    {
        public Texture2D image;
        public Vector2 location;
        /// <summary>
        /// Geeft aan welke variabelen Powerup met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public Powerup(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "Powerup";
            CollisionSystem.triggers.Add(this);
            bounds = new Rectangle((int)location.X, (int)location.Y, image.Width, image.Height);
        }
        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, location, Color.White);
        }
    }

}
