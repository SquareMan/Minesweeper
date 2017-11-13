using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public abstract class Component {
        public Transform Transform;

        public void OnAdd(GameObject parent) {
            Transform = parent.Transform;
        }

        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
    }
}