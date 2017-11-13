﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.View {
    public abstract class Component {
        public Transform Transform;

        public void OnAdd(GameObject parent) {
            Transform = parent.Transform;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
    }
}