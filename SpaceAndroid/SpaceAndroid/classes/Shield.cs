using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class Shield : sprite {

        private float _timer;
        public float SpawnTimer { get; set; }
        public bool CanAdd { get; set; }

        public Shield(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            SpawnTimer = 10f;
            Layer = 0.5f;
        }

        public override void Update(GameTime gameTime, scene currN) {
            this.position.X = currN.player.position.X;
            this.position.Y = currN.player.position.Y -50;

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > SpawnTimer) {
                this.removed = true;
                _timer = 0;
            }
        }
    }
}

