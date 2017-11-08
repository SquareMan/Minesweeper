using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public sealed class GameObject {
        //List of custom scripts that can be attached to a GameObject and run
        private readonly List<GameObjectComponent> Components = new List<GameObjectComponent>();

        public readonly Scene Scene;

        public Transform Transform;
        public GameObject Parent;
        public List<GameObject> Children = new List<GameObject>();


        private GameObject(GameObject parent, Vector2 position) {
            Parent = parent;
            Scene = Scene.GetActiveScene();
            Scene.GameObjects.Add(this);

            Transform = new Transform(this) {
                Position = position
            };
        }

        /// <summary>
        /// Creates a new instance of an empty GameObject
        /// </summary>
        /// <param name="parent">The GameObject this GameObject will belong to (null makes it have no parent)</param>
        /// <param name="position">Position of this GameObject, relative to all parent GameObjects</param>
        /// <returns>The created GameObject</returns>
        public static GameObject Instantiate(GameObject parent = null, Vector2? position = null) {
            return new GameObject(parent, position ?? Vector2.Zero);
        }

        /// <summary>
        /// Use this method to attach a script to this GameObject
        /// </summary>
        /// <param name="component">An instance of the script to attach</param>
        public void AddComponent(GameObjectComponent component) {
            Components.Add(component);
            component.OnAdd(this);
        }

        /// <summary>
        /// This method will be called every cycle
        /// </summary>
        /// <param name="gameTime">Time values for the game</param>
        public void Update(GameTime gameTime) {
            foreach (var component in Components) {
                component.Update(gameTime);
            }
        }

        /// <summary>
        /// This method will be called every frame
        /// </summary>
        /// <param name="gameTime">Time values for the game</param>
        public void Draw(GameTime gameTime) {
            foreach (var component in Components) {
                component.Draw(gameTime);
            }
        }
    }
}