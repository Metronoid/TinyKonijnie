using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TinyGame
{
    class Pitstop : CollisionComponent
    {
        public Texture2D image;
        public Rectangle location;

        /// <summary>
        /// Geeft aan welke variabelen Pitstop met zich meeneemt.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public Pitstop(Rectangle location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "Pitstop";
            CollisionSystem.colliders.Add(this);
            bounds = location;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, location, Color.White);
        }
    }
}
