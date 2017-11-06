using Microsoft.Xna.Framework;

namespace Minesweeper.Model {
    public class GameBoard {
        public readonly int Width;
        public readonly int Height;

        private readonly Tile[,] _tiles;

        public GameBoard(int width, int height) {
            Width = width;
            Height = height;
            _tiles = new Tile[width,height];

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++) {
                    _tiles[x,y] = new Tile(new Point(x,y));
            }
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
