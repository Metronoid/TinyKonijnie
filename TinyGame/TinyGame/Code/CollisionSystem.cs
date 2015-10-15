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
        /// Add to this list the objects for collision.
        /// </summary>
        public static List<CollisionComponent> colliders = new List<CollisionComponent>();
        /// <summary>
        /// Add to this list the objects for triggers.
        /// </summary>
        public static List<CollisionComponent> triggers = new List<CollisionComponent>();
        /// <summary>
        /// Get back the string id when you have a collision;
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static string CollisionDetection(Rectangle box)
        {
            List<Rectangle> t = new List<Rectangle>();
            foreach (CollisionComponent a in colliders)
            {
                if (a.bounds.Intersects(box) && box != a.bounds)
                    return a.id;
            }
            return "";
        }

        public static string TriggerDetection(Rectangle box)
        {
            List<Rectangle> t = new List<Rectangle>();
            foreach (CollisionComponent a in triggers)
            {
                if (a.bounds.Intersects(box) && box != a.bounds)
                    return a.id;
            }
            return "";
        }
    }
}
