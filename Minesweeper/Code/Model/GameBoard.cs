using Microsoft.Xna.Framework;

namespace Minesweeper.Model {
    public class GameBoard {
        public delegate void TileDelegate(Tile tileChanged);

        public event TileDelegate OnTileCreated;
        public event TileDelegate OnTileChanged;
        public event TileDelegate OnTileDestroyed;

        public readonly int Width;
        public readonly int Height;

        private readonly Tile[,] _tiles;

        public GameBoard(int width, int height) {
            Width = width;
            Height = height;
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
        }

        public void ClearBoard() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    OnTileDestroyed?.Invoke(_tiles[x,y]);
                    _tiles[x, y] = null;
                }
            }
            OnTileCreated = null;
            OnTileChanged = null;
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
