using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class BackgroundManager {
        private float _timer;
        public float SpawnTimer { get; set; }
        private Texture2D _textures;
        private List<Rectangle> _rectangles;

        public BackgroundManager(Texture2D t) {
            _textures = t;
            SpawnTimer = 5f;

            _rectangles = new List<Rectangle>() {
                new Rectangle(224, 664, 101, 84),
                new Rectangle(0, 520, 120, 98),
                new Rectangle(518, 810, 89, 82),
                new Rectangle(327, 452, 98, 96),
                new Rectangle(651, 447, 43, 43),
                new Rectangle(237, 452, 45, 40),
                new Rectangle(406, 234, 28, 28),
                new Rectangle(778, 587, 29, 26),
                new Rectangle(346, 814, 18, 18),
                new Rectangle(399, 814, 16, 15),
                new Rectangle(224, 748, 101, 84),
                new Rectangle(0, 618, 120, 98),
                new Rectangle(516, 728, 89, 82),
                new Rectangle(327, 548, 98, 96),
                new Rectangle(674, 219, 43, 43),
                new Rectangle(282, 452, 45, 40),
                new Rectangle(406, 262, 28, 28),
                new Rectangle(396, 413, 29, 26),
                new Rectangle(364, 814, 18, 18),
                new Rectangle(602, 646, 16, 15),
              };
        }


        public virtual void Update(GameTime gameTime, scene CurrN) {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > SpawnTimer) {
                Rectangle Rec = _rectangles[MyGameMain.Random.Next(0,20)];
                Vector2 pos = new Vector2(MyGameMain.Random.Next(100, (int)(MyGameMain.originalX - 100 / MyGameMain.scaleX)), 10 / MyGameMain.scaleY);
                CurrN.addEntry(new Asteroid(_textures, Rec, pos));

                _timer = 0;
            }
        }
    }
}

