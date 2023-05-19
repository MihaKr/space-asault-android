using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SpaceAndroid {
    public partial class sprite: ICloneable{
        public Texture2D texture;
        public Rectangle sourceRectangle;
        public Vector2 origin;
        public Vector2 position;
        public float rotationV = (float) 2;
        public float velocity = 5;
        public float lifespan = 0;
        public bool removed = false;
        public sprite parent;
        public scene curr;
        public int lives;
        public sprite exp;
        public Vector2 scale = new Vector2(2,2);
        public float Layer;

        public enum EnemyState {
            Basic,
            Evader,
            Final,
        }

        public enum EnemyStateN{
            Normal,
            Kamikaze,
        }

        protected float _layer { get; set; }

        public ScoreModel sc;

        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public sprite (Texture2D textureN, Rectangle sourceRectangleN, Vector2 positionN){
            texture = textureN;
            sourceRectangle = sourceRectangleN;
            origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
            position = positionN;
            Layer = 0.5f;
        }

        public Rectangle getCollisionRectangle() {
            return (new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width*(int)scale.X, sourceRectangle.Height*(int)scale.Y));
        }

        public Rectangle GetRectangle() {
            return sourceRectangle;
        }

        public Vector2 getOrigin() {
            return origin;
        }

        public void setPosition(Vector2 pos) {
             position = pos;
        }

        public Vector2 getPosition() {
            return position;
        }

        public virtual void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(texture, position, sourceRectangle, Microsoft.Xna.Framework.Color.White, 0, origin, scale, SpriteEffects.None, Layer);
        }

        public virtual void Update(GameTime gameTime, scene currN) {
        }

        public Matrix Transform {
            get {
                return Matrix.CreateTranslation(new Vector3(origin, 0)) *
                  Matrix.CreateRotationZ(rotationV) *
                  Matrix.CreateTranslation(new Vector3(position, 0));
            }
        }

        public virtual bool ColisionDetection(sprite sp) {
            if (sp == null) {
                return false;
            }
            else {
                bool Top = (this.getCollisionRectangle().Bottom > sp.getCollisionRectangle().Top &&
                            this.getCollisionRectangle().Top < sp.getCollisionRectangle().Top &&
                            this.getCollisionRectangle().Right > sp.getCollisionRectangle().Left &&
                            this.getCollisionRectangle().Left < sp.getCollisionRectangle().Right);

                bool Bottom = (this.getCollisionRectangle().Top < sp.getCollisionRectangle().Bottom &&
                            this.getCollisionRectangle().Bottom > sp.getCollisionRectangle().Bottom &&
                            this.getCollisionRectangle().Right > sp.getCollisionRectangle().Left &&
                            this.getCollisionRectangle().Left < sp.getCollisionRectangle().Right);

                bool Left = (this.getCollisionRectangle().Right > sp.getCollisionRectangle().Left &&
                            this.getCollisionRectangle().Left < sp.getCollisionRectangle().Left &&
                            this.getCollisionRectangle().Bottom > sp.getCollisionRectangle().Top &&
                            this.getCollisionRectangle().Top < sp.getCollisionRectangle().Bottom);

                bool Right = (this.getCollisionRectangle().Left < sp.getCollisionRectangle().Right &&
                            this.getCollisionRectangle().Right > sp.getCollisionRectangle().Right &&
                            this.getCollisionRectangle().Bottom > sp.getCollisionRectangle().Top &&
                            this.getCollisionRectangle().Top < sp.getCollisionRectangle().Bottom);

                
                return Top || Bottom || Left || Right;
            }
            //TODO: Izboljšat colison detection
        }
        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}