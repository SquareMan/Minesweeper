using Microsoft.Xna.Framework;
using Minesweeper.View;
using MonoGame.Extended;

namespace Minesweeper.Model {
    public class ComponentTest : GameObjectComponent {
        public override void Draw(GameTime gameTime) {
            Transform.GameObject.Scene.SpriteBatch.DrawRectangle(Transform.Position, new Size2(200,200), Color.Blue, 12f);
        }

        public override void Update(GameTime gameTime) {
            Transform.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}