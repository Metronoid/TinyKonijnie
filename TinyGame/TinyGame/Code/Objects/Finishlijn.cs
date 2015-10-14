﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Finishlijn
    {
        public Texture2D image;
        public Vector2 location;
        public Rectangle bounds;

        public Finishlijn (Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            CollisionSystem.colliders.Add(bounds);
        }

        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)(location.X - image.Width / 2), (int)(location.Y - image.Height / 2), image.Width, image.Height);
            sb.Draw(image, location, Color.White);
        }
    }
}