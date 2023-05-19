using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceAndroid {
    public class DemoLevel2 : scene {
        public DemoLevel2(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = new EnemyController(_content.sheet);
            _PowerUpController = new PowerUpController(_content.sheet);
            _backgroundManager = new BackgroundManager(_content.sheet);

            List<Vector2> path1a = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2, MyGameMain.originalY / 2), new Vector2(0, MyGameMain.originalY), new Vector2(1000 / MyGameMain.scaleX, 0) };
            List<Vector2> path1b = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2, MyGameMain.originalY / 2), new Vector2(MyGameMain.originalX, MyGameMain.originalY), new Vector2(1000, 0) };

            List<Vector2> path2a = new List<Vector2>() { new Vector2(0, 250), new Vector2(300, 500), new Vector2(0, 750), new Vector2(300, 1000), new Vector2(0, 1250), new Vector2(300, 1500), new Vector2(-200, 1500) };
            List<Vector2> path2b = new List<Vector2>() { new Vector2(MyGameMain.originalX / 2 - 150, 250), new Vector2(MyGameMain.originalX / 2 + 150, 500), new Vector2(MyGameMain.originalX / 2 - 150, 750), new Vector2(MyGameMain.originalX / 2 + 150, 1000), new Vector2(MyGameMain.originalX / 2 - 150, 1250), new Vector2(MyGameMain.originalX / 2 - 150, 1500), new Vector2(MyGameMain.originalX / 2, -200) };
            List<Vector2> path2c = new List<Vector2>() { new Vector2(MyGameMain.originalX - 300, 250), new Vector2(MyGameMain.originalX, 500), new Vector2(MyGameMain.originalX - 300, 750), new Vector2(MyGameMain.originalX, 1000), new Vector2(MyGameMain.originalX, 1250), new Vector2(MyGameMain.originalX - 300, 1500), new Vector2(MyGameMain.originalX + 200, 1500) };

            List<Vector2> path3a = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150, 150), new Vector2(MyGameMain.originalX, 150) };
            List<Vector2> path3b = new List<Vector2>() { new Vector2(0, 300), new Vector2(-100, 300) };
            List<Vector2> path3c = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150, 450), new Vector2(MyGameMain.originalX, 450) };
            List<Vector2> path3d = new List<Vector2>() { new Vector2(0, 600), new Vector2(-100, 600) };
            List<Vector2> path3e = new List<Vector2>() { new Vector2(MyGameMain.originalX + 150, 750), new Vector2(MyGameMain.originalX, 750) };
            List<Vector2> path3f = new List<Vector2>() { new Vector2(0, 900), new Vector2(-100, 900) };

            groups = new List<int>() { 0, 2, 1, 0, 2, 1, 0, 2, 2, 1, 0, -1};

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
    }
}

