using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.View {
    public class Scene : DrawableGameComponent {
        public List<GameObject> GameObjects = new List<GameObject>();
        private SpriteBatch SpriteBatch;

        public Scene(Game game) : base(game) {
            SpriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime) {
            for (int i = GameObjects.Count - 1; i >= 0; i--) {
                if(GameObjects[i]._objectDestroyed)
                    GameObjects[i].Dispose();
            }

            foreach (var go in GameObjects) {
                go.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime) {
            SpriteBatch.Begin();
            foreach (var go in GameObjects) {
                go.Draw(SpriteBatch, gameTime);
            }
            SpriteBatch.End();
        }

        public new void Dispose() {
            while(GameObjects.Count > 0) {
                GameObjects[0].Destroy();
                GameObjects.Remove(GameObjects[0]);
            }
        }
    }
}