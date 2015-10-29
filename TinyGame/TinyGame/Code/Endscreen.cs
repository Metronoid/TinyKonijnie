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
        public static int winner = 2;
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
        public int winnerx;
        public int loserx;
        public int wortely;
        public int counter;
        public int wortelcounter;
        public float wortelfade;
        public float textfade;
        public bool startheight = true;
        public bool shiny = false;

        private enum Steps
        {
            Setup,
            AscendBoth,
            BrownWin,
            GrayWin,
            Carrot,
            BrownFall,
            GrayFall,
            Text,
            End
        }
        Steps ending = Steps.Setup;
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
            switch (ending)
            {
                case Steps.Setup:
                    if (winner == 1)
                    {
                        winnerx = 290;
                        loserx = 700;
                    }

                    if (winner == 2)
                    {
                        winnerx = 700;
                        loserx = 290;
                    }

                    counter = 0;
                    wortely = 20;
                    bruinkoy = ((controller.graphics.PreferredBackBufferHeight) - (bruinkonijn.Height / 2));
                    grijskoy = ((controller.graphics.PreferredBackBufferHeight) - (grijskonijn.Height / 2));
                    bruinply = bruinkoy + 255;
                    grijsply = grijskoy + 255;
                    ending = Steps.AscendBoth;
                    break;

                case Steps.AscendBoth:
                    counter++;
                    bruinkoy--;
                    grijskoy--;
            bruinply = bruinkoy + 255;
            grijsply = grijskoy + 255;

                    if (counter == 200 && winner == 1)
                    {
                        counter = 0;
                        ending = Steps.BrownWin;
                    }

                    if (counter == 200 && winner == 2)
                    {
                        counter = 0;
                        ending = Steps.GrayWin;
                    }
                    break;

                case Steps.BrownWin:
                    counter++;
                    bruinkoy--;
                    bruinply = bruinkoy + 255;

                    if (counter == 150)
                    {
                        counter = 0;
                        ending = Steps.Carrot;
                    }

                    break;

                case Steps.GrayWin:
                    counter++;
                    grijskoy--;
                    grijsply = grijskoy + 255;

                    if (counter == 150)
                    {
                        counter = 0;
                        ending = Steps.Carrot;
                    }

                    break;

                case Steps.Carrot:
                    if (shiny == false)
                    {
                        wortelfade += 0.04F;
                        wortelcounter++;
                        if (wortelcounter == 25)
                        {
                            shiny = true;
                            wortelcounter = 0;
                        }
                    }

                    if (shiny == true)
                    {
                        wortelfade -= 0.04F;
                        wortelcounter++;
                        if (wortelcounter == 25)
                        {
                            shiny = false;
                            wortelcounter = 0;
                        }
                    }
                    counter++;
                    wortely++;

                    if (counter == 320)
                    {
                        counter = 0;
                        wortelfade = 1;

                        if (winner == 1)
                            ending = Steps.GrayFall;

                        if (winner == 2)
                            ending = Steps.BrownFall;
                    }
                    break;

                case Steps.GrayFall:
                    counter++;
                    grijskoy += 5;
                    grijsply = grijskoy + 255;

                    if (counter == 75)
                    {
                        counter = 0;
                        ending = Steps.Text;
                    }

                    break;

                case Steps.BrownFall:
                    counter++;
                    bruinkoy += 5;
                    bruinply = bruinkoy + 255;

                    if (counter == 75)
                    {
                        counter = 0;
                        ending = Steps.Text;
                    }

                    break;

                case Steps.Text:
                    counter++;
                    textfade += 0.05F;

                    if (counter == 40)
                        ending = Steps.End;
                    break;

                case Steps.End:
                    if (Keyboard.GetState().GetPressedKeys().Length > 0)
                        controller.Exit();
                    break;
            }
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            if (controller != null)
            {
                controller.spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
                controller.spriteBatch.Draw(bruinzuil, new Rectangle(245, bruinply, (int)(bruinzuil.Width * 0.8), (int)(bruinzuil.Height * 0.8)), Color.White);
                controller.spriteBatch.Draw(grijszuil, new Rectangle(655, grijsply, (int)(grijszuil.Width * 0.8), (int)(grijszuil.Height * 0.8)), Color.White);
                controller.spriteBatch.Draw(bruinkonijn, new Rectangle(210, bruinkoy, (int)(bruinkonijn.Width * 0.8), (int)(bruinkonijn.Height * 0.8)), Color.White);
                controller.spriteBatch.Draw(grijskonijn, new Rectangle(620, grijskoy, (int)(grijskonijn.Width * 0.8), (int)(grijskonijn.Height * 0.8)), Color.White);
                controller.spriteBatch.Draw(goudwortel, new Rectangle(winnerx, wortely, goudwortel.Width, goudwortel.Height), Color.White * wortelfade);
                controller.spriteBatch.DrawString(font, "Player " + winner + " Wins!", new Vector2(winnerx,200), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Created By:", new Vector2(loserx, 200), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Wander van der Wal", new Vector2(loserx, 250), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Sandra Elzinga", new Vector2(loserx, 300), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Henkjan Braaksma", new Vector2(loserx, 350), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Nijwanda Janga", new Vector2(loserx, 400), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Jeroen Jonker", new Vector2(loserx, 450), Color.DarkBlue * textfade);
                controller.spriteBatch.DrawString(font, "Press any key to exit", new Vector2(loserx, 600), Color.DarkBlue * textfade);
            }
    }
}
}
