using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class ScoreFont : Font {
        public ScoreFont(string t, Vector2 p, SpriteFont f) : base(t, p, f) {
        }

        public override void Update(GameTime gameTime, scene currN) {
            Text = currN.player.sc.Score.ToString();
        }
    }
}

