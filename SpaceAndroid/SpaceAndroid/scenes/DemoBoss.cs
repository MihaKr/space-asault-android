using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid { 
    public class DemoBoss : scene {
        public DemoBoss(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            this.setPlayer(_content.ship);
            this.addItem(_content.Boss1);
            this.addText(_content.Score);
            this.addUI(_content.Lives);
            this.addUI(_content.ScoreBox);
            this.addButton(_content.button);
            _enemyController = new BossController(_content.sheet);
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

