using System;
using forest_keeper;
using forest_keeper.Entities;
using forest_keeper.Spawners;
using forest_keeper.Systems;
using forest_keeper.Systems.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class Game : Microsoft.Xna.Framework.Game
{
    const int WIDTH = 1280;
    const int HEIGHT = 720;

    private int frames;
    private SpriteBatch? batch;
    // private Texture2D? texture;
    private Assets assets;
    private World world;
    private RenderSystem renderSystem;
    private MovementSystem movementSystem;

    [STAThread]
    static void Main(string[] args)
    {
        using (Game g = new Game())
        {
            g.Run();
        }
    }

    private Game()
    {
        this.frames = 0;

        GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);
        gdm.PreferredBackBufferWidth = 1280;
        gdm.PreferredBackBufferHeight = 720;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;

        // All content loaded will be in a "Content" folder
        Content.RootDirectory = "Content";

        assets = new Assets();
        world =  new World();
        renderSystem = new RenderSystem();
        movementSystem = new MovementSystem();
    }

    protected override void Initialize()
    {
        /* This is a nice place to start up the engine, after
         * loading configuration stuff in the constructor
         */
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load textures, sounds, and so on in here...
        // Create the batch...
        batch = new SpriteBatch(GraphicsDevice);
        assets.LoadContent(Content);
        
        BallSpawner.Spawn(world, assets);
    }

    protected override void UnloadContent()
    {
        // Clean up after yourself!
        if (batch != null)
        {
            batch.Dispose();
        }

        assets?.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        // Run game logic in here. Do NOT render anything here!
        base.Update(gameTime);
        
        movementSystem.Update(world, gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.Clear(Color.FloralWhite);

        if (batch != null)
        {
            
            // var destination = new Rectangle(WIDTH / 2, HEIGHT / 2, texture!.Width, texture.Height);
            // var rotation = (float) gameTime.TotalGameTime.TotalMilliseconds / 150;
            // var rotationOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
            //
            // // Draw the texture to the corner of the screen
            // batch.Begin();
            // batch.Draw(texture, destination, null, Color.White, rotation, rotationOrigin, SpriteEffects.None, 0);
            // batch.End();
            renderSystem.Update(world, batch);
        }

        base.Draw(gameTime);
    }
}