﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Minesweeper.Model;
using Minesweeper.View;
using Minesweeper.View.GUI;
using MonoComponents;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.NuclexGui;
using MonoGame.Extended.NuclexGui.Controls.Desktop;

namespace Minesweeper.Controller {
    public class GameController {
        public enum GameState {
            Initialization,
            MainMenu,
            Running,
            GameOver,
            Win
        }

        public static GameController Instance;

        private readonly Minesweeper _game;

        private readonly GuiManager _gui;
        public readonly InputListenerComponent _inputManager;
        public IReturnsGUIControl ActiveGUI { get; protected set; }
        private GUIMainMenu _guiMainMenu;
        private GUIGame _guiGame;

        private Dictionary<Tile, GameObject> _tileToGameObjectMap;
        private Dictionary<GameObject, Tile> _gameObjectToTileMap;

        public GameController(Minesweeper game) {
            Instance = this;
            _game = game;

            //Setup GUI
            _inputManager = new InputListenerComponent(game);
            var guiInputService = new GuiInputService(_inputManager);

            _gui = new GuiManager(game.Services, guiInputService);

            //Setup dictionary to hold tiles and their game objects
            _tileToGameObjectMap = new Dictionary<Tile, GameObject>();
            _gameObjectToTileMap = new Dictionary<GameObject, Tile>();
        }

        public GameBoard GameBoard { get; private set; }

        public GameState CurrentState { get; private set; } = GameState.Initialization;

        public void Initialize() {
            _gui.Screen = new GuiScreen(_game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height);
            _gui.Screen.Desktop.Bounds = new UniRectangle(
                new UniScalar(0f, 0), new UniScalar(0f, 0), new UniScalar(1f, 0), new UniScalar(1f, 0));
            _gui.Initialize();

            _guiMainMenu = new GUIMainMenu();
            _guiGame = new GUIGame();
            
            GameBoard = new GameBoard(10, 10, 10);
        }

        public void MainMenu() {
            if (CurrentState == GameState.MainMenu)
                throw new Exception("Cannot go to the main menu if currently there");

            if (CurrentState == GameState.Running) {
                //We need to cleanup the game
                GameBoard.OnTileCreated -= CreateTileGameObject;
                GameBoard.OnTileDestroyed -= CreateTileGameObject;
                GameBoard.ClearBoard();

                _gui.Screen.Desktop.Children.Remove(_guiGame);
            }
            CurrentState = GameState.MainMenu;
            //_guiMainMenu.Open();
            _gui.Screen.Desktop.Children.Add(_guiMainMenu);
            ActiveGUI = _guiMainMenu;
        }

        public void StartGame() {
            if (CurrentState == GameState.Running)
                throw new Exception("Cannot Start a new game if game is currently running");
            CurrentState = GameState.Running;
            GameBoard.OnTileCreated += CreateTileGameObject;
            GameBoard.OnTileDestroyed += DeleteTileGameObject;
            GameBoard.CreateBoard();

            _gui.Screen.Desktop.Children.Remove(_guiMainMenu);
            _gui.Screen.Desktop.Children.Add(_guiGame);
            ActiveGUI = _guiGame;
        }

        public void GameOver() {
            if(CurrentState == GameState.GameOver)
                throw new Exception("The Game is already Over");
            CurrentState = GameState.GameOver;

            _gui.Screen.Desktop.Children.Remove(_guiGame);
            ActiveGUI = null;
        }

        public void QuitGame() {
            _game.Exit();
        }

        public void Update(GameTime gameTime) {
            _inputManager.Update(gameTime);
            _gui.Update(gameTime);
        }

        public void Draw(GameTime gameTime) {
            _gui.Draw(gameTime);
        }

        void CreateTileGameObject(Tile t) {
            GameObject go = new GameObject(null, new Vector2(t.Position.X, t.Position.Y));
            var renderer = go.AddComponent<TileRenderer>();
            renderer.Initialize(t);

            //This should probably be done by the renderer
            t.OnTileRevealed += renderer.OnTileRevealed;
            t.OnTileFlagged += renderer.OnTileFlagged;

            _tileToGameObjectMap.Add(t, go);
            _gameObjectToTileMap.Add(go, t);
        }

        void DeleteTileGameObject(Tile t) {
            GameObject go = _tileToGameObjectMap[t];

            _tileToGameObjectMap.Remove(t);
            _gameObjectToTileMap.Remove(go);
            //GameObject.Destroy(go);
            go.Destroy();
        }
    }
}