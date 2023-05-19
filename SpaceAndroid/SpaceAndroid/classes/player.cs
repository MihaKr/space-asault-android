using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input.Touch;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using Timer = System.Threading.Timer;
using System.Reflection.Emit;
using System.Threading.Tasks;
using MonoGame.Framework;
using static System.Formats.Asn1.AsnWriter;

namespace SpaceAndroid {
    public class player : sprite {
        TouchCollection touchState;
        public float speed = 10f;
        public bool check = true;
        public bullet bullet;
        private float _timer;
        public float shootTimer = 0.5f;
        public float BulletCount = 1f;

        public player(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            lives = 3;
            sc = new ScoreModel();
            Layer = 0.5f;
        }

        public virtual void Move(scene f) {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            //TODO: POPRAVI PC SCALE BOUNDS

            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                if (position.Y >= 0) { 
                    position.Y -= speed;
                    PcBullet(f);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S)) {
                if (position.Y <= MyGameMain.originalY * MyGameMain.scale) {
                    position.Y += speed;
                    PcBullet(f);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                if (position.X <= MyGameMain.originalX * MyGameMain.scale) {
                    position.X += speed;
                    PcBullet(f);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                if (position.X >= 0) {
                    position.X -= speed;
                    PcBullet(f);
                }
            }

            if (check) {

            }

            touchState = TouchPanel.GetState();

            foreach (TouchLocation tl in touchState) {
                if ((tl.State == TouchLocationState.Pressed)
                        || (tl.State == TouchLocationState.Moved)) {
                    foreach(ButtonController s in f.Buttons) {
                        if (!s.src.Contains(tl.Position)) {
                            Vector2 pos = new Vector2(touchState[0].Position.X / MyGameMain.scale, touchState[0].Position.Y / MyGameMain.scale);
                            this.position = new Vector2(pos.X, pos.Y);
                            if (check) {
                                for (int i = 0; i < BulletCount; i++) {
                                    bullet bul;
                                    bul = bullet.Clone() as bullet;
                                    bul.lifespan = 5f;
                                    bul.origin = this.origin;
                                    bul.parent = this;
                                    bul.position = new Vector2(this.position.X + (float)47.5 + i * 50, this.position.Y - 50);

                                    AddBullet(f, bul);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PcBullet(scene f) {
            for (int i = 0; i < BulletCount; i++) {
                bullet bul;
                bul = bullet.Clone() as bullet;
                bul.lifespan = 5f;
                bul.origin = this.origin;
                bul.parent = this;
                bul.position = new Vector2(this.position.X + (float)47.5 + i * 50, this.position.Y - 50);

                AddBullet(f, bul);
            }
        }

        public void AddBullet(scene f, bullet bul) {
            f.addItem(bul);
            f.Laser.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);
        }

        public override void Update(GameTime gameTime, scene currN) {
            Move(currN);

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            check = false;

            if (_timer > shootTimer) {
                check = true;

                _timer = 0;
            }

            if (this.lives < 1){
                MyGameMain._gameplay.Score += this.sc.Score;

                MyGameMain._gameplay.Finished = true;
                currN.Reset();
            }
        }

        public override void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(this.exp.texture, new Vector2(this.position.X - 10, this.position.Y + 70), this.exp.sourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(1.5f, 1.5f), SpriteEffects.None, Layer);
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, 0, origin, scale, SpriteEffects.None, Layer);
            for (int i = 0; i < lives; i++) { 
                sb.Draw(texture, new Vector2(i * 100 + 60, 380), new Rectangle(211, 941, 99, 75), Color.White, 0, new Vector2(0, 0), new Vector2(0.7f, 0.7f), SpriteEffects.None, Layer);
            }
        }
    }
}