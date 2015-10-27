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
    public class Introscreen : Game
    {
        public static SpriteFont font;
        Texture2D NHLlogo;
        Texture2D teamlogo;
        Song jingle;

        private float nhlfadeeffect = 0;
        private float teamfadeeffect = 0;
        private int counter = 0;
        private bool nhlfadeout = false;
        private bool nhloff = false;
        private bool muziekaan = false;
        private bool vroem = false;

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

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //GUIM screenInterface = new GUIM();
        


        public Introscreen()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1024;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 768;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Cartoon12");
            NHLlogo = Content.Load<Texture2D>("NHL logo");
            teamlogo = Content.Load<Texture2D>("Team13logo");
            jingle = Content.Load<Song>("logo");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);

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
                    counter++;
                    if (counter == 150)
                        intro = Steps.Exit;
                    break;

                case Steps.Vroem:
                    break;

                case Steps.Team13in:
                    break;

                case Steps.Team13out:
                    break;

                case Steps.Exit:
                    
                    break;
            }

            /* if (counter == 150)
                nhlfadeout = true;

            if (counter == 250)
            {
                nhloff = true;
                vroem = true;
            }

            if (muziekaan == false)
            {
                MediaPlayer.Play(jingle);
                muziekaan = true;
            }

            if (nhlfadeout == false)
            {
                nhlfadeeffect += 0.01f;
                counter++;
            }

            if (nhlfadeout == true && nhloff == false)
            {
                nhlfadeeffect -= 0.01f;
                counter++;
            }*/

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(NHLlogo, new Rectangle((graphics.PreferredBackBufferWidth / 2 - (NHLlogo.Width / 2)), graphics.PreferredBackBufferHeight / 2 - (NHLlogo.Height / 2), NHLlogo.Width, NHLlogo.Height), Color.White * nhlfadeeffect);
            spriteBatch.Draw(teamlogo, new Rectangle((graphics.PreferredBackBufferWidth / 2 - (teamlogo.Width / 2)), graphics.PreferredBackBufferHeight / 2 - (teamlogo.Height / 2), teamlogo.Width, teamlogo.Height), Color.White * teamfadeeffect);
            spriteBatch.End(); 

            base.Update(gameTime);
        }
    }
}
