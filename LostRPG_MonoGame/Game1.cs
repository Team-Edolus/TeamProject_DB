namespace LostRPG_MonoGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using LostRPG_MonoGame.Data.Interfaces;
    using LostRPG_MonoGame.Models.Controllers;
    using LostRPG_MonoGame.Models.GameEngine;
    using LostRPG_MonoGame.Models.Graphics;
    using LostRPG_MonoGame.Models.Interfaces;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;
        ////
        private IGraphicsEngine graphicsEngine;

        private IUserInputInterface controller;

        private Engine engine;

        private IUnitOfWork unitOfWork;

        private IGameStateInformation gameStateInformation;

        public Game1(IUnitOfWork unitOfWork)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            ////graphics.IsFullScreen = true;
            this.IsMouseVisible = true;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            this.unitOfWork = unitOfWork;
            this.gameStateInformation = this.unitOfWork.GetGameStateInformation();
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

            this.engine = new Engine(this.controller, painter, this.gameStateInformation);

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
