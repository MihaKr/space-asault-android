using System;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class SettingsMenu : scene { 
        public SettingsMenu(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = null;
            _backgroundManager = null;

            this.Background = _content.Background;
            this.addItem(_content.MenuScreen);
            this.addButton(_content.Back);
            this.addText(_content.Music);
            this.addButton(_content.OnOff);
            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);
        }
    }
}

