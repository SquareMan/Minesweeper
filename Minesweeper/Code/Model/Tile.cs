using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Minesweeper.Controller;

namespace Minesweeper.Model {
    public class Tile {
        public delegate void IntDelegate(int num);
        public event IntDelegate OnTileRevealed;

        public readonly Point Position;

        public Tile(Point position) {
            Position = position;
        }

        public bool IsFlagged { get; private set; }
        public bool IsBomb { get; private set; }
        public bool IsRevealed { get; private set; }

        public void ToggleFlag() {
            IsFlagged = !IsFlagged;
        }

        public void AddBomb() {
            IsBomb = true;
        }

        public void Reveal() {
            if (IsFlagged)
                return;

            if (IsRevealed)
                return;

            if (IsBomb) {
                //TODO: Gameover
                return;
            }

            IsRevealed = true;

            //Check number of neighboring bombs
            var neighbors = GetNeighbors();
            var bombs = 0;
            foreach (var tile in neighbors) {
                if (tile.IsBomb) {
                    bombs++;
                }
            }

            OnTileRevealed?.Invoke(bombs);

            //If bombs == 0 call Reveal on each neighbor
            //Else This tile should show the number of bombs
            if (bombs == 0) {
                foreach (var neighbor in neighbors) {
                    neighbor.Reveal();
                }
            }
        }

        public Tile[] GetNeighbors() {
            var neighbors = new List<Tile>();

            for (var x = -1; x <= 1; x++) {
                for (var y = -1; y <= 1; y++) {
                    //Skip ourselves
                    if (x == 0 && y == 0) continue;

                    var neighbor = GameController.Instance.GameBoard.GetTile(x + Position.X, y + Position.Y);

                    if(neighbor != null)
                        neighbors.Add(neighbor);
                }
            }

            return neighbors.ToArray();
        }

        public void Destroy() {
            OnTileRevealed = null;
        }
    }
}