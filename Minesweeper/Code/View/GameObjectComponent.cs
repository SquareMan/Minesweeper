using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public abstract class GameObjectComponent {
        public Transform Transform;

        public void OnAdd(GameObject parent) {
            Transform = parent.Transform;
        }

        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}