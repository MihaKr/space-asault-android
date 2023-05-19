using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceAndroid {
    public class Asteroid : sprite {
        public Asteroid(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            Layer = 0f;
        }

        public override void Update(GameTime gameTime, scene currN) {
            this.position.Y += 5;

            float rotationSpeed = MathHelper.ToRadians(90f);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.rotationV += rotationSpeed * deltaTime;

        }

        public override void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, this.rotationV, origin, scale, SpriteEffects.None, Layer);
        }

    }
}

