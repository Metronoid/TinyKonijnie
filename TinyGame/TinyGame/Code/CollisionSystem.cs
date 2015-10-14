using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TinyGame
{

    class CollisionSystem
    {
        public static List<Rectangle> coliders = new List<Rectangle>();
        public static List<Rectangle> triggers = new List<Rectangle>();

        public static bool CollisionDetection(Rectangle box)
        {
            foreach(Rectangle a in coliders)
            {
                if (a.Intersects(box) && box != a)
                    return true;
            }
            return false;
        }

        public static bool TriggerDetection(Rectangle box)
        {
            foreach (Rectangle a in triggers)
            {
                if (a.Intersects(box) && box != a)
                    return true;
            }
            return false;
        }
    }
}
