using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Timer = System.Threading.Timer;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SpaceAndroid {
    public class enemy : sprite {
        public int CurrPath = 0;
        public int CurrPathPoint = 0;

        public List<Vector2> p;
        public SpriteEffects flip;

        public float rot;
        public bool check = true;
        public EnemyBullet enemybullet;
        public Timer x;
        private float _timer;
        private float shootTimer = 1f;
        private bool kami = false;

        private Vector2 direction;

        public EnemyStateN State;


        public enemy(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            Layer = 0.5f;
        }

        public override void Update(GameTime gameTime, scene currN) {

            if (p == null) {
                p = currN.paths[CurrPath];
            }

            if (CurrPathPoint + 1 == p.Count) {
                if (State == EnemyStateN.Kamikaze) {
                    if(kami == false) {
                        p.Add(currN.player.position);
                        velocity *= 2;
                        kami = true;
                    }
                    if(CurrPathPoint + 1 == p.Count) {
                        this.removed = true;
                    }
                }
                else {
                    this.removed = true;
                }
            }

            direction = p[CurrPathPoint] - this.position;
            direction.Normalize();

            rot = -(float)Math.Atan2(direction.X, direction.Y);

            position += direction * velocity;

            if (p[CurrPathPoint].X - 5 <= this.position.X && this.position.X <= p[CurrPathPoint].X + 5 &&
                p[CurrPathPoint].Y - 5 <= this.position.Y && this.position.Y <= p[CurrPathPoint].Y + 5) {
                if (CurrPathPoint + 1 < p.Count) {
                    CurrPathPoint++;
                }
             }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            check = false;

            if (_timer > shootTimer) {
                check = true;

                _timer = 0;
            }
            if (this.position.X < currN.player.position.X + 75 && this.position.X > currN.player.position.X - 75) {
                if (check) {
                    AddEnemyBullet(currN);
                }
            }

            if (this.position.X > MyGameMain.originalX || this.position.X < 0 || this.position.Y < 0 || this.position.Y > MyGameMain.originalY) {
                this.removed = true;
            }

            if(this.ColisionDetection(currN.player)) {
                currN.player.lives--;
                this.removed = true;
            }
        }

        public override void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, rot, origin, scale, flip, Layer);
        }

        public void AddEnemyBullet(scene f) {
            EnemyBullet enbul;
            enbul = enemybullet.Clone() as EnemyBullet;
            enbul.lifespan = 5f;
            enbul.origin = this.origin;
            enbul.parent = this;
            enbul.position = new Vector2(this.position.X + (float)47.5, this.position.Y - 50);

            f.addItem(enbul);
        }
    }
}

