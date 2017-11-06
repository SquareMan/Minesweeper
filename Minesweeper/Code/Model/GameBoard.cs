namespace Minesweeper.Model {
    class GameBoard {
        private readonly Tile[,] tiles;

        public GameBoard(int width, int height)
        {
            tiles = new Tile[width,height];
        }
    }
}
