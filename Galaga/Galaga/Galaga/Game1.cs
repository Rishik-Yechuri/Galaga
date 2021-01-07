using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Galaga
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle background;
        Rectangle name;
        Rectangle arrow;
        Texture2D galagaNameArt;
        Texture2D space;
        Texture2D pointer;
        SpriteFont homefont;
        KeyboardState old;
        bool mainmenu;
        bool oneplayer;
        bool twoplayer;
        bool highscore;
        Vector2 arrowPos;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            graphics.ApplyChanges();
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
            background = new Rectangle(0,0,GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            name = new Rectangle(GraphicsDevice.Viewport.Width/2 - 160, 100,320,179);
            arrow = new Rectangle(name.X+50,name.Y+200,25,25);
            arrowPos = new Vector2(arrow.X,arrow.Y);
            mainmenu = true;
            oneplayer = false;
            twoplayer = false;
            highscore = false;
            old = Keyboard.GetState();
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
            space = this.Content.Load<Texture2D>("space");
            galagaNameArt = this.Content.Load<Texture2D>("galaga");
            pointer = this.Content.Load<Texture2D>("Pointer");
            homefont = this.Content.Load<SpriteFont>("HomePlayerSelection");
            // TODO: use this.Content to load your game content here
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
            KeyboardState kb = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if(kb.IsKeyDown(Keys.Down) && !old.IsKeyDown(Keys.Down))
            {
                if (arrow.Y == arrowPos.Y)
                    arrow.Y += 50;
                else
                    arrow.Y = (int)arrowPos.Y;
            }
            if (kb.IsKeyDown(Keys.Up) && !old.IsKeyDown(Keys.Up))
            {
                if (arrow.Y == arrowPos.Y)
                    arrow.Y += 50;
                else
                    arrow.Y = (int)arrowPos.Y;
            }
            old = kb;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(space,background,Color.White);
            if(mainmenu)
            {
                spriteBatch.Draw(galagaNameArt, name, Color.White);
                spriteBatch.Draw(pointer,arrow,Color.White);
                spriteBatch.DrawString(homefont,"One Player",new Vector2(arrowPos.X + 50,arrowPos.Y), Color.White);
                spriteBatch.DrawString(homefont, "Two Player", new Vector2(arrowPos.X + 50, arrowPos.Y + 50), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
