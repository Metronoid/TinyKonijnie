using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    class Checkpoint : CollisionComponent
    {
        public Vector2 location;

        public Checkpoint(Vector2 location, Texture2D image)
        {
            this.location = location;
            id = "Checkpoint";
            this.location = location;
            CollisionSystem.triggers.Add(this);
        }
    }
}
