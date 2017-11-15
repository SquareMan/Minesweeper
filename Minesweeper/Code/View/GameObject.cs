using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.View {
    public sealed class GameObject {
        //List of custom scripts that can be attached to a GameObject and run
        private List<Component> Components = new List<Component>();

        public Scene Scene;

        public Transform Transform;

        public string Name = "GameObject";
        public GameObject Parent;
        public List<GameObject> Children = new List<GameObject>();

        //GameObject()
        //GameObject(Name)
        //GameObject(Parent)
        public GameObject() {
            Scene = SceneManager.ActiveScene;
            Scene.GameObjects.Add(this);
            Transform = new Transform(this);
        }


        public GameObject(GameObject parent = null, Vector2? position = null) {
            Parent = parent;
            Scene = SceneManager.ActiveScene;
            Scene.GameObjects.Add(this);

            Transform = new Transform(this) {
                LocalPosition = position ?? Vector2.Zero
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
        /// Destroys an exisiting GameObject
        /// </summary>
        /// <param name="theObject">The object to be destroyed</param>
        /// <returns></returns>
        public static void Destroy(GameObject theObject) {
            //TODO: Implment
            theObject.Destroy();
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
        /// This method will be called every game update
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
        /// <param name="spriteBatch">The scene's spritebatch</param>
        /// <param name="gameTime">Time values for the game</param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            foreach (var component in Components) {
                component.Draw(spriteBatch, gameTime);
            }
        }

        public void Destroy() {
            Scene.GameObjects.Remove(this);
            Components = null;
            Scene = null;
            Transform = null;
        }
    }
}