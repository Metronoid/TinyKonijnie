using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    class Endscreen
    {
        public static SpriteFont font;
        public static int winner = 0;
        SceneManager controller;
        Texture2D background;
        Texture2D grijskonijn;
        Texture2D bruinkonijn;
        Texture2D grijszuil;
        Texture2D bruinzuil;
        Texture2D goudwortel;
        public int bruinkoy;
        public int grijskoy;
        public int bruinply;
        public int grijsply;
        //GUIM screenInterface = new GUIM();



        public Endscreen()
        {
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(SceneManager controller)
        {
            this.controller = controller;
            // Create a new SpriteBatch, which can be used to draw textures.
            font = controller.Content.Load<SpriteFont>("Cartoon12");
            grijskonijn = controller.Content.Load<Texture2D>("konijn_grijs");
            bruinkonijn = controller.Content.Load<Texture2D>("konijn_bruin");
            background = controller.Content.Load<Texture2D>("endscreen_bg");
            grijszuil = controller.Content.Load<Texture2D>("plateau");
            bruinzuil = controller.Content.Load<Texture2D>("plateau");
            goudwortel = controller.Content.Load<Texture2D>("Wortel");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            controller.spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            controller.spriteBatch.Draw(bruinzuil, new Rectangle(245, (controller.graphics.PreferredBackBufferHeight / 2 - (bruinkonijn.Height / 2) + 255), (int)(bruinzuil.Width * 0.8), (int)(bruinzuil.Height * 0.8)), Color.White);
            controller.spriteBatch.Draw(grijszuil, new Rectangle(655, (controller.graphics.PreferredBackBufferHeight / 2 - (grijskonijn.Height / 2) + 255), (int)(grijszuil.Width * 0.8), (int)(grijszuil.Height * 0.8)), Color.White);
            controller.spriteBatch.Draw(bruinkonijn, new Rectangle(210, (controller.graphics.PreferredBackBufferHeight / 2 - (bruinkonijn.Height / 2)), (int)(bruinkonijn.Width * 0.8), (int)(bruinkonijn.Height * 0.8)), Color.White);
            controller.spriteBatch.Draw(grijskonijn, new Rectangle(620, (controller.graphics.PreferredBackBufferHeight / 2 - (grijskonijn.Height / 2)), (int)(grijskonijn.Width * 0.8), (int)(grijskonijn.Height * 0.8)), Color.White);
        }
    }
}
