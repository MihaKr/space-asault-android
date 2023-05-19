using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceAndroid {
    public class scene {
        public player player;
        public List<sprite> sprites;
        public List<sprite> removedEn;
        public List<sprite> Entry;
        public List<Font> text;
        public List<sprite> UI_element;
        public List<List<Vector2>> paths;
        public List<int> groups;
        public int group = 0;

        public List<PowerUp> PowerUps;

        public List<sprite> PauseMenu;
        public List<Font> PauseText;
        public List<ButtonController> PauseButtons;

        public List<sprite> LevelEndMenu;
        public List<Font> LevelEndText;
        public List<ButtonController> LevelEndButtons;

        public List<ButtonController> Buttons;
        public List<AnimatedSprite> Animations;
        public SpriteFont font;
        public sprite Background;
        public sprite Background2;


        public LoadContent _content;
        public EnemyController _enemyController;
        public PowerUpController _PowerUpController;
        public BackgroundManager _backgroundManager;

        protected GraphicsDevice _graphicsDevice;
        protected MyGameMain _game;

        public SoundEffect Laser;
        public SoundEffect Boop;
        public SoundEffect Exp;
        public SoundEffect ShieldOn;
        public SoundEffect ShieldBounce;
        public SoundEffect PlayerHit;

        public Song LevelEndSong;

        public List<String> First;
        public List<String> Second;
        public List<String> Third;

        public int FirstInd = 0;
        public int SecondInd = 0;
        public int ThirdInd = 0;

        public scene(LoadContent c, GraphicsDevice g, MyGameMain gm) {
            sprites = new List<sprite>();
            Entry = new List<sprite>();
            Buttons = new List<ButtonController>();
            Animations = new List<AnimatedSprite>();
            text = new List<Font>();
            UI_element = new List<sprite>();
            paths = new List<List<Vector2>>();
            PowerUps = new List<PowerUp>();
            removedEn = new List<sprite>();
            PauseMenu = new List<sprite>();
            PauseText = new List<Font>();
            PauseButtons = new List<ButtonController>();
            LevelEndMenu = new List<sprite>();
            LevelEndText = new List<Font>();
            LevelEndButtons = new List<ButtonController>();
            Background2 = MyGameMain._content.Background2;

            _content = c;
            _graphicsDevice = g;
            _game = gm;
        }

        public void setPlayer(player pl) {
            player = pl;
            addItem(player);
        }

        public void addItem(sprite item) {
            sprites.Add(item);
        }

        public void addRemoved(sprite item) {
            removedEn.Add(item);
        }

        public void addEntry(sprite item) {
            Entry.Add(item);
        }

        public void addButton(ButtonController item) {
            Buttons.Add(item);
        }

        public void addText(Font item){
            text.Add(item);
        }

        public void addUI(sprite item) {
            UI_element.Add(item);
        }

        public void addPauseMenu(sprite item){
            PauseMenu.Add(item);
        }

        public void addPauseText(Font item) {
            PauseText.Add(item);
        }

        public void addPauseButton(ButtonController item){
            PauseButtons.Add(item);
        }

        public void addLevelEndMenu(sprite item) {
            LevelEndMenu.Add(item);
        }

        public void addLevelEndText(Font item) {
            LevelEndText.Add(item);
        }

        public void addLevelEndButton(ButtonController item) {
            LevelEndButtons.Add(item);
        }

        public void addPath(List<Vector2> item) {
            paths.Add(item);
        }

        public void addPowerup(PowerUp item) {
            PowerUps.Add(item);
        }

        public void addAnimation(AnimatedSprite item) {
            Animations.Add(item);
        }

        public void addSounds(SoundEffect l, SoundEffect b, SoundEffect e, SoundEffect sh, SoundEffect ph, SoundEffect so, Song Le) {
            Boop = b;
            Laser = l;
            Exp = e;
            ShieldBounce = sh;
            PlayerHit = ph;
            ShieldOn = so;
            LevelEndSong = Le;
        }

        public virtual void Reset() {
        }
    }
}

