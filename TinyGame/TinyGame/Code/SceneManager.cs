using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SceneManager : Game
    {
        public static SpriteFont font;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        MainGame game;
        Introscreen intro;
        Endscreen end;
        public enum Scenes
        {
            none,intro,menu,game,end
        };
        public static Scenes state = Scenes.intro;
        public Scenes lastState = Scenes.none;
        //GUIM screenInterface = new GUIM();

        public SceneManager()
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
            game = new MainGame();
            intro = new Introscreen();
            end = new Endscreen();
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1024;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 768;   // set this value to the desired height of your window
            graphics.IsFullScreen = true;
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

            if(Keyboard.GetState().IsKeyDown(Keys.F))
                graphics.ToggleFullScreen();

            if (state != lastState)
            {
                switch (state)
                {
                    case Scenes.intro:
                        intro.Initialize();
                        intro.LoadContent(this);
                        break;
                    case Scenes.menu:
                        //Handle
                        break;
                    case Scenes.game:
                        game.Initialize();
                        game.LoadContent(this);
                        break;
                    case Scenes.end:
                        end.Initialize();
                        end.LoadContent(this);
                        break;
                }
                lastState = state;

            }

            switch (state)
            {
                case Scenes.intro:
                    intro.Update(gameTime);
                    break;
                case Scenes.menu:
                    //Handle
                    break;
                case Scenes.game:
                    game.Update(gameTime);
                    break;
                case Scenes.end:
                    end.Update(gameTime);
                    break;
            }

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            switch (state)
            {
                case Scenes.intro:
                    intro.Draw(gameTime);
                    break;
                case Scenes.menu:
                    //Handle
                    break;
                case Scenes.game:
                    game.Draw();
                    break;
                case Scenes.end:
                    end.Draw(gameTime);
                    break;
            }
            spriteBatch.End();
            base.Update(gameTime);
        }
    }
}
