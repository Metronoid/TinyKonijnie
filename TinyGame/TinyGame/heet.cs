using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    class heet : CollisionComponent
    {

        public Texture2D image;
        public Vector2 location;
        public float kookfade = 0;
        public int counter = 0;
        public bool heetst = false;
        public bool aanraak = false;

        public heet(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
            id = "heet";
            CollisionSystem.colliders.Add(this);
            bounds = new Rectangle((int)location.X, (int)location.Y, image.Width, image.Height);
        }


        public void Update(float elapsed)
        {

            if (aanraak == true)
            {

            }

            if (heetst == false)
            {
                kookfade += 0.01F;
                counter++;
                if (counter == 100)
                {
                    heetst = true;
                    counter = 0;
                }
            }

            if (heetst == true)
            {
                kookfade -= 0.01F;
                counter++;
                if (counter == 100)
                {
                    heetst = false;
                    counter = 0;
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, location, Color.White * kookfade);
        }
    }
}
