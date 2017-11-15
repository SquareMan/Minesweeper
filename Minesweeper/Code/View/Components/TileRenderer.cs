using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Minesweeper.View {
    public class TileRenderer : Component {
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.DrawRectangle(Transform.Position * 32, new Size2(32, 32), Color.Black, 2f);
        }
    }
}