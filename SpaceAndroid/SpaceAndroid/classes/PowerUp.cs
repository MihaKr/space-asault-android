using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class PowerUp : sprite {

        public enum PowerUPType {
            Life,
            Shield,
            MoreBullets,
            FasterBullets,
            SlowerBullets,
        }

        Array values = Enum.GetValues(typeof(PowerUPType));
        Random random = new Random();
        public PowerUPType CurrentPowerUp;

        public PowerUp(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            CurrentPowerUp = (PowerUPType)values.GetValue(random.Next(values.Length));
        }

        public override void Update(GameTime gameTime, scene CurrN) {
            if (this.ColisionDetection(CurrN.player)) {
                switch (CurrentPowerUp) {
                    case PowerUPType.Life:
                        {
                            getLife(CurrN);
                            break;
                        }

                    case PowerUPType.FasterBullets:
                        {
                            fasterB(CurrN);
                            break;
                        }

                    case PowerUPType.SlowerBullets:
                        {
                            slowerB(CurrN);
                            break;
                        }
                    case PowerUPType.MoreBullets:
                        {
                            moreB(CurrN);
                            break;
                        }

                    case PowerUPType.Shield:
                        {
                            shieldUp(CurrN);
                            break;
                        }
                    default: break;
                }
                this.removed = true;
            }
        }

        public void getLife(scene CurrN) {
            if (CurrN.player.lives < 3) {
                CurrN.player.lives++;
            }
        }

        public void slowerB(scene CurrN){
            if (CurrN.player.shootTimer <= 1f){
                CurrN.player.bullet.speed += 0.1f;
            }
        }

        public void fasterB(scene CurrN) {
            if (CurrN.player.bullet.speed >= 0.1f) {
                CurrN.player.bullet.speed -= 0.1f;
            }
        }

        public void moreB(scene CurrN){
            if (CurrN.player.BulletCount < 3) {
                CurrN.player.BulletCount++;
            }
        }

        public void shieldUp(scene CurrN) {
            Shield sh = CurrN._content.Shield.Clone() as Shield;
            CurrN.ShieldOn.Play(volume: 0.5f, pitch: 0.0f, pan: 0.0f);
            CurrN.addItem(sh);
        }
    }
}

