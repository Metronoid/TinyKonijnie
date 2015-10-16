using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Blok : CollisionComponent
    {
        public Texture2D image;
        public Vector2 location;

        /// <summary>
        /// Geeft aan welke variabelen Blok met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public Blok (Vector2 location,Texture2D image )
        {
            this.location = location;
            this.image = image;
            id = "blok";
            CollisionSystem.colliders.Add(this);
        }
        /// <summary>
        /// Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X - image.Width / 2), (int)(location.Y - image.Height / 2), image.Width, image.Height);
            sb.Draw(image, location, Color.White);
        }
    }
}

///<summary>
/// Haha negeer dit vrienden
/// </summary>
/*
{
    class trap : CollisionComponent
    {
        public Texture2D image;
        public Vector2 location;

        public trap(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "trap";
            CollisionSystem.triggers.Add(this);
        }



        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X - image.Width / 2), (int)(location.Y - image.Height / 2), image.Width, image.Height);
            sb.Draw(image, location, Color.White);
        }
    }

}
*/