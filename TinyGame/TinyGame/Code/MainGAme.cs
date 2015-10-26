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
        Pitstop Pitstop;
        Finishlijn finish;
        Powerup speedboost1;
        Powerup speedboost2;
        trap spin1;
        trap spin2;
        trap spin3;
        Checkpoint check1;
        Checkpoint check2;
        Checkpoint check3;
        GraphicsDevice device;
        Texture2D background;
        public static SpriteFont font;
        public static Rectangle backgroundbound = new Rectangle(0, 0, 1024, 768);
        


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

            speler = new Konijn(1, new Vector2(800, 250), 1.55F, Content.Load<Texture2D>("brownbunny"), Content.Load<Texture2D>("SnuffelBounds"));
            speler2 = new Konijn(2, new Vector2(880, 320), 1.55F, Content.Load<Texture2D>("greybunny"), Content.Load<Texture2D>("SnuffelBounds"));

            
            Pitstop = new Pitstop(new Vector2(0, 140), Content.Load<Texture2D>("RodeBalk"));

            finish = new Finishlijn(new Rectangle(777, 357, 132, 43), Content.Load<Texture2D>("Finish"));

            speedboost1 = new Powerup(new Vector2(10, 50), Content.Load<Texture2D>("SmileOrb"));
            speedboost2 = new Powerup(new Vector2(890, 625), Content.Load<Texture2D>("SmileOrb"));

            check1 = new Checkpoint(new Rectangle(485, 542, 40, 117), Content.Load< Texture2D>("SnuffelBounds"), 1);
            check2 = new Checkpoint(new Rectangle(40, 370, 270, 53), Content.Load<Texture2D>("SnuffelBounds"), 2);
            check3 = new Checkpoint(new Rectangle(406, 92, 40, 117), Content.Load<Texture2D>("SnuffelBounds"), 3);

            //spin1 = new trap(new Vector2(450, 200), Content.Load<Texture2D>("AngerOrb"));
            //spin2 = new trap(new Vector2(450, 275), Content.Load<Texture2D>("AngerOrb"));
            //spin3 = new trap(new Vector2(450, 350), Content.Load<Texture2D>("AngerOrb"));

            GUI = new GUIM();

            background = Content.Load<Texture2D>("track");
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
            spriteBatch.Draw(background, backgroundbound, Color.White);

            check1.Draw(spriteBatch);
            check2.Draw(spriteBatch);
            check3.Draw(spriteBatch);
            finish.Draw(spriteBatch);
            //Pitstop.Draw(spriteBatch);
            //speedboost1.Draw(spriteBatch);
            //speedboost2.Draw(spriteBatch);
            //spin1.Draw(spriteBatch);
            //spin2.Draw(spriteBatch);
            //spin3.Draw(spriteBatch);
            speler.Draw(spriteBatch);
            speler2.Draw(spriteBatch);
            GUI.Draw(spriteBatch);
            spriteBatch.End();

            base.Update(gameTime);
        }
    }
}
