﻿using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SpaceAndroid {
    public class LevelSelectButton : ButtonController {
        private MouseState oldState;
        float _timer = 0;
        float tim = 0.15f;

        public LevelSelectButton(Texture2D t, Rectangle s, SpriteFont f, Color c) : base(t, s, f, c) {
        }

        public override void Update(GameTime gameTime, scene currN) {

            MouseState newState = Mouse.GetState();

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > tim) {
                _timer = 0;


                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) {
                Vector2 vmes = new Vector2(newState.X / MyGameMain.scale, newState.Y / MyGameMain.scale);
                if (src.Contains(vmes)) {
                    MyGameMain._nextScene = MyGameMain.first;
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
                            MyGameMain._nextScene = MyGameMain.LevelSelect;
                            currN.Boop.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
                        }
                    }
                }
            }
           }
    }
}


