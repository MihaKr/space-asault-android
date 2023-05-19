using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SpaceAndroid {
    public class LetterUp : ButtonController {
        List<String> Select;
        int Ind;
        Font F;
        private MouseState oldState;
        float _timer = 0;
        float tim = 0.15f;

        public LetterUp(Texture2D t, Rectangle s, SpriteFont f, Color c, List<String> Sleve, int inde, Font x) : base(t, s, f, c) {
            Select = Sleve;
            Ind = inde;
            F = x;
        }

        public override void Update(GameTime gameTime, scene currN) {
            MouseState newState = Mouse.GetState();

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > tim) {
                _timer = 0;

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) {
                    Vector2 vmes = new Vector2(newState.X / MyGameMain.scale, newState.Y / MyGameMain.scale);
                    if (src.Contains(vmes)) {
                        Ind++;

                        if (Ind == 25) {
                            Ind = 0;
                        }

                        F.Text = Select[Ind];

                        currN.Boop.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                    }
                }

                oldState = newState;

                src = new Rectangle((int)Position.X - Source.Height / 2, (int)Position.Y - Source.Width / 2, Rectangle.Width, Rectangle.Height);
                touchState = TouchPanel.GetState();

                if (touchState.Count > 0) {
                    if (touchState[0].State == TouchLocationState.Moved || touchState[0].State == TouchLocationState.Pressed) {
                        Vector2 pos = new Vector2(touchState[0].Position.X / MyGameMain.scale, touchState[0].Position.Y / MyGameMain.scale);
                        if (src.Contains(pos)) {
                            Ind++;

                            if (Ind == 25) {
                                Ind = 0;
                            }

                            F.Text = Select[Ind];

                            currN.Boop.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                        }
                    }
                }
            }
        }
    }
}

