using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TinyGame
{

    class CollisionSystem
    {
        public static List<Rectangle> lijst = new List<Rectangle>();

        public static bool CollisionDetection(Rectangle box)
        {

            foreach(Rectangle a in lijst)
            {
                if (a.Intersects(box))
                    return true;
            }
            return false;

           
        }
    }
}
