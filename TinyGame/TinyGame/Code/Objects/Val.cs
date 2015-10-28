using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Val : CollisionComponent
    {
        public Texture2D image;
        public Vector2 location;
        public bool bSpawnVal = false;
        /// <summary>
        /// Geeft aan welke variabelen Val met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public Val(Vector2 location, Texture2D image,Konijn controller)
        {
            this.location = location;
            this.image = image;
            id = "Val";
            Initialise(controller);
            CollisionSystem.triggers.Add(this);
        }
        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)location.X, (int)location.Y, image.Width, image.Height);
            if (bSpawnVal == true)
            {
                sb.Draw(image, location, Color.White);
            }
        }
    }
}
