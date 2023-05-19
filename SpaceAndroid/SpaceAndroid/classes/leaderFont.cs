using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class leaderFont : Font {
        public leaderFont(string t, Vector2 p, SpriteFont f) : base(t, p, f){
        }

        public virtual void Update(GameTime gameTime, scene currN, string text) {
            Text = text;
        }
    }

}

