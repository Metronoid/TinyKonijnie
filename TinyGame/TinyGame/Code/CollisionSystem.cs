using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TinyGame
{

    class CollisionSystem
    {
        public static List<object> colliders = new List<object>();
        public static List<object> triggers = new List<object>();

        public static object CollisionDetection(Rectangle box)
        {
            foreach(Rectangle a in colliders)
            {
                if (a.Intersects(box) && box != a)
                    return a;
            }
            return null;
        }

        public static object TriggerDetection(Rectangle box) 
        {
            foreach (Rectangle a in triggers)
            {
                if (a.Intersects(box) && box != a)
                    return a;
            }
            return null;
        }
    }
}
