using Microsoft.Xna.Framework.Media;

namespace Bejewled.View
{
    using System;

    using Bejewled.Model;
    using Bejewled.Model.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BejeweledView : Game, IView
    {

        private readonly Texture2D[] textureTiles;

        private readonly GraphicsDeviceManager graphics;

        private Texture2D grid;

        private BejeweledPresenter presenter;

        private SpriteBatch spriteBatch;
        private AssetManager assetManager;

        private Score score;

        private SpriteFont scoreFont;

        public BejeweledView()
        {
            this.textureTiles = new Texture2D[7];
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.PreferredBackBufferWidth = 800;
            this.Content.RootDirectory = "Content";
            this.score = new Score();
            assetManager = new AssetManager(Content);
        }

        public event EventHandler OnLoad;

        public int[,] Tiles { get; set; }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            this.spriteBatch.Draw(this.grid, Vector2.Zero, Color.White);
            this.spriteBatch.End();
            var scale = 0.5f;
            this.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            
            this.spriteBatch.Draw(
                this.textureTiles[0], 
                new Vector2(250, 115), 
                null, 
                Color.White, 
                0f, 
                Vector2.Zero, 
                0.5f, 
                SpriteEffects.None, 
                0);
            this.spriteBatch.Draw(
                this.textureTiles[1],
                new Vector2(250, 50),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                0.5f,
                SpriteEffects.None,
                0);
            this.spriteBatch.DrawString(scoreFont,
                "Score: " + this.score.PlayerScore.ToString(),
                new Vector2(30, 120),
                Color.GreenYellow);
            this.spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
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
            this.presenter = new BejeweledPresenter(this, new GameBoard());
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.textureTiles[0] = this.Content.Load<Texture2D>(@"bluegemTrans");
            this.textureTiles[1] = this.Content.Load<Texture2D>(@"greengemTrans");
            this.textureTiles[2] = this.Content.Load<Texture2D>(@"purplegemTrans");
            this.textureTiles[3] = this.Content.Load<Texture2D>(@"rainbowTrans");
            this.textureTiles[4] = this.Content.Load<Texture2D>(@"redgemTrans");
            this.textureTiles[5] = this.Content.Load<Texture2D>(@"whitegemTrans");
            this.textureTiles[6] = this.Content.Load<Texture2D>(@"yellowgemTrans");
            this.grid = this.Content.Load<Texture2D>(@"boardFinal");
            this.scoreFont = this.Content.Load<SpriteFont>("scoreFont");


            if (this.OnLoad != null)
            {
                this.OnLoad(this, EventArgs.Empty);
            }
          this.assetManager.PlayMusic("snd_music");

      

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }
   //     public static AssetManager AssetManager
     //   {
       //     get { return assetManager; }
        //}
    }
   
}