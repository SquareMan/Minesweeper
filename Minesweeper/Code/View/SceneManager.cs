using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.View {
    public static class SceneManager {
        public static Scene ActiveScene { get; private set; }

        private static Game _game;

        public static void Initialize(Game game) {
            _game = game;
            LoadScene();
        }

        public static void LoadScene() {
            //TODO: Implement Scene file format and load with this method
            //Create a new ActiveScene instead
            _game.Components.Remove(ActiveScene);
            //ActiveScene?.Dispose();
            ActiveScene = new Scene(_game);
            _game.Components.Add(ActiveScene);
        }

        public static void UnloadScene() {
            if (ActiveScene == null) {
                return;
            }

            _game.Components.Remove(ActiveScene);
            //ActiveScene.Dispose();
            ActiveScene = null;
        }
    }
}