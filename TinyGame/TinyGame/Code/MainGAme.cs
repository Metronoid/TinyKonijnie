using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame
    {
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
        SceneManager controller;
        heet kook;
        


        public MainGame()
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
            // Create a new SpriteBatch, which can be used to draw textures.
            this.controller = controller;

            speler = new Konijn(1, new Vector2(800, 250), 1.55F, controller.Content.Load<Texture2D>("brownbunny"), controller.Content.Load<Texture2D>("SnuffelBounds"));
            speler2 = new Konijn(2, new Vector2(880, 320), 1.55F, controller.Content.Load<Texture2D>("greybunny"), controller.Content.Load<Texture2D>("SnuffelBounds"));

            
            Pitstop = new Pitstop(new Vector2(0, 140), controller.Content.Load<Texture2D>("RodeBalk"));

            finish = new Finishlijn(new Rectangle(777, 357, 132, 43), controller.Content.Load<Texture2D>("Finish"));

            speedboost1 = new Powerup(new Vector2(10, 50), controller.Content.Load<Texture2D>("SmileOrb"));
            speedboost2 = new Powerup(new Vector2(890, 625), controller.Content.Load<Texture2D>("SmileOrb"));

            check1 = new Checkpoint(new Rectangle(485, 542, 40, 117), controller.Content.Load< Texture2D>("SnuffelBounds"), 1);
            check2 = new Checkpoint(new Rectangle(40, 370, 270, 53), controller.Content.Load<Texture2D>("SnuffelBounds"), 2);
            check3 = new Checkpoint(new Rectangle(406, 85, 40, 117), controller.Content.Load<Texture2D>("SnuffelBounds"), 3);
            kook = new heet(new Vector2(300, 450), controller.Content.Load<Texture2D>("pit_l"));
            kook = new heet(new Vector2(300, 250), controller.Content.Load<Texture2D>("pit_m"));
            kook = new heet(new Vector2(500, 250 ), controller.Content.Load<Texture2D>("pit_m"));
            kook = new heet(new Vector2(500, 450), controller.Content.Load<Texture2D>("pit_s"));
            spin1 = new trap(new Vector2(540, 370), new Vector2(730,540), controller.Content.Load<Texture2D>("SnuffelBounds"));
            //spin2 = new trap(new Vector2(450, 275), Content.Load<Texture2D>("AngerOrb"));
            //spin3 = new trap(new Vector2(450, 350), Content.Load<Texture2D>("AngerOrb"));

            GUI = new GUIM();

            background = controller.Content.Load<Texture2D>("track");
            // TODO: use this.Content to load your game content here
            font = controller.Content.Load<SpriteFont>("Cartoon12");
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

            speler.Update(elapsed);
            speler2.Update(elapsed);
            kook.Update(elapsed);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw()
        {

            // TODO: Add your drawing code here
            if (controller != null)
            {
                controller.spriteBatch.Draw(background, backgroundbound, Color.White);

                //check1.Draw(controller.spriteBatch);
                //check2.Draw(controller.spriteBatch);
                //check3.Draw(controller.spriteBatch);

                //finish.Draw(spriteBatch);

            //Pitstop.Draw(controller.spriteBatch);
                
                //speedboost1.Draw(spriteBatch);
                //speedboost2.Draw(spriteBatch);
                //spin1.Draw(spriteBatch);
                //spin2.Draw(spriteBatch);
                //spin3.Draw(spriteBatch);
                speler.Draw(controller.spriteBatch);
                speler2.Draw(controller.spriteBatch);
                GUI.Draw(controller.spriteBatch);
                kook.Draw(controller.spriteBatch);
                kook.Draw(controller.spriteBatch);
                kook.Draw(controller.spriteBatch);
                kook.Draw(controller.spriteBatch);
            }

        }
    }
}
