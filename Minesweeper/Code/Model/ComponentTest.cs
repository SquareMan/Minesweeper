using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.View;
using MonoGame.Extended;

namespace Minesweeper.Model {
    public class ComponentTest : Component {
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.DrawRectangle(Transform.Position, new Size2(200,200), Color.Blue, 12f);
        }

        public override void Update(GameTime gameTime) {
            Transform.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}