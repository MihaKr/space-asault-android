using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class PowerUpController {

        private float _timer;
        public float SpawnTimer { get; set; }
        public bool CanAdd { get; set; }
        private Texture2D _textures;
        private List<Rectangle> _rectangles;

        public PowerUpController(Texture2D t) {
            _textures = t;
            SpawnTimer = 5f;

            _rectangles = new List<Rectangle>() {
                new Rectangle(423, 728, 93, 84),
                new Rectangle(224, 580, 103, 84),
                new Rectangle(408, 907, 97, 84),
             };
        }

        public virtual void Update(GameTime gameTime, scene CurrN) {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            CanAdd = false;

            if (_timer > SpawnTimer) {
                CanAdd = true;

                _timer = 0;
            }
        }

        public void Add(scene CurrN) {
            Vector2 pos = new Vector2(MyGameMain.Random.Next(100 / (int)MyGameMain.scaleX, (int)(MyGameMain.originalX - 100/MyGameMain.scaleX)), MyGameMain.Random.Next(300 / (int)MyGameMain.scaleY, (int)(MyGameMain.originalY - 300/MyGameMain.scaleY)));
            PowerUp p = new PowerUp(_textures, new Rectangle(696, 329, 34, 33), pos);
            CurrN.addEntry(p);
        }
    }
}

