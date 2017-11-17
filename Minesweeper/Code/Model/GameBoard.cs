using System;
using Microsoft.Xna.Framework;

namespace Minesweeper.Model {
    public class GameBoard {
        public delegate void TileDelegate(Tile tileChanged);

        public event TileDelegate OnTileCreated;
        public event TileDelegate OnTileDestroyed;

        public readonly int Width;
        public readonly int Height;
        public readonly int Bombs;

        private Random rand = new Random();

        private readonly Tile[,] _tiles;

        public GameBoard(int width, int height, int bombs) {
            Width = width;
            Height = height;
            Bombs = bombs;
            _tiles = new Tile[width,height];
        }

        public void CreateBoard() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Tile t = new Tile(new Point(x, y));

                    _tiles[x, y] = t;
                    OnTileCreated?.Invoke(t);
                }
            }

            PlaceBombs();
        }

        public void PlaceBombs() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    //TODO: This places an uncertain amount of bombs, need to place the amount specified by Bombs
                    if(rand.Next(Bombs) == 0)
                        _tiles[x, y].AddBomb();
                }
            }
        }

        public void ClearBoard() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    OnTileDestroyed?.Invoke(_tiles[x,y]);
                    _tiles[x, y].Destroy();
                    _tiles[x, y] = null;
                }
            }
            OnTileCreated = null;
            OnTileDestroyed = null;
        }

        public Tile GetTile(int x, int y) {
            if (x < 0 || x >= Width || y < 0 || y >= Height) {
                //Requested tile is out of bounds
                return null;
            }

            return _tiles[x, y];
        }
    }
}
