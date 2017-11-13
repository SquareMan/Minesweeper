using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public class Transform {
        public readonly GameObject GameObject;

        public Vector2 Position = Vector2.Zero;
        public float Rotation;
        public Vector2 Scale = Vector2.One;

        /// <summary>
        /// Creates a new transform
        /// </summary>
        /// <param name="gameObject">The GameObject this transform will be attached to</param>
        public Transform(GameObject gameObject) {
            GameObject = gameObject;
        }
    }
}