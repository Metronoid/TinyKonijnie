using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //GUIM screenInterface = new GUIM();
        GUIM GUI;
        Konijn speler;
        Konijn speler2;
        Blok rood;
        Finishlijn finish;
        Powerup speedboost;
        trap spin;
        public static SpriteFont font;
        


        public MainGame()
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

            speler = new Konijn(1, new Vector2(60, 40), Content.Load<Texture2D>("Snuffel"));
            speler2 = new Konijn(2, new Vector2(60, 120), Content.Load<Texture2D>("Snuffel"));

            rood = new Blok(new Vector2(0, 200), Content.Load<Texture2D>("RodeBalk"));

            finish = new Finishlijn(new Vector2(300, 100), Content.Load<Texture2D>("Finish"));
            speedboost = new Powerup(new Vector2(500, 500), Content.Load<Texture2D>("SmileOrb"));
            spin = new trap(new Vector2(300, 300), Content.Load<Texture2D>("AngerOrb"));
            GUI = new GUIM();
           
            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("Cartoon12");
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

            speler.Update(elapsed);
            speler2.Update(elapsed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            finish.Draw(spriteBatch);
            rood.Draw(spriteBatch);
            speedboost.Draw(spriteBatch);
            speler.Draw(spriteBatch);
            speler2.Draw(spriteBatch);
            spin.Draw(spriteBatch);
            GUI.Draw(spriteBatch);
            spriteBatch.End();

            base.Update(gameTime);
        }
    }
}
