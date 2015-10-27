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
        Texture2D logo;
        Song jingle;

        private float nhlfadeeffect = 0;
        private int counter = 0;
        private bool nhlfadeout = false;
        private bool muziekaan = false;

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
            logo = Content.Load<Texture2D>("NHL logo");
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

            if (counter == 150)
                nhlfadeout = true;

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

            if (nhlfadeout == true)
            {
                nhlfadeeffect -= 0.01f;
                counter++;
            }

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
            spriteBatch.Draw(logo, new Rectangle((graphics.PreferredBackBufferWidth/2 - (logo.Width/2)), graphics.PreferredBackBufferHeight/2 - (logo.Height/2), logo.Width, logo.Height), Color.White * nhlfadeeffect);
            spriteBatch.End(); 

            base.Update(gameTime);
        }
    }
}
