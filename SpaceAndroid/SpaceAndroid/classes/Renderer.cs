using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace SpaceAndroid {
    public class Renderer {
        scene _currentScene;
        private float _w;
        private float _h;


        public Renderer(scene sc, float w, float h) {
            _currentScene = sc;
            _w = w;
            _h = h;
        }

        public void Draw(SpriteBatch _spriteBatch, GameTime gameTime) {
           //_spriteBatch.Draw(_currentScene.Background, new Vector2(0, 0), new Rectangle(0, 0, 256, 256), Color.White, 0, new Vector2(0, 0), new Vector2(_w, _h), SpriteEffects.None, 1);
            //_currentScene.Background2.Draw(gameTime, _spriteBatch);
            _currentScene.Background.Draw(gameTime, _spriteBatch);


            for (int i = 0; i < _currentScene.UI_element.Count; i++) {
                _currentScene.UI_element[i].Draw(gameTime, _spriteBatch);
            }

            for (int i = 0; i < _currentScene.sprites.Count; i++) {
                if (_currentScene.sprites[i] is player) {
                    sprite expAn = _currentScene.Animations[1].SpriteAtTime(gameTime.TotalGameTime);
                    if (expAn != null) { 
                        _currentScene.sprites[i].exp = expAn.Clone() as sprite;
                    }
                }
                _currentScene.sprites[i].Draw(gameTime, _spriteBatch);
            }

            for (int i = 0; i < _currentScene.Buttons.Count; i++) {
                _currentScene.Buttons[i].Draw(gameTime, _spriteBatch);
            }

            for (int i = 0; i < _currentScene.text.Count; i++) {
                _currentScene.text[i].Draw(gameTime, _spriteBatch);
            }

            for (int i = 0; i < _currentScene.PowerUps.Count; i++) {
                _currentScene.PowerUps[i].Draw(gameTime, _spriteBatch);
            }


            for (int i = 0; i < _currentScene.removedEn.Count; i++) {
                if (_currentScene.removedEn[i] is enemy) { 
                sprite expAn = _currentScene.Animations[0].SpriteAtTime(gameTime.TotalGameTime);
                    if (expAn != null) {
                        _currentScene.removedEn[i].exp = expAn.Clone() as sprite;
                        _spriteBatch.Draw(_currentScene.removedEn[i].exp.texture, _currentScene.removedEn[i].position, _currentScene.removedEn[i].exp.sourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);
                    }
                    else {
                        _currentScene.removedEn.RemoveAt(i);
                    }
                }
            }

            if (MyGameMain._gameplay.isPaused) {
                for (int i = 0; i < _currentScene.PauseMenu.Count; i++){
                    _currentScene.PauseMenu[i].Draw(gameTime, _spriteBatch);
                }

                for (int i = 0; i < _currentScene.PauseText.Count; i++) {
                    _currentScene.PauseText[i].Draw(gameTime, _spriteBatch);
                }

                for (int i = 0; i < _currentScene.PauseButtons.Count; i++) {
                    _currentScene.PauseButtons[i].Draw(gameTime, _spriteBatch);
                }
            }

            if (MyGameMain._gameplay.LevelEnd || MyGameMain._gameplay.Finished) {
                for (int i = 0; i < _currentScene.LevelEndMenu.Count; i++) {
                    _currentScene.LevelEndMenu[i].Draw(gameTime, _spriteBatch);
                }

                for (int i = 0; i < _currentScene.LevelEndText.Count; i++) {
                    _currentScene.LevelEndText[i].Draw(gameTime, _spriteBatch);
                }

                for (int i = 0; i < _currentScene.LevelEndButtons.Count; i++) {
                    _currentScene.LevelEndButtons[i].Draw(gameTime, _spriteBatch);
                }
            }
        }

        public void ChangeScene(scene NewScene) {
            _currentScene = NewScene;
        }
    }
}

