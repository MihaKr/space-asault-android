using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class BossEnemy : sprite {
        public float rot;
        public float speed;
        public float speedY;
        public bool check = true;
        public EnemyBullet enemybullet;
        public sprite exp;
        private float _timer;
        private float shootTimer = 0.5f;
        public float evadeCooldown = 2f;
        public EnemyState state;


        public BossEnemy(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            lives = 5;
            Layer = 0.5f;
        }

        public override void Update(GameTime gameTime, scene currN) {
            if (currN.player.position.X < this.position.X-20) {
                rot = 0.2f;
                speed = -0.5f; 
            }
            else if (currN.player.position.X > this.position.X + 20) {
                rot = -0.2f;
                speed = 0.5f;
            }
            else {
                rot = 0f;
                speed = 0f;
            }

            if (currN.player.position.Y < this.position.Y + 1000) {
                speedY = -0.5f;
            }
            else if (currN.player.position.Y > this.position.Y - 1000) {
                speedY = 0.5f;
            }
            else {
                speedY = 0f;
            }

            //TODO: spreminjanje visine

            position.X += speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position.Y += speedY * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            check = false;

            if (_timer > shootTimer) {
                check = true;
                _timer = 0;
            }

            if (this.position.X < currN.player.position.X + 50 && this.position.X > currN.player.position.X - 50) {
                if (check) {
                    AddEnemyBullet(currN);
                }
            }

            evadeCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, rot, origin, scale, SpriteEffects.None, Layer);
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

        public void Evade(bullet b){
            float distance = (float)Math.Sqrt((b.position.X - this.position.X) * (b.position.X - this.position.X) + (b.position.Y - this.position.Y) * (b.position.Y - this.position.Y));
            if (evadeCooldown <= 0 && distance > 20 && distance < 200) {
                if(b.position.X < this.position.X - 20) {
                    this.position.X += 250;
                }
                if (b.position.X > this.position.X + 20) {
                    this.position.X -= 250;
                }
                evadeCooldown = 2f;
            }

        }
    }
}
