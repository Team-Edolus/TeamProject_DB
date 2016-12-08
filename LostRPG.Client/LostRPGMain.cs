// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable

namespace LostRPG.Client
{
    using LostRPG.Client.Controllers;
    using LostRPG.Client.GameEngine;
    using LostRPG.Client.Graphics;
    using LostRPG.Client.Interfaces;
    using LostRPG.Data.Repositories;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using QuakeConsole;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class LostRPGMain : Game
    {
        private readonly ConsoleComponent console;

        private readonly GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;
        ////
        private IGraphicsEngine graphicsEngine;

        private IUserInputInterface controller;
        
        private Engine engine;

        private IGameLoader gameLoader;

        private ConsoleHandler consoleHandler;

        private KeyboardState previousKeyboardState = Keyboard.GetState();
        private KeyboardState currentKeyboardState;

        public LostRPGMain()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            //this.graphics.IsFullScreen = true;
            this.IsMouseVisible = true;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            ////
            this.console = new ConsoleComponent(this);
            this.Components.Add(this.console);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ////
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //// Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            ////
            this.graphicsEngine = new GraphicsEngine(this.spriteBatch);
            this.controller = new ControllerUserInput();
            ITextureHandler textureHandler = new TextureHandler(this.Content);
            IPaintInterface painter = new PaintBrush(textureHandler, this.graphicsEngine);
            this.engine = new Engine(this.controller, painter);
            ////
            this.gameLoader = new GameLoader(new UnitOfWork(), this.engine);
            this.consoleHandler = new ConsoleHandler(this.console, this.gameLoader);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            //// TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            //    Keyboard.GetState().IsKeyDown(Keys.Escape))
            //{
            //    this.Exit();
            //}

            this.controller.CheckForInput();
            this.engine.Update(gameTime);
            //// TODO: Add your update logic here
            /// 
            this.currentKeyboardState = Keyboard.GetState();
            if (this.previousKeyboardState.IsKeyUp(Keys.F1) && this.currentKeyboardState.IsKeyDown(Keys.F1))
            {
                this.console.ToggleOpenClose();
            }


            this.previousKeyboardState = this.currentKeyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            ////GraphicsDevice.Clear(Color.BlanchedAlmond);

            this.graphicsEngine.RedrawAll(gameTime);

            ////spriteBatch.Begin();
            ////spriteBatch.Draw(Content.Load<Texture2D>("Character_16x24"), new Vector2(200, 200));
            ////spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
