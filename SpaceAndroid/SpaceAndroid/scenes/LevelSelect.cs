using System;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class LevelSelect : scene {
        public LevelSelect(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = null;
            _backgroundManager = null;

            this.Background = _content.Background;
            this.addUI(_content.MenuScreen);
            this.addButton(_content.LevelOne);
            this.addButton(_content.LevelTwo);
            this.addButton(_content.LevelThree);
            this.addButton(_content.Back);
            this.addButton(_content.EndlessButton);
            this.addText(_content.Endl);
            this.addText(_content.One);
            this.addText(_content.Two);
            this.addText(_content.Three);
            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);
        }
    }
}

