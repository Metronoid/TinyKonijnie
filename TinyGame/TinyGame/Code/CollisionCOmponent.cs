using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TinyGame
{
    public class CollisionComponent
    {
        public Rectangle bounds;
        public bool triggerEntered = false;
        public string id;
    }
}
