using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class bullet:sprite {
        public float _timer;
        public float speed = 15f;
        public bool hit = false;

        public bullet(Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN) : base(textureN, sourceRectangleN, positionN) {
            Layer = 0.5f;
        }

        public override void Update(GameTime gameTime, scene currN) {

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < currN.sprites.Count; i++) {
                if (currN.sprites[i] != this) {
                    if (this.ColisionDetection(currN.sprites[i])) {
                        if(hit == false) { 
                            if (currN.sprites[i] is SpaceAndroid.enemy) {
                                if (currN.sprites[i].lives == 0) {
                                    currN.sprites[i].removed = true;
                                    this.parent.sc.Score += 100;
                                    MyGameMain._gameplay.Score += 100;
                                    hit = true;
                                }
                                else {
                                    currN.sprites[i].lives -= 1;
                                }
                                this.removed = true;
                                currN.Exp.Play(volume: 0.5f, pitch: 0.0f, pan: 0.0f);

                            }

                            if (currN.sprites[i] is BossEnemy) {
                                if ((((BossEnemy)currN.sprites[i]).state == EnemyState.Evader)) {
                                    if(((BossEnemy)currN.sprites[i]).evadeCooldown <= 0) {
                                        ((BossEnemy)currN.sprites[i]).Evade(this);
                                    }
                                    else {
                                        currN.sprites[i].lives -= 1;
                                        Console.WriteLine(currN.sprites[i].lives);
                                        if (currN.sprites[i].lives == 0) {
                                            currN.sprites[i].removed = true;
                                            this.removed = true;
                                        }
                                    }
                                }
                                else {
                                    currN.sprites[i].lives -= 1;
                                    Console.WriteLine(currN.sprites[i].lives);
                                    if (currN.sprites[i].lives == 0) {
                                        currN.sprites[i].removed = true;
                                        this.removed = true;
                                    }
                                }

                                hit = true;
                            }
                        }
                    }
                }
            }

            if (_timer >= lifespan) {
                removed = true;
            }
            else { 
                position.Y -= speed;
            }
        }
    }
}
