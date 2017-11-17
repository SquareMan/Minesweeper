using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.Controller;
using MonoGame.Extended;

namespace Minesweeper.View {
    public class TileRenderer : Component {
        public delegate void TileRendererDelegate(GameObject tileObject);
        public event TileRendererDelegate OnTileClicked;

        public static readonly int TileSize = 32;

        private string bombNumber = "";
        private Color color = Color.Black;

        private Rectangle _bounds;

        public override void Start() {
            _bounds = new Rectangle((int)Transform.Position.X * TileSize, (int)Transform.Position.Y * TileSize, TileSize, TileSize);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.DrawRectangle(Transform.Position * TileSize, new Size2(TileSize, TileSize), color, 2f);

            if(bombNumber != "0")
                spriteBatch.DrawString(Minesweeper.Font,bombNumber,Transform.Position * TileSize, Color.White);
        }

        public override void Update(GameTime gameTime) {
            //Check If We're Clicked
            MouseState state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed && _bounds.Intersects(new Rectangle(new Point(state.X, state.Y), new Point(1)))) {
                //Reveal this tile
                OnTileClicked?.Invoke(Transform.GameObject);
            }
        }

        public void OnTileRevealed(int bombs) {
            bombNumber = bombs.ToString();
            color = Color.Gray;
        }

        public override void Destroy() {
            OnTileClicked = null;
        }
    }
}