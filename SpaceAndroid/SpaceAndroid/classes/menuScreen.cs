using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class menuScreen : sprite{
        public menuScreen(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            Layer = 0.6f;
        }

        public override void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, 0, origin, scale, SpriteEffects.None, Layer);
        }
    }
}

