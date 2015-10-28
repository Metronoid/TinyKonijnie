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
        public Konijn controller;

        public void Initialise(Konijn controller)
        {
            this.controller = controller;
        }
        public void OnDestroy()
        {
            CollisionSystem.triggers.Remove(this);
            if(controller!=null)
            controller.valtrap = null;
        }

    }
}
