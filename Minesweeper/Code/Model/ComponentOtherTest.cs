using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.View;
using MonoGame.Extended;

namespace Minesweeper.Model {
    public class ComponentOtherTest : Component {
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.DrawCircle(Transform.Position, 100, 4, Color.Blue, 12f);
        }

        public override void Update(GameTime gameTime) {
            Transform.LocalPosition.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}