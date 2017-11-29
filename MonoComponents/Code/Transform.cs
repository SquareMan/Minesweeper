using Microsoft.Xna.Framework;

namespace MonoComponents {
    public class Transform {
        public readonly GameObject GameObject;

        public Vector2 LocalPosition = Vector2.Zero;
        public Vector2 Position {
            get {
                if (GameObject.Parent == null) {
                    return LocalPosition;
                }
                return LocalPosition + GameObject.Parent.Transform.Position;
            }
        }

        public float LocalRotation = 0f;
        public float Rotation {
            get {
                if (GameObject.Parent == null) {
                    return LocalRotation;
                }
                return LocalRotation + GameObject.Parent.Transform.Rotation;
            }
        }

        public Vector2 LocalScale = Vector2.One;
        public Vector2 Scale {
            get {
                if (GameObject.Parent == null) {
                    return LocalScale;
                }
                return LocalScale + GameObject.Parent.Transform.Scale;
            }
        }

        /// <summary>
        /// Creates a new transform
        /// </summary>
        /// <param name="gameObject">The GameObject this transform will be attached to</param>
        public Transform(GameObject gameObject) {
            GameObject = gameObject;
        }
    }
}