//PLEASE DO NOT CHANGE THE CODE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TinyGame
{
    /// <summary>
    /// CollisionSystem for checking collision based stuff.
    /// </summary>
    class CollisionSystem
    {
        /// <summary>
        /// Add to this list the moment
        /// </summary>
        public static List<CollisionComponent> colliders = new List<CollisionComponent>();
        public static List<CollisionComponent> triggers = new List<CollisionComponent>();

        public static object CollisionDetection(Rectangle box)
        {
            List<Rectangle> t = new List<Rectangle>();
            foreach (CollisionComponent a in colliders)
            {
                if (a.bounds.Intersects(box) && box != a.bounds)
                    return a;
            }
            return null;
        }

        public static object TriggerDetection(Rectangle box)
        {
            List<Rectangle> t = new List<Rectangle>();
            foreach (CollisionComponent a in colliders)
            {
                if (a.bounds.Intersects(box) && box != a.bounds)
                    return a;
            }
            return null;
        }
    }
}
