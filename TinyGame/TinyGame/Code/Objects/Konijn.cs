using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    public class Konijn
    {
        public Vector2 location;
        public Texture2D image;
        public Vector2 velocity;
        public GameTime gameTime;

        public Konijn(Vector2 location, Texture2D image)
        {
            this.location = location;
            this.image = image;
        }



        public void Update(float elapsed)
        {
            // Is voor consisten Frame rate
            location += velocity * elapsed;

            // TODO: Add your update logic here

            velocity = new Vector2(0, 0);


            if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X = -80;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = 80;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                velocity.Y = 80;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                velocity.Y = -80;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, location, Color.White);
        }


    }
}
