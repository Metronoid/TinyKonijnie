﻿using System;
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
        /// Geeft aan welke  
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
        /// 
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X - image.Width / 2), (int)(location.Y - image.Height / 2), image.Width, image.Height);
            sb.Draw(image, location, Color.White);
        }
    }
}
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