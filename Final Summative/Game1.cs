using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        KeyboardState keyboardState;
        Texture2D spaceshipTexture;
        Player spaceship;
        enum Screen
        {
            intro,
            game,
            game_over,
            game_win
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _graphics.PreferredBackBufferWidth = 550;
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.ApplyChanges();

            spaceship = new Player(spaceshipTexture, 10, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spaceshipTexture = Content.Load<Texture2D>("spaceshiptexture");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            spaceship.horizontalSpeed = 0;
            spaceship.verticalSpeed = 0;
            if (keyboardState.IsKeyDown(Keys.D))
                spaceship.horizontalSpeed = 3;
            else if (keyboardState.IsKeyDown(Keys.A))
                spaceship.horizontalSpeed = -3;
            if (keyboardState.IsKeyDown(Keys.W))
                spaceship.verticalSpeed = -3;
            else if (keyboardState.IsKeyDown(Keys.S))
                spaceship.verticalSpeed = 3;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (Screen == Screen.intro)
            {

            }
            else if (Screen == Screen.game)
            {
                spaceship.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}