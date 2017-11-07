using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public abstract class GameObjectComponent {
        public GameObject Parent;

        public void OnAdd(GameObject parent) {
            Parent = parent;
        }

        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}