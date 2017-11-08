using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public class Transform {
        public GameObject GameObject;

        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        /// <summary>
        /// Creates a new transform
        /// </summary>
        /// <param name="gameObject">The GameObject this transform will be attached to</param>
        public Transform(GameObject gameObject) {
            GameObject = gameObject;
        }
    }
}