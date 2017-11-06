using System;
using Microsoft.Xna.Framework;
using Minesweeper.Model;
using Minesweeper.View.GUI;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;

namespace Minesweeper.Controller {
    public class GameController {
        public enum GameState {
            Initialization,
            MainMenu,
            Running
        }

        public static GameController Instance;

        private readonly Minesweeper _game;

        private readonly GuiManager _gui;
        private readonly InputListenerComponent _inputManager;
        private GUIMainMenu _guiMainMenu;

        public GameController(Minesweeper game) {
            Instance = this;

            _game = game;

            //Setup GUI
            _inputManager = new InputListenerComponent(game);

            var guiInputService = new GuiInputService(_inputManager);
            _gui = new GuiManager(game.Services, guiInputService);

            //_guiMainMenu = new GUIMainMenu(_gui);
        }

        public GameBoard GameBoard { get; private set; }

        public GameState CurrentState { get; private set; } = GameState.Initialization;

        public void Initialize() {
            _gui.Screen = new GuiScreen(_game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height);
            _gui.Screen.Desktop.Bounds = new UniRectangle(
                new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));
            _gui.Initialize();

            _guiMainMenu = new GUIMainMenu();
            //_guiMainMenu.Initialize();
        }

        public void MainMenu() {
            if (CurrentState == GameState.MainMenu)
                throw new Exception("Cannot go to the main menu if currently there");
            CurrentState = GameState.MainMenu;
            //_guiMainMenu.Open();
            _gui.Screen.Desktop.Children.Add(_guiMainMenu);
        }

        public void StartGame() {
            if (CurrentState == GameState.Running)
                throw new Exception("Cannot Start a new game if game is currently running");
            CurrentState = GameState.Running;
            GameBoard = new GameBoard(10, 10);
            //_guiMainMenu.Close();
            //_gui.Screen.Desktop.Children.Remove(_guiMainMenu);
            _guiMainMenu.Close();
        }

        public void QuitGame() {
            _game.Exit();
        }

        public void Update(GameTime gameTime) {
            _inputManager.Update(gameTime);
            _gui.Update(gameTime);

            _guiMainMenu.Update();
        }

        public void Draw(GameTime gameTime) {
            if (CurrentState == GameState.Running) {

            }

            _gui.Draw(gameTime);
        }
    }
}