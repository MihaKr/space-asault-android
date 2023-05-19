using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.IO;
using Microsoft.Xna.Framework;

namespace SpaceAndroid {
    public class EnemyController {

        private float _timer;

        private List<Rectangle> _rectangles;

        private Texture2D _textures;

        public bool CanAdd { get; set; }

        public EnemyBullet Bullet;

        public int MaxEnemies { get; set; }

        public float SpawnTimer { get; set; }

        public EnemyController(Texture2D t) {

            _textures = t;

            _rectangles = new List<Rectangle>() {
                new Rectangle(423, 728, 93, 84),
                new Rectangle(224, 580, 103, 84),
                new Rectangle(408, 907, 97, 84),
              };

            Bullet = new EnemyBullet(t, new Rectangle(856, 421, 9, 54), Vector2.Zero );

            MaxEnemies = 10;
            SpawnTimer = 5f;
        }

        public virtual void Update(GameTime gameTime) {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            CanAdd = false;

            if (_timer > SpawnTimer) {
                CanAdd = true;

                _timer = 0;
            }
        }

        public void NextGroup(scene currN) {
            if(currN is Endless) {
                if(currN.group == currN.groups.Count-1) {
                    currN.group = 0;
                }
                currN.groups[currN.group] = MyGameMain.Random.Next(0, 2);
            }
            if (currN.group < currN.groups.Count) {
                switch (currN.groups[currN.group]) {
                    case 0:
                        Spawn10(currN);
                        currN.group++;
                        break;
                    case 1:
                        SpawnZigZag(currN);
                        currN.group++;
                        break;
                    case 2:
                        SpawnFade(currN);
                        currN.group++;
                        break;
                    default:
                        break;
                }
            }
        }

        public enemy GetEnemy() {
            int r = MyGameMain.Random.Next(0, _rectangles.Count);
            Rectangle src = _rectangles[r];

            Vector2 pos = new Vector2(MyGameMain.Random.Next(100, (int)(MyGameMain.originalX-100/MyGameMain.scaleX)), MyGameMain.Random.Next(100, (int)(MyGameMain.originalY-300/MyGameMain.scaleY)));

            //Vector2 pos = new Vector2(700, 1266);

            enemy n = new enemy(_textures, src, pos);
            Bullet.position = pos;
            n.enemybullet = Bullet;
            n.State = sprite.EnemyStateN.Normal;
            return n;
        }

        public void Spawn10(scene currN) {
            List<Vector2> posL = new List<Vector2>() { new Vector2(0, 1250/MyGameMain.scaleY), new Vector2(0, 250/MyGameMain.scaleY), new Vector2(0, 500/MyGameMain.scaleY), new Vector2(0, 750/MyGameMain.scaleY), new Vector2(0, 1000/MyGameMain.scaleY),
                                new Vector2(MyGameMain.originalX, 1250/MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 250/MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 500/MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 750/MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 1000/MyGameMain.scaleY) };

            for (int i = 0; i < 10; i++){
                Rectangle src = _rectangles[1];

                Vector2 pos = posL[i];

                enemy n = new enemy(_textures, src, pos);
                Bullet.position = pos;
                n.enemybullet = Bullet;
                n.State = sprite.EnemyStateN.Normal;

                if (i < 5) {
                    n.CurrPath = 0;
                }

                else {
                    n.CurrPath = 1;
                }
                currN.addEntry(n);
            }
        }

        public void SpawnZigZag(scene currN) {
            List<Vector2> posL = new List<Vector2>() { new Vector2(150, 150), new Vector2(MyGameMain.originalX/2, 150/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 150/MyGameMain.scaleY) };

            for (int i = 0; i < 3; i++) {
                Rectangle src = _rectangles[2];

                Vector2 pos = posL[i];

                enemy n = new enemy(_textures, src, pos);
                n.lives = 3;
                Bullet.position = pos;
                n.enemybullet = Bullet;
                n.State = sprite.EnemyStateN.Normal;

                switch(i) {
                    case 0:
                        n.CurrPath = 2;
                        break;
                    case 1:
                        n.CurrPath = 3;
                        break;
                    case 2:
                        n.CurrPath = 4;
                        break;
                }
                currN.addEntry(n);
            }
        }

        public void SpawnFade(scene currN) {
            List<Vector2> posL = new List<Vector2>() { new Vector2(150, 150), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 300/MyGameMain.scaleY), new Vector2(150/MyGameMain.scaleX, 450/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 600/MyGameMain.scaleY), new Vector2(150/MyGameMain.scaleX, 750/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 900/MyGameMain.scaleY) };

            for (int i = 0; i < 6; i++) {
                Rectangle src = _rectangles[0];

                Vector2 pos = posL[i];

                enemy n = new enemy(_textures, src, pos);
                Bullet.position = pos;
                n.enemybullet = Bullet;
                n.State = sprite.EnemyStateN.Normal;
                n.CurrPath = 5 + i;

                currN.addEntry(n);
            }
        }

        public void spawnSideZig(scene currN) {
            List<Vector2> posL = new List<Vector2>() { new Vector2(150/MyGameMain.scaleX, 150/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 300/MyGameMain.scaleY), new Vector2(150/MyGameMain.scaleX, 450/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 600/MyGameMain.scaleY), new Vector2(150/MyGameMain.scaleX, 750/MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 150/MyGameMain.scaleX, 900/MyGameMain.scaleY) };

            for (int i = 0; i < 6; i++) {
                Rectangle src = _rectangles[0];

                Vector2 pos = posL[i];

                enemy n = new enemy(_textures, src, pos);
                Bullet.position = pos;
                n.enemybullet = Bullet;
                n.State = sprite.EnemyStateN.Normal;
                n.CurrPath = 5 + i;

            }
        }
    }
}