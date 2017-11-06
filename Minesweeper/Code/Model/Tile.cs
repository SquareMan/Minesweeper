using Microsoft.Xna.Framework;

namespace Minesweeper.Model {
    public class Tile {
        private bool _isFlagged = false;
        private bool _isBomb = false;
        private bool _isRevealed;

        private Point _location;

        public Tile(Point location) {
            _location = location;
        }

        public void Reveal() {
            if (_isFlagged)
                return;

            if(_isRevealed)
                return;

            if (_isBomb) {
                // TODO: Game Over
                return;
            }

            //TODO: Check number of neighboring bombs

            //If bombs == 0 call Reveal on each neighbor
            //Else This tile should show the number of bombs

            _isRevealed = true;
        }
    }
}