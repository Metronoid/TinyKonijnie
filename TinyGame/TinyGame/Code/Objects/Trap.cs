﻿using System;
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
        public Vector2 location;
        public Vector2 size;
        public Texture2D image;

        /// <summary>
        /// Geeft aan welke variabelen trap met zich mee geeft. 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public trap(Vector2 location, Vector2 size, Texture2D image)
        {
            this.location = location;
            this.size = size;
            this.image = image;
            bounds = new Rectangle((int)location.X, (int)location.Y, (int)(size.X), (int)(size.Y));
            id = "trap";
            CollisionSystem.triggers.Add(this);
        }


        /// <summary>
        ///  Drawt de variabelen wanneer het wordt aangeroepen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            
            Vector2 origin = new Vector2(bounds.Width / 2, bounds.Height / 2);
            sb.Draw(image, bounds, Color.White);
            
        }
    }

}