﻿using System;
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

        public Powerup(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "Powerup";
            CollisionSystem.triggers.Add(this);
        }

        public void Draw(SpriteBatch sb)
        {
            bounds = new Rectangle((int)location.X, (int)location.Y, image.Width, image.Height);
            sb.Draw(image, location, Color.White);
        }
    }

}