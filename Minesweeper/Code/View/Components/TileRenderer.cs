using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Minesweeper.View {
    public class TileRenderer : Component {
        private string bombNumber = "";
        private Color color = Color.Black;

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.DrawRectangle(Transform.Position * 32, new Size2(32, 32), color, 2f);

            if(bombNumber != "0")
                spriteBatch.DrawString(Minesweeper.Font,bombNumber,Transform.Position * 32, Color.White);
        }

        public void OnTileRevealed(int bombs) {
            bombNumber = bombs.ToString();
            color = Color.Gray;
        }
    }
}