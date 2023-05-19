using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceAndroid {
    public class LeaderboardEntry : scene {
        public LeaderboardEntry(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = null;
            _PowerUpController = null;
            _backgroundManager = null;

            First = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Second = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Third = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            _content.LdbSecond.Text = Second[1];
            this.addPauseMenu(_content.MenuScreen);

            this.addLevelEndMenu(_content.MenuScreen);
            this.addLevelEndText(_content.Name);
            this.addLevelEndText(_content.LdbFirst);
            this.addLevelEndText(_content.LdbSecond);
            this.addLevelEndText(_content.LdbThird);

            this.addLevelEndButton(_content.Up1);
            this.addLevelEndButton(_content.Up2);
            this.addLevelEndButton(_content.Up3);
            this.addLevelEndButton(_content.Down1);
            this.addLevelEndButton(_content.Down2);
            this.addLevelEndButton(_content.Down3);
            this.addLevelEndButton(_content.FinishLb);

            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);

            this.Background = _content.Background;
        }
    }
}

