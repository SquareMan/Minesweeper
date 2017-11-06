using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Minesweeper.Model;
using Minesweeper.View.GUI;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;

namespace Minesweeper.Controller {
    public class GameController {
        public enum GameState {
            MainMenu,
            Running
        }

        public static GameController Instance;

        private readonly Minesweeper _game;

        private readonly GuiManager _gui;
        private readonly InputListenerComponent _inputManager;
        private readonly GUIMainMenu _guiMainMenu;
        private GameBoard _gameBoard;

        public GameController(Minesweeper game) {
            Instance = this;

            _game = game;

            //Setup GUI
            _inputManager = new InputListenerComponent(game);

            var guiInputService = new GuiInputService(_inputManager);
            _gui = new GuiManager(game.Services, guiInputService);

            _guiMainMenu = new GUIMainMenu(_gui);
        }

        public GameState CurrentState { get; private set; }

        public void Initialize() {
            _gui.Screen = new GuiScreen(_game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height);
            _gui.Screen.Desktop.Bounds = new UniRectangle(
                new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));
            _gui.Initialize();

            _guiMainMenu.Initialize();
        }

        public void StartGame() {
            if (CurrentState == GameState.Running)
                throw new Exception("Cannot Start a new game if game is currently running");
            CurrentState = GameState.Running;
            _gameBoard = new GameBoard(10,10);
            Debug.WriteLine("GameStarted");
        }

        public void Update(GameTime gameTime) {
            _inputManager.Update(gameTime);
            _gui.Update(gameTime);

            _guiMainMenu.Update();
        }

        public void Draw(GameTime gameTime) {
            _gui.Draw(gameTime);
        }
    }
}