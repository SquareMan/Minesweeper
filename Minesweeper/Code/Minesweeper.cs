using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.Controller;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper {
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Minesweeper : Game {
        private readonly GameController _gameController;
        private readonly GuiManager _gui;

        private readonly InputListenerComponent _inputManager;

        private GuiButtonControl _button;
        private GraphicsDeviceManager _graphics;
        private GuiVerticalSliderControl _slider;
        private SpriteBatch _spriteBatch;

        public Minesweeper() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _inputManager = new InputListenerComponent(this);

            var guiInputService = new GuiInputService(_inputManager);
            _gui = new GuiManager(Services, guiInputService);

            _gameController = new GameController();
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            _gui.Screen = new GuiScreen(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _gui.Screen.Desktop.Bounds = new UniRectangle(
                new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));
            _gui.Initialize();

            _button = new GuiButtonControl {
                Name = "button",
                Bounds = new UniRectangle(new UniScalar(0.5f, -50), new UniScalar(0, 20), 100, 24),
                Text = "Start Game"
            };

            _button.Pressed += (sender, e) => { GameController.Instance.StartGame(); };

            _gui.Screen.Desktop.Children.Add(_button);

            _slider = new GuiVerticalSliderControl {
                Name = "slider",
                Bounds = new UniRectangle(20, 20, 20, 200),
                ThumbSize = .2f
            };
            _gui.Screen.Desktop.Children.Add(_slider);

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _button.Bounds.Location.Y = _slider.Bounds.Top + _slider.ThumbPosition * _slider.Bounds.Size.Y;

            _inputManager.Update(gameTime);
            _gui.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gui.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}