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
        public static string CollisionDetection(CollisionComponent caller)
        {
            foreach (CollisionComponent a in colliders)
            {
                if (a.bounds.Intersects(caller.bounds) && caller.bounds != a.bounds)
                    return a.id;
            }
            return "";
        }
        /// <summary>
        /// Get back the string id when you enter a trigger;
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static string TriggerDetection(CollisionComponent caller)
        {

            foreach (CollisionComponent a in triggers)
            {
                if (a.bounds.Intersects(caller.bounds) && caller.bounds != a.bounds)
                {
                    if (caller.triggerEntered)
                        return "";
                    caller.triggerEntered = true;
                    return a.id;
                }
            }
            caller.triggerEntered = false;
            return "";
        }

        public static CollisionComponent TriggerDetection(CollisionComponent caller, string id)
        {
            foreach (CollisionComponent a in triggers)
            {
                if (a.id == id)
                {
                    if (a.bounds.Intersects(caller.bounds) && caller.bounds != a.bounds)
                    {
                        if (caller.triggerEntered)
                            return null;
                        caller.triggerEntered = true;
                        return a;
                    }
                }
            }
            caller.triggerEntered = false;
            return null;
        }
    }
}
