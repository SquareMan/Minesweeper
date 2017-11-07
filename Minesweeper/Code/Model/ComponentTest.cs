using Microsoft.Xna.Framework;
using Minesweeper.View;
using MonoGame.Extended;

namespace Minesweeper.Model {
    public class ComponentTest : GameObjectComponent {
        public override void Draw(GameTime gameTime) {
            Parent.Scene.SpriteBatch.DrawRectangle(Parent.Position, new Size2(200,200), Color.Blue, 12f);
        }

        public override void Update(GameTime gameTime) {
            Parent.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}