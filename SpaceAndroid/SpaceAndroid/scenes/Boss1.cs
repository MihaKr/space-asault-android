using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid { 
    public class Boss1 : scene {
        public Boss1(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            this.setPlayer(_content.ship);

            this.addAnimation(_content.explosion);
            this.addAnimation(_content.engine);

            this.addItem(_content.Boss2);
            this.addText(_content.Score);
            this.addUI(_content.Lives);
            this.addUI(_content.ScoreBox);
            this.addButton(_content.button);
            _enemyController = new BossController(_content.sheet);
            _backgroundManager = new BackgroundManager(_content.sheet);

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

            this.Background = _content.Background;
            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);

        }

        public override void Reset() {
            sprites = new List<sprite>();
            removedEn = new List<sprite>();
            Entry = new List<sprite>();
            Buttons = new List<ButtonController>();
            Animations = new List<AnimatedSprite>();

            this.setPlayer(_content.ship);
            this.addItem(_content.Boss1);
            this.addText(_content.Score);
            this.addUI(_content.Lives);
            this.addUI(_content.ScoreBox);
            this.addButton(_content.button);
        }
    }
}

