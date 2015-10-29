using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public struct Controls
    {
        public Keys left;
        public Keys right;
        public Keys up;
        public Keys down;

        public Controls(Keys up, Keys left, Keys down, Keys right) {
            this.left = left;this.right = right;this.up = up;this.down = down;
        }
    }
}
