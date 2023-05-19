using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Media;

namespace SpaceAndroid {
    public class Gameplay {
        scene CurrentScene;
        EnemyController _enemyController;
        PowerUpController _powerUpController;
        LeaderBoardManager _leaderboard;
        public bool isPaused = false;
        public bool LevelEnd = false;
        public bool Finished = false;
        public int Score = 0;

        public List<scene> Levels = new List<scene>();

        public bool BossFight = false;
        public int stageInd = 1;
        public int LevelInd = 0;

        public Gameplay(scene s, EnemyController e, PowerUpController p, LeaderBoardManager l) {
            CurrentScene = s;
            _enemyController = e;
            _powerUpController = p;
            _leaderboard = l;
        }

        public void AddLevel(scene level) {
            Levels.Add(level);
        }

        public void Update(GameTime gameTime) {
            CurrentScene.Background.position.Y += 2;

            if (CurrentScene.Background.position.Y > MyGameMain.originalY) {
                CurrentScene.Background.position.Y = 0;
            }

            if (CurrentScene._backgroundManager != null) {
                CurrentScene._backgroundManager.Update(gameTime, CurrentScene);
            }

            for (int i = 0; i < CurrentScene.Buttons.Count; i++) {
                CurrentScene.Buttons[i].Update(gameTime, CurrentScene);
            }

            for (int i = 0; i < CurrentScene.text.Count; i++) {
                CurrentScene.text[i].Update(gameTime, CurrentScene);
            }

            if (isPaused) {
                //MyGameMain._content.BackgroundSong.Play();
                for (int i = 0; i < CurrentScene.PauseButtons.Count; i++) {
                    CurrentScene.PauseButtons[i].Update(gameTime, CurrentScene);
                }
            }

            if (LevelEnd || Finished) {
                //CurrentScene.LevelEndSong.Play();
                for (int i = 0; i < CurrentScene.LevelEndButtons.Count; i++) {
                    CurrentScene.LevelEndButtons[i].Update(gameTime, CurrentScene);
                }
                for (int i = 0; i < CurrentScene.LevelEndText.Count; i++) {
                    CurrentScene.LevelEndText[i].Update(gameTime, CurrentScene);
                }
            }

            if (!isPaused && !LevelEnd) {
                for (int i = 0; i < CurrentScene.Entry.Count; i++) {
                    CurrentScene.addItem(CurrentScene.Entry[i]);
                }
                CurrentScene.Entry.Clear();

                for (int i = 0; i < CurrentScene.sprites.Count; i++) {
                    CurrentScene.sprites[i].Update(gameTime, CurrentScene);
                }

                if (_enemyController != null) {
                    _enemyController.Update(gameTime);
                    if (_enemyController.CanAdd && CurrentScene.sprites.Where(c => c is enemy).Count() < _enemyController.MaxEnemies) {
                        _enemyController.NextGroup(CurrentScene);
                    }
                }

                if (_powerUpController != null) {
                    _powerUpController.Update(gameTime, CurrentScene);
                    if (_powerUpController.CanAdd) {
                        _powerUpController.Add(CurrentScene);
                    }
                }

                for (int i = 0; i < CurrentScene.PowerUps.Count; i++) {
                    CurrentScene.PowerUps[i].Update(gameTime, CurrentScene);
                }

                if ((CurrentScene.player != null) && ((CurrentScene != MyGameMain.Boss1) && (CurrentScene != MyGameMain.Boss2) && (CurrentScene != MyGameMain.Boss3))) {
                    if (CurrentScene.groups[CurrentScene.group] == -2) {
                        BossFight = true;
                        stageInd++;
                    }

                    if (CurrentScene.groups[CurrentScene.group] == -1) {
                        LevelEnd = true;
                    }
                }

                if (Finished && CurrentScene.player != null) {
                    MyGameMain._nextScene = MyGameMain.lbe;
                }
            }
            remover();
        }

        private void remover() {
            for (int i = 0; i < CurrentScene.sprites.Count; i++) {
                if (CurrentScene.sprites[i].removed) {
                    if (CurrentScene.sprites[i] is SpaceAndroid.enemy) {
                        CurrentScene.addRemoved((enemy)CurrentScene.sprites[i]);
                    }
                    if (CurrentScene.sprites[i] is SpaceAndroid.Shield) {
                        CurrentScene.addRemoved(CurrentScene.sprites[i]);
                    }
                    if (CurrentScene.sprites[i] is SpaceAndroid.BossEnemy) {
                        LevelEnd = true;
                        CurrentScene.addRemoved(CurrentScene.sprites[i]);
                    }
                    CurrentScene.sprites.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < CurrentScene.PowerUps.Count; i++) {
                if (CurrentScene.PowerUps[i].removed) {
                    CurrentScene.addRemoved(CurrentScene.PowerUps[i]);
                    CurrentScene.PowerUps.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ChangeScene(scene NewScene) {
            MediaPlayer.Stop();
            CurrentScene = NewScene;
            _enemyController = NewScene._enemyController;
            _powerUpController = NewScene._PowerUpController;
        }
    }
}