using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace TinyGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Introscreen
    {
        public static SpriteFont font;
        Texture2D NHLlogo;
        Texture2D teamlogo;
        Texture2D konijn;
        Song jingle;
        public int bunnyx = -200;

        private float nhlfadeeffect = 0;
        private float teamfadeeffect = 0;
        private int counter = 0;

        private enum Steps
        {
            Music,
            NHLin,
            NHLout,
            Vroem,
            Team13in,
            Team13out,
            Exit
        }
        Steps intro = Steps.Music;
        SceneManager controller;
        //GUIM screenInterface = new GUIM();



        public Introscreen()
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
            NHLlogo = controller.Content.Load<Texture2D>("NHL logo");
            teamlogo = controller.Content.Load<Texture2D>("Team13logo");
            jingle = controller.Content.Load<Song>("logo");
            konijn = controller.Content.Load<Texture2D>("Snuffel");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                SceneManager.state = SceneManager.Scenes.game;
                MediaPlayer.Stop();
            }


            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (intro)
            {
                case Steps.Music:
                    MediaPlayer.Play(jingle);
                    intro = Steps.NHLin;
                    break;

                case Steps.NHLin:
                    nhlfadeeffect += 0.01f;
                    counter++;
                    if (counter == 150)
                        intro = Steps.NHLout;
                    break;

                case Steps.NHLout:
                    nhlfadeeffect -= 0.01f;
                    counter--;
                    if (counter == -10)
                    {
                        counter = 0;
                        intro = Steps.Vroem;
                    }
                    break;

                case Steps.Vroem:
                    bunnyx += 20;
                    counter++;
                    if (counter == 80)
                    {
                        counter = 0;
                        intro = Steps.Team13in;
                    }

                    break;

                case Steps.Team13in:
                    teamfadeeffect += 0.01f;
                    counter++;
                    if (counter == 150)
                        intro = Steps.Team13out;

                    break;

                case Steps.Team13out:
                    teamfadeeffect -= 0.01f;
                    counter--;
                    if (counter == -10)
                    {
                        counter = 0;
                        intro = Steps.Exit;
                    }
                    break;

                case Steps.Exit:
                    if (controller != null)
                        SceneManager.state = SceneManager.Scenes.game;
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

            controller.spriteBatch.Draw(NHLlogo, new Rectangle((controller.graphics.PreferredBackBufferWidth / 2 - (NHLlogo.Width / 2)), controller.graphics.PreferredBackBufferHeight / 2 - (NHLlogo.Height / 2), NHLlogo.Width, NHLlogo.Height), Color.White * nhlfadeeffect);
            controller.spriteBatch.Draw(teamlogo, new Rectangle((controller.graphics.PreferredBackBufferWidth / 2 - (teamlogo.Width / 2)), controller.graphics.PreferredBackBufferHeight / 2 - (teamlogo.Height / 2), teamlogo.Width, teamlogo.Height), Color.White * teamfadeeffect);
            controller.spriteBatch.Draw(konijn, new Rectangle(bunnyx, (controller.graphics.PreferredBackBufferHeight / 2 - (konijn.Height / 2)), konijn.Width, konijn.Height), Color.White);
        }
    }
}
