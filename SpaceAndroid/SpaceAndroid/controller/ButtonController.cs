using System;
using System.Drawing;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using static System.Formats.Asn1.AsnWriter;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SpaceAndroid {
    public class ButtonController {
        public TouchCollection touchState;

        private MouseState _currentTouch;
        private MouseState _prevousTouch;

        private SpriteFont Font;

        public Texture2D Texture;

        public event EventHandler Click;

        public bool Clicked;

        public Vector2 Position;

        public Rectangle Rectangle;
        public Rectangle Source;
        public Rectangle src;

        public string Text;
        public Color TextColor;

        public Vector2 Origin;

        public Color Color;

        private MouseState oldState;

        public float Layer;
        float _timer = 0;
        float tim = 0.15f;

        public ButtonController(Texture2D t, Rectangle s, SpriteFont f, Color c) {
            Texture = t;
            Source = s;
            Font = f;
            Color = c;

            Origin = new Vector2(Source.Height / 2, Source.Width / 2);

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, s.Width, s.Height);
            Layer = 0.7f;
        }

        public void Draw(GameTime gt, SpriteBatch sb) {
            sb.Draw(Texture, Position, Source, Microsoft.Xna.Framework.Color.White, 0, Origin, 1, SpriteEffects.None, Layer);
        }

        public virtual void Update(GameTime gameTime, scene currN) {
            int previousId = -1;
            MouseState newState = Mouse.GetState();

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > tim) {
                _timer = 0;

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) {
                    Vector2 vmes = new Vector2(newState.X / MyGameMain.scale, newState.Y / MyGameMain.scale);
                    if (src.Contains(vmes)) {
                        if (MyGameMain._gameplay.isPaused == true) {
                            MyGameMain._gameplay.isPaused = false;
                        }
                        else { 
                            MyGameMain._gameplay.isPaused = true;
                        }
                        Console.WriteLine(currN.Boop);
                        currN.Boop.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                        MediaPlayer.Stop();
                    }
                }

                oldState = newState;

                src = new Rectangle((int)Position.X - Source.Height / 2, (int)Position.Y - Source.Width / 2, Rectangle.Width, Rectangle.Height);
                touchState = TouchPanel.GetState();

                if (touchState.Count > 0) {
                    if (touchState[0].State == TouchLocationState.Moved || touchState[0].State == TouchLocationState.Pressed) {
                        if (touchState[0].Id != previousId) {
                            Vector2 pos = new Vector2(touchState[0].Position.X / MyGameMain.scale, touchState[0].Position.Y / MyGameMain.scale);
                            if (src.Contains(pos)) {
                                if (MyGameMain._gameplay.isPaused == true) {
                                    MyGameMain._gameplay.isPaused = false;
                                }
                                else {
                                    MyGameMain._gameplay.isPaused = true;
                                }
                                currN.Boop.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                                MediaPlayer.Stop();

                            }
                            previousId = touchState[0].Id;
                        }
                    }
                }
            }
        }
    }
}