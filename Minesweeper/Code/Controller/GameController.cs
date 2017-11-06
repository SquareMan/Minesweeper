using System.Diagnostics;
using Minesweeper.Model;

namespace Minesweeper.Controller {
    public class GameController {
        public enum GameState {
            MainMenu,
            InGame
        }

        public static GameController Instance;

        private GameBoard _gameBoard;

        public GameController() {
            Instance = this;
        }

        public void StartGame() {
            _gameBoard = new GameBoard();
            Debug.WriteLine("GameStarted");
        }
    }
}