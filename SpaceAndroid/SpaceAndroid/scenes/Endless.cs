using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceAndroid {
    public class Endless : scene {

        public Endless(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = new EnemyController(_content.sheet);
            _PowerUpController = new PowerUpController(_content.sheet);
            _backgroundManager = new BackgroundManager(_content.sheet);

            List<Vector2> path1a = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2, MyGameMain.originalY / 2), new Vector2(0, MyGameMain.originalY), new Vector2(1000 / MyGameMain.scaleX, 0) };
            List<Vector2> path1b = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2, MyGameMain.originalY / 2), new Vector2(MyGameMain.originalX, MyGameMain.originalY), new Vector2(1000 / MyGameMain.scaleX, 0) };

            List<Vector2> path2a = new List<Vector2>() { new Vector2(0, 250 / MyGameMain.scaleY), new Vector2(300 / MyGameMain.scaleX, 500 / MyGameMain.scaleY), new Vector2(0, 750 / MyGameMain.scaleY), new Vector2(300 / MyGameMain.scaleX, 1000 / MyGameMain.scaleY), new Vector2(0, 1250 / MyGameMain.scaleY), new Vector2(300 / MyGameMain.scaleX, 1500 / MyGameMain.scaleY), new Vector2(-200 / MyGameMain.scaleX, 1500 / MyGameMain.scaleY) };
            List<Vector2> path2b = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2 - 150 / MyGameMain.scaleX, 250 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2 + 150 / MyGameMain.scaleX, 500 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2 - 150 / MyGameMain.scaleX, 750 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2 + 150 / MyGameMain.scaleX, 1000 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2 - 150 / MyGameMain.scaleX, 1250 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2 - 150 / MyGameMain.scaleX, 1500 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX / 2, -200 / MyGameMain.scaleY) };
            List<Vector2> path2c = new List<Vector2>() { new Vector2(MyGameMain.originalX - 300 / MyGameMain.scaleX, 250 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 500 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 300 / MyGameMain.scaleX, 750 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 1000 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 1250 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX - 300 / MyGameMain.scaleX, 1500 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX + 200 / MyGameMain.scaleX, 1500 / MyGameMain.scaleY) };

            List<Vector2> path3a = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150 / MyGameMain.scaleX, 150 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 150 / MyGameMain.scaleY) };
            List<Vector2> path3b = new List<Vector2>() { new Vector2(0, 300 / MyGameMain.scaleY), new Vector2(-100 / MyGameMain.scaleX, 300 / MyGameMain.scaleY) };
            List<Vector2> path3c = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150 / MyGameMain.scaleX, 450 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 450 / MyGameMain.scaleY) };
            List<Vector2> path3d = new List<Vector2>() { new Vector2(0, 600 / MyGameMain.scaleY), new Vector2(-100 / MyGameMain.scaleX, 600 / MyGameMain.scaleY) };
            List<Vector2> path3e = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150 / MyGameMain.scaleX, 750 / MyGameMain.scaleY), new Vector2(MyGameMain.originalX, 750 / MyGameMain.scaleY) };
            List<Vector2> path3f = new List<Vector2>() { new Vector2(0, 900 / MyGameMain.scaleY), new Vector2(-100 / MyGameMain.scaleX, 900 / MyGameMain.scaleY) };

            groups = new List<int>() { 0, 1, 1, 2, 1 };
            //groups = new List<int>() { 0, -1 };

            this.setPlayer(_content.ship);
            this.addAnimation(_content.explosion);
            this.addAnimation(_content.engine);

            this.addItem(_content.enemy1);
            //this.addItem(_content.Shield);
            this.addItem(_content.enemy2);
            this.addItem(_content.enemy3);
            this.addButton(_content.button);
            this.addText(_content.Score);
            this.addUI(_content.Lives);
            this.addUI(_content.ScoreBox);

            this.addPauseMenu(_content.MenuScreen);

            this.addPauseText(_content.Pause);
            this.addPauseText(_content.Resume);
            this.addPauseText(_content.Restart);
            this.addPauseText(_content.Pause_Settings);
            this.addPauseText(_content.Quit);

            this.addPauseButton(_content.ResumeButton);
            this.addPauseButton(_content.RestartButton);
            this.addPauseButton(_content.PauseSettingsButton);
            this.addPauseButton(_content.QuitButton);

            this.addLevelEndMenu(_content.MenuScreen);
            this.addLevelEndText(_content.LevelFinished);
            this.addLevelEndText(_content.LevelIndex);
            this.addLevelEndText(_content.Progress);
            this.addLevelEndText(_content.NextLevel);
            this.addLevelEndText(_content.Menu);

            this.addLevelEndButton(_content.NextLevelButton);

            this.addLevelEndButton(_content.QuitButton2);

            this.addPath(path1a);
            this.addPath(path1b);

            this.addPath(path2a);
            this.addPath(path2b);
            this.addPath(path2c);

            this.addPath(path3a);
            this.addPath(path3b);
            this.addPath(path3c);
            this.addPath(path3d);
            this.addPath(path3e);
            this.addPath(path3f);

            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);

            this.Background = _content.Background;
        }

        public override void Reset() {
            sprites.Clear();
            removedEn.Clear();
            Entry.Clear();

            this.setPlayer(_content.ship);
            this.player.sc.Score = 0;
            this.group = 0;
        }
    }
}

