using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class SpriteModel{

        public Texture2D texture { get; set; }
        public Rectangle sourceRectangle { get; set; }
        public Vector2 origin { get; set; }
        public Vector2 position { get; set; }
        public float lifespan = 0;
        public bool removed = false;
        public sprite parent { get; set; }
        public scene curr { get; set; }

        public SpriteModel() {

        }
    }
}

