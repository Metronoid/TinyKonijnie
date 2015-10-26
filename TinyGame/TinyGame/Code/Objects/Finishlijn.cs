using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Finishlijn : CollisionComponent
    {
        public Texture2D image;
        
        public Rectangle location;

        /// <summary>
        /// Geeft aan welke variabelen Finishlijn met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public Finishlijn (Rectangle location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "Finish";
            CollisionSystem.colliders.Add(this);

            if (CollisionSystem.CollisionDetection(this) != null)
            {
             
            }
        }
        /// <summary>
        /// Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>

        public void Draw(SpriteBatch sb)
        {
            bounds = location;
            sb.Draw(image, location, Color.White);
        }
    }
}
