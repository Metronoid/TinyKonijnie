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
        public Keys back;

        public Controls(Keys l, Keys r, Keys u, Keys b) {
            left = l;right = r;up = u;back = b;
        }
    }
}
