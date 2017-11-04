using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Minesweeper : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        InputListenerComponent _inputManager;
        GuiManager _gui;

        GuiButtonControl button;
        GuiVerticalSliderControl slider;

        public Minesweeper()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _inputManager = new InputListenerComponent(this);

            var guiInputService = new GuiInputService(_inputManager);
            _gui = new GuiManager(Services, guiInputService);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _gui.Screen = new GuiScreen(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _gui.Screen.Desktop.Bounds = new UniRectangle(new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));
            _gui.Initialize();

            button = new GuiButtonControl {
                Name = "button",
                Bounds = new UniRectangle(new UniScalar(0.5f, -50), new UniScalar(0, 20), 100, 24),
                Text = "Quit Game",
            };

            button.Pressed += (object sender, System.EventArgs e) => { Exit(); };

            _gui.Screen.Desktop.Children.Add(button);

            slider = new GuiVerticalSliderControl {
                Name = "slider",
                Bounds = new UniRectangle(20, 20, 20, 200),
                ThumbSize = .2f
            };
            _gui.Screen.Desktop.Children.Add(slider);

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            button.Bounds.Location.Y = slider.Bounds.Top + slider.ThumbPosition * slider.Bounds.Size.Y;

            _inputManager.Update(gameTime);
            _gui.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _gui.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
