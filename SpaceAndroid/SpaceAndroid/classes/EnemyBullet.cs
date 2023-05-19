using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class EnemyBullet : bullet {
        public EnemyBullet(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            this.sourceRectangle = new Rectangle(858, 230, 9, 54);
            Layer = 0.5f;
        }

        public override void Update(GameTime gameTime, scene currN) {

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < currN.sprites.Count; i++) {
                if (currN.sprites[i] != this) {
                    if (this.ColisionDetection(currN.sprites[i])) {
                        if (currN.sprites[i] is SpaceAndroid.Shield) {
                            this.removed = true;

                            bullet bul;
                            bul = currN.player.bullet.Clone() as bullet;
                            bul.sourceRectangle = new Rectangle(858, 230, 9, 54);
                            bul.lifespan = 5f;
                            bul.origin = this.origin;
                            bul.parent = currN.player;
                            bul.position = new Vector2(currN.sprites[i].position.X + (float)47.5, currN.sprites[i].position.Y - 50);

                            currN.player.AddBullet(currN, bul);
                            currN.ShieldBounce.Play(volume: 0.5f, pitch: 0.0f, pan: 0.0f);
                        }

                        if (currN.sprites[i] is SpaceAndroid.player) {
                            currN.sprites[i].lives-- ;
                            Console.WriteLine(currN.sprites[i].lives);
                            this.removed = true;
                            currN.PlayerHit.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                        }
                    }
                }
            }

            if (_timer >= lifespan) {
                removed = true;
            }
            else {
                position.Y += speed;
            }
        }
    }
}

