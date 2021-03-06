﻿using Microsoft.Xna.Framework;
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
        Pitstop Pitstop;
        Finishlijn finish;
        Powerup speedboost1;
        Powerup speedboost2;
        trap spin1;
        trap spin2;
        trap spin3;
        trap spin4;
        trap spin5;
        trap spin6;
  
        Checkpoint check1;
        Checkpoint check2;
        Checkpoint check3;
        GraphicsDevice device;
        Texture2D background;
        Texture2D konijn1;
        Texture2D konijn2;
        public static SpriteFont font;
        public static Rectangle backgroundbound = new Rectangle(0, 0, 1024, 768);
        public static Rectangle konijn1bound = new Rectangle(0, 6, 83, 75); 
        public static Rectangle konijn2bound = new Rectangle(515, 6, 83, 75);
        SceneManager controller;
        heet kook;
        heet kook1;
        heet kook2;
        heet kook3;
        



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


            speler = new Konijn(1,new Controls(Keys.S,Keys.Q,Keys.A,Keys.Z), new Vector2(800, 250), 1.55F, controller.Content.Load<Texture2D>("brownbunny"), controller.Content.Load<Texture2D>("SnuffelBounds"));
            speler2 = new Konijn(2, new Controls(Keys.Up, Keys.Left, Keys.Down, Keys.Right ), new Vector2(880, 320), 1.55F, controller.Content.Load<Texture2D>("greybunny"), controller.Content.Load<Texture2D>("SnuffelBounds"));

            Pitstop = new Pitstop(new Rectangle(11, 219, 155, 310), controller.Content.Load<Texture2D>("RodeBalk"));

            finish = new Finishlijn(new Rectangle(777, 357, 132, 43), controller.Content.Load<Texture2D>("Finish"));

            //speedboost1 = new Powerup(new Vector2(190, 345), controller.Content.Load<Texture2D>("speed"));
            //speedboost2 = new Powerup(new Vector2(890, 625), controller.Content.Load<Texture2D>("SmileOrb"));

            check1 = new Checkpoint(new Rectangle(485, 475, 40, 187), controller.Content.Load< Texture2D>("SnuffelBounds"), 1);
            check2 = new Checkpoint(new Rectangle(40, 370, 270, 53), controller.Content.Load<Texture2D>("SnuffelBounds"), 2);
            check3 = new Checkpoint(new Rectangle(406, 85, 40, 197), controller.Content.Load<Texture2D>("SnuffelBounds"), 3);
            kook = new heet(new Vector2(267, 399), controller.Content.Load<Texture2D>("pit_l"), controller.Content.Load<Texture2D>("SnuffelBounds"));
            kook1 = new heet(new Vector2(292, 180), controller.Content.Load<Texture2D>("pit_m"), controller.Content.Load<Texture2D>("SnuffelBounds"));
            kook2 = new heet(new Vector2(580, 180), controller.Content.Load<Texture2D>("pit_m"), controller.Content.Load<Texture2D>("SnuffelBounds"));
            kook3 = new heet(new Vector2(604, 445), controller.Content.Load<Texture2D>("pit_s"), controller.Content.Load<Texture2D>("SnuffelBounds"));

            spin1 = new trap(new Vector2(0, 0), new Vector2(1021,93), controller.Content.Load<Texture2D>("RodeBalk"));
            spin2 = new trap(new Vector2(905, 0), new Vector2(124,667), controller.Content.Load<Texture2D>("RodeBalk"));
            spin3 = new trap(new Vector2(40, 659), new Vector2(877, 56), controller.Content.Load<Texture2D>("RodeBalk"));
            spin4 = new trap(new Vector2(0, 82), new Vector2(41, 605), controller.Content.Load<Texture2D>("RodeBalk"));
            spin5 = new trap(new Vector2(130, 215), new Vector2(47, 315), controller.Content.Load<Texture2D>("RodeBalk"));
            spin6 = new trap(new Vector2(352, 306), new Vector2(387, 145), controller.Content.Load<Texture2D>("RodeBalk"));
          




            GUI = new GUIM();

            background = controller.Content.Load<Texture2D>("newtrack");
            konijn1 = controller.Content.Load<Texture2D>("konijnhoofd_bruin");
            konijn2 = controller.Content.Load<Texture2D>("konijnhoofd_grijs");
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
            kook1.Update(elapsed);
            kook2.Update(elapsed);
            kook3.Update(elapsed);

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
                controller.spriteBatch.Draw(konijn1, konijn1bound, Color.White);
                controller.spriteBatch.Draw(konijn2, konijn2bound, Color.White);

                //check1.Draw(controller.spriteBatch);
                //check2.Draw(controller.spriteBatch);
                //check3.Draw(controller.spriteBatch);

                finish.Draw(controller.spriteBatch);

                //Pitstop.Draw(controller.spriteBatch);
                
                //speedboost1.Draw(controller.spriteBatch);
                //speedboost2.Draw(spriteBatch);
                /*spin1.Draw(controller.spriteBatch);
                spin2.Draw(controller.spriteBatch);
                spin3.Draw(controller.spriteBatch);
                spin4.Draw(controller.spriteBatch);
                spin5.Draw(controller.spriteBatch);
                spin6.Draw(controller.spriteBatch);
                 */

                GUI.Draw(controller.spriteBatch);
                kook.Draw(controller.spriteBatch);
                kook1.Draw(controller.spriteBatch);
                kook2.Draw(controller.spriteBatch);
                kook3.Draw(controller.spriteBatch);
                speler.Draw(controller.spriteBatch);
                speler2.Draw(controller.spriteBatch);
            }

        }
    }
}
