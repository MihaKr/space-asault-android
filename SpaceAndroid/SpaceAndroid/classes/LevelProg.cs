using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class LevelProg : Font {
        public LevelProg(string t, Vector2 p, SpriteFont f) : base(t, p, f) {
        }

        public override void Update(GameTime gameTime, scene currN) { 
            string mid = (MyGameMain._gameplay.LevelInd + 1).ToString();

            Text = mid + "/15";
        }
    }
}