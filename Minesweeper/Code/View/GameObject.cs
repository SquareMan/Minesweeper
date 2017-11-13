using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper.View {
    public sealed class GameObject {
        //List of custom scripts that can be attached to a GameObject and run
        private readonly List<Component> Components = new List<Component>();

        public readonly Scene Scene;

        public readonly Transform Transform;

        public string Name = "GameObject";
        public GameObject Parent;
        public List<GameObject> Children = new List<GameObject>();

        //GameObject()
        //GameObject(Name)
        //GameObject(Parent)
        public GameObject() {
            Scene = Scene.GetActiveScene();
            Scene.GameObjects.Add(this);
            Transform = new Transform(this);
        }


        public GameObject(GameObject parent = null, Vector2? position = null) {
            Parent = parent;
            Scene = Scene.GetActiveScene();
            Scene.GameObjects.Add(this);

            Transform = new Transform(this) {
                Position = position ?? Vector2.Zero
            };
        }

        /// <summary>
        /// Clones an exisiting GameObject
        /// </summary>
        /// <param name="parent">The GameObject this GameObject will belong to (null makes it have no parent)</param>
        /// <param name="position">Position of this GameObject, relative to all parent GameObjects</param>
        /// <returns>The created GameObject</returns>
        public static GameObject Instantiate(GameObject parent, Vector2? position = null) {
            return new GameObject(parent, position ?? Vector2.Zero);
        }

        /// <summary>
        /// Adds a component to the GameObject
        /// </summary>
        /// <typeparam name="T">The Type of the component you want to add</typeparam>
        public void AddComponent<T>() where T : Component, new() {
            T component = new T();
            Components.Add(component);
            component.OnAdd(this);
        }

        //public void AddComponent(Component component) {
        //    Components.Add(component);
        //    component.OnAdd(this);
        //}

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