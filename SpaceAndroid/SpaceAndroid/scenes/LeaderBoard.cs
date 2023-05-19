using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceAndroid {
    public class LeaderBoard : scene {
        public LeaderBoard(LoadContent c, GraphicsDevice g, MyGameMain gm) : base(c, g, gm) {
            _enemyController = null;
            _backgroundManager = null;

            this.Background = _content.Background;
            _content.UpdateScores();

            this.addItem(_content.MenuScreen);
            this.addButton(_content.Back);
            this.addSounds(_content.Laser, _content.Boop, _content.Exp, _content.ShieldBounce, _content.PlayerHit, _content.ShieldOn, _content.LevelEndSong);
            this.addText(_content.One1);
            this.addText(_content.Two1);
            this.addText(_content.Three1);
            this.addText(_content.Four);
            this.addText(_content.Five);

            this.addText(_content.FirstName);
            this.addText(_content.FirstScore);

            this.addText(_content.SecondName);
            this.addText(_content.SecondScore);

            this.addText(_content.ThirdName);
            this.addText(_content.ThirdScore);

            this.addText(_content.FourthName);
            this.addText(_content.FourthScore);

            this.addText(_content.FifthName);
            this.addText(_content.FifthScore);
        }

        public void ResetScore() {
            _content.UpdateScores();
            text.Clear();

            this.addText(_content.One1);
            this.addText(_content.Two1);
            this.addText(_content.Three1);
            this.addText(_content.Four);
            this.addText(_content.Five);

            this.addText(_content.FirstName);
            this.addText(_content.FirstScore);

            this.addText(_content.SecondName);
            this.addText(_content.SecondScore);

            this.addText(_content.ThirdName);
            this.addText(_content.ThirdScore);

            this.addText(_content.FourthName);
            this.addText(_content.FourthScore);

            this.addText(_content.FifthName);
            this.addText(_content.FifthScore);
        }
    }
}

