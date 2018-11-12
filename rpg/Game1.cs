using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using rpg.Characters;
using rpg.Components;
using System;
using System.Collections.Generic;

namespace rpg
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static Game1 Instance;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player _player;
        private Sprite _map;
        private Camera _camera;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static int LimitHeight;
        public static int LimitWidth;

        public Game1()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            _player = new Player(GraphicsDevice);
            _camera = new Camera();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sprite player = new Sprite(Content.Load<Texture2D>("LightBandit_Spritesheet"), null);
            _player.LoadContent(player);
            _map = new Sprite(Content.Load<Texture2D>("MapTest"), new Vector2(0,0));
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                _player.Update(gameTime);
               _camera.Follow(_player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gold);

            spriteBatch.Begin(transformMatrix: _camera.Transform);

            _map.Draw(spriteBatch);
            _player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
