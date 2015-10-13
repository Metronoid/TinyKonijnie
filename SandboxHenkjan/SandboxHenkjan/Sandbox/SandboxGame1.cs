using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SandboxGame1 : Game
    {
        private int score;
        private Texture2D konijn;
        private float angle = 0;
        private SpriteFont scorefont;
        private SandboxAnimatedSprite animatedSprite;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SandboxGame1()
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

            // TODO: use this.Content to load your game content here
            Texture2D image = Content.Load<Texture2D>("Graphics/Snuffel");
            konijn = Content.Load<Texture2D>("Graphics/Snuffel");
            scorefont = Content.Load<SpriteFont>("Fonts/Score");
            Texture2D smiley = Content.Load<Texture2D>("Graphics/SmileyWalk");
            //haha
            animatedSprite = new SandboxAnimatedSprite(smiley, 4, 4);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            score++;
            animatedSprite.Update();
            angle += 0.01f;
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
            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, konijn.Width, konijn.Height);
            Vector2 origin = new Vector2(konijn.Width / 2, konijn.Height / 2);

            spriteBatch.Draw(konijn, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            spriteBatch.DrawString(scorefont, "Score" + score, new Vector2(0, 0), Color.Black);
            spriteBatch.End();

            animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
        }
    }
}
