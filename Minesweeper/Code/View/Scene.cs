using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.View {
    public class Scene {
        //TODO: Remove this and create a more robust SceneManager
        static Scene ActiveScene;

        public List<GameObject> GameObjects = new List<GameObject>();
        public SpriteBatch SpriteBatch;

        public Scene(Game game) {
            ActiveScene = this;
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        [System.Obsolete]
        public static Scene GetActiveScene() {
            return ActiveScene;
        }

        public void Update(GameTime gameTime) {
            foreach (var go in GameObjects) {
                go.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime) {
            SpriteBatch.Begin();
            foreach (var go in GameObjects) {
                go.Draw(gameTime);
            }
            SpriteBatch.End();
        }
    }
}