using System;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class menu : scene {
        public menu(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = null;
            _backgroundManager = null;

            this.Background = _content.Background;
            this.addUI(_content.MenuScreen);
            this.addButton(_content.Play);
            this.addButton(_content.Settings);
            this.addButton(_content.LevelSelect);
            this.addButton(_content.Leaderboard);
            this.addText(_content.PlayT);
            this.addText(_content.SettingsT);
            this.addText(_content.LevelSelectT);
            this.addText(_content.Title);
            this.addText(_content.LeaderbaordT);
            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);
        }
    }
}

