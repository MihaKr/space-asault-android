using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace SpaceAndroid {
    public class Font {
        public string Text;
        public Vector2 Position;
        public SpriteFont _font;

        public Font(string t, Vector2 p, SpriteFont f) {
            Text = t;
            Position = p;
            _font = f;
        }

        public void Draw(GameTime gt, SpriteBatch sb) {
            sb.DrawString(_font, Text, Position, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }

        public void setText(string t) {
            Text = t;
        }

        public virtual void Update(GameTime gameTime, scene currN) {
        }
    }
}

