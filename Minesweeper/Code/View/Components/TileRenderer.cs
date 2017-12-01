using System.Runtime.ExceptionServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.Controller;
using MonoComponents;
using MonoGame.Extended;

namespace Minesweeper.View {
    public class TileRenderer : Component {
        public delegate void TileRendererDelegate(GameObject tileObject);
        public event TileRendererDelegate OnTileLeftClicked;
        public event TileRendererDelegate OnTileRightClicked;

        public static readonly int TileSize = 32;

        private string _bombNumber = "";
        private Color _borderColor = Color.Black;
        private Color _tileColor = Color.Gray;

        private Rectangle _bounds;

        public override void Start() {
            _bounds = new Rectangle((int)Transform.Position.X * TileSize, (int)Transform.Position.Y * TileSize, TileSize, TileSize);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.FillRectangle(Transform.Position * TileSize, new Size2(TileSize, TileSize), _tileColor);
            spriteBatch.DrawRectangle(Transform.Position * TileSize, new Size2(TileSize, TileSize), _borderColor, 2f);

            if(_bombNumber != "0")
                spriteBatch.DrawString(Minesweeper.Font,_bombNumber,Transform.Position * TileSize, Color.White);
        }

        public override void Update(GameTime gameTime) {
            if (GameController.Instance.CurrentState != GameController.GameState.Running)
                return;

            //Check If We're Clicked
            MouseState state = Mouse.GetState();
            if (!_bounds.Intersects(new Rectangle(new Point(state.X, state.Y), new Point(1))))
                return;

            if (state.IsLeftButtonReleased()) {
                //Reveal this tile
                OnTileLeftClicked?.Invoke(Transform.GameObject);
            }

            if (state.IsRightButtonReleased()) {
                //Toggle flag on this tile
                OnTileRightClicked?.Invoke(Transform.GameObject);
            }
        }

        public void OnTileRevealed(int bombs) {
            _bombNumber = bombs.ToString();
            _borderColor = Color.Gray;
        }

        public void OnTileFlagged(bool flag) {
            _tileColor = flag ? Color.Red : Color.Gray;
        }

        public override void Destroy() {
            OnTileLeftClicked = null;
        }
    }
}