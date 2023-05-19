using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Android.Content.Res;
using Java.Lang;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpriteFontPlus;

using static System.Formats.Asn1.AsnWriter;

namespace SpaceAndroid
{
    public class LoadContent
    {
        public Texture2D background1;
        public Texture2D background2;

        public Texture2D sheet { get; set; }

        public scene first;
        public scene menu;

        public player ship;
        public player fake;

        public Shield Shield;

        public sprite asteroid1;
        public enemy enemy1;
        public enemy enemy2;
        public enemy enemy3;
        public AnimatedSprite engine;
        public AnimatedSprite explosion;
        public Texture2D UI;

        public sprite Lives;
        public sprite ScoreBox;

        public ButtonController button;

        public sprite Background;
        public sprite Background2;


        public Texture2D BMenu;

        public ButtonController Play;
        public ButtonController Settings;
        public ButtonController LevelSelect;
        public ButtonController Leaderboard;

        public ButtonController LevelOne;
        public ButtonController LevelTwo;
        public ButtonController LevelThree;

        public ButtonController Back;

        public ButtonController OnOff;

        public ButtonController ResumeButton;
        public ButtonController RestartButton;
        public ButtonController PauseSettingsButton;
        public ButtonController QuitButton;

        public ButtonController QuitButton2;
        public ButtonController EndlessButton;

        public ButtonController NextLevelButton;
        public ButtonController FinishLb;

        public ScoreFont Score;
        public LevelProg LevelIndex;


        public SpriteFont font;

        public Font One;
        public Font Two;
        public Font Three;

        public Font One1;
        public Font Two1;
        public Font Three1;
        public Font Four;
        public Font Five;
        public Font Six;
        public Font Seven;
        public Font Eight;
        public Font Nine;
        public Font Ten;

        public Font FirstScore;
        public Font SecondScore;
        public Font ThirdScore;
        public Font FourthScore;
        public Font FifthScore;

        public Font FirstName;
        public Font SecondName;
        public Font ThirdName;
        public Font FourthName;
        public Font FifthName;

        public Font Music;

        public Font PlayT;
        public Font SettingsT;
        public Font LevelSelectT;
        public Font LeaderbaordT;

        public Font LevelFinished;
        public Font Menu;
        public Font NextLevel;
        public Font Progress;

        public Font Title;
        public Font Pause;
        public Font Resume;
        public Font Restart;
        public Font Pause_Settings;
        public Font Quit;

        public Font Name;
        public Font Endl;

        public Font LdbFirst;
        public Font LdbSecond;
        public Font LdbThird;

        public GraphicsDevice _graphicsDevice;

        public sprite MenuScreen;

        public BossEnemy Boss1;
        public BossEnemy Boss2;


        public sprite Life100;
        public sprite Life75;
        public sprite Life50;
        public sprite Life25;

        public SoundEffect Boop; 
        public SoundEffect Laser;
        public SoundEffect Exp;
        public SoundEffect ShieldOn; 
        public SoundEffect ShieldBounce; 
        public SoundEffect PlayerHit;

        public Song BackgroundSong;
        public Song LevelEndSong;

        public PowerUp blue;

        public ButtonController Up1;
        public ButtonController Up2;
        public ButtonController Up3;

        public ButtonController Down1;
        public ButtonController Down2;
        public ButtonController Down3;

        Texture LifeBar;

        LeaderBoardManager _leaderboard;

        public LoadContent(GraphicsDevice gd, LeaderBoardManager ld)
        {
            _graphicsDevice = gd;
            _leaderboard = ld;
        }

        public static Uri ConvertStreamToUri(Stream stream)
        {
            var memoryStream = stream as MemoryStream;
            if (memoryStream == null)
            {
                memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
            }
            return new Uri(Convert.ToBase64String(memoryStream.ToArray()));
        }

        public void load(AssetManager a)
        {
            AssetManager assets = a;
            Stream fRead = assets.Open("black.png");

            background1 = Texture2D.FromStream(_graphicsDevice, fRead);

            Background = new sprite(background1, new Rectangle(0, 0, 512, 1024), Vector2.Zero);
            Background.scale = new Vector2(MyGameMain._width / 128, MyGameMain._height / 256);
            Background.origin = new Vector2(50, 300);

            Background2 = new sprite(background1, new Rectangle(0, 0, 512, 1024), Vector2.Zero);
            Background.scale = new Vector2(MyGameMain._width / 128, MyGameMain._height / 256);
            Background.origin = new Vector2(256, 512);

            fRead = assets.Open("sheet.png");
            sheet = Texture2D.FromStream(_graphicsDevice, fRead);

            ship = new player(sheet, new Rectangle(211, 941, 99, 75), new Vector2(400, 300));
            fake = new player(sheet, new Rectangle(0, 0, 0, 0), new Vector2(400, 300));

            asteroid1 = new sprite(sheet, new Rectangle(0, 520, 120, 98), new Vector2(200, 400));
            enemy1 = new enemy(sheet, new Rectangle(346, 150, 97, 84), new Vector2(700, 1266));
            enemy2 = new enemy(sheet, new Rectangle(346, 150, 97, 84), new Vector2(600, 800));
            enemy3 = new enemy(sheet, new Rectangle(346, 150, 97, 84), new Vector2(500, 1600));

            ship.bullet = new bullet(sheet, new Rectangle(856, 421, 9, 54), ship.position);
            enemy1.enemybullet = new EnemyBullet(sheet, new Rectangle(856, 421, 9, 54), enemy1.position);
            enemy2.enemybullet = new EnemyBullet(sheet, new Rectangle(856, 421, 9, 54), enemy2.position);
            enemy3.enemybullet = new EnemyBullet(sheet, new Rectangle(856, 421, 9, 54), enemy3.position);

            blue = new PowerUp(sheet, new Rectangle(696, 329, 34, 33), new Vector2(300, 300));

            Shield = new Shield(sheet, new Rectangle(0, 412, 133, 108), new Vector2(400, 200));

            const int maxReadSize = 256 * 1024;
            byte[] content;
            using (BinaryReader br = new BinaryReader(assets.Open("font.ttf")))
            {
                content = br.ReadBytes(maxReadSize);
            }

            var fontBakeResult = TtfFontBaker.Bake(content,
                25,
                1024,
                1024,
                new[] {
                        CharacterRange.BasicLatin,
                        CharacterRange.Latin1Supplement,
                        CharacterRange.LatinExtendedA,
                        CharacterRange.Cyrillic
                    }
                );

            font = fontBakeResult.CreateSpriteFont(_graphicsDevice);

            fRead = assets.Open("interface.png");
            UI = Texture2D.FromStream(_graphicsDevice, fRead);

            float v = (MyGameMain._width - 150);
            v /= MyGameMain.scale;

            Console.WriteLine(v);

            button = new ButtonController(UI, new Rectangle(413, 0, 124, 126), font, Color.Black)
            {
                Position = new Vector2((MyGameMain._width - 150) / MyGameMain.scale, 200 / MyGameMain.scale),
            };

            Play = new PlayButton(UI, new Rectangle(1120, 0, 122, 124), font, Color.Black)
            {
                Position = new Vector2((MyGameMain._width / 3 - 125) / MyGameMain.scale, (MyGameMain._height / 2) / MyGameMain.scale),
            };

            Settings = new SettingsButton(UI, new Rectangle(1270, 0, 122, 124), font, Color.Black)
            {
                Position = new Vector2(((MyGameMain._width / 3 * 2) - 150) / MyGameMain.scale, MyGameMain._height / 2 / MyGameMain.scale),
            };

            LevelSelect = new LevelSelectButton(UI, new Rectangle(413, 0, 124, 126), font, Color.Black)
            {
                Position = new Vector2(((MyGameMain._width / 3 * 3) - 150) / MyGameMain.scale, MyGameMain._height / 2 / MyGameMain.scale),
            };

            Leaderboard = new LeaderBoardButton(UI, new Rectangle(552, 0, 124, 126), font, Color.Black)
            {
                Position = new Vector2((MyGameMain._width / 3 - 125) / MyGameMain.scale, (MyGameMain._height / 2 + 250) / MyGameMain.scale),
            };

            OnOff = new OnOffButton(UI, new Rectangle(410, 145, 400, 207), font, Color.Black)
            {
                Position = new Vector2(((MyGameMain._width / 3 * 2) - 150) / MyGameMain.scale, (MyGameMain._height / 2 + 125) / MyGameMain.scale),
            };

            Score = new ScoreFont("0", new Vector2(140, 240), font);

            ScoreBox = new sprite(UI, new Rectangle(0, 2000, 1375, 336), new Vector2(0, 150));
            ScoreBox.scale = new Vector2(0.3f, 0.5f);
            ScoreBox.origin = Vector2.Zero;
            Lives = new sprite(UI, new Rectangle(0, 2000, 1375, 336), new Vector2(0, 300));
            Lives.scale = new Vector2(0.3f, 0.5f);
            Lives.origin = Vector2.Zero;

            MenuScreen = new sprite(UI, new Rectangle(0, 380, 1024, 1462), Vector2.Divide(new Vector2(MyGameMain._width / 2, MyGameMain._height / 2), MyGameMain.scale));
            MenuScreen.scale = Vector2.Divide(new Vector2(0.6f, 0.5f),MyGameMain.scale);

            Boss1 = new BossEnemy(sheet, new Rectangle(346, 150, 97, 84), new Vector2(700, 1266));
            Boss1.enemybullet = new EnemyBullet(sheet, new Rectangle(856, 421, 9, 54), enemy3.position);
            Boss1.state = sprite.EnemyState.Evader;

            //TODO: life system
            Life100 = new sprite(UI, new Rectangle(0, 380, 1024, 1462), new Vector2(MyGameMain._width / 2, MyGameMain._height / 2));

            enemy1.State = sprite.EnemyStateN.Kamikaze;

            LevelOne = new LevelSelector(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.first)
            {
                Position = Vector2.Divide(new Vector2(1 * MyGameMain._width / 3 - 100, MyGameMain._height / 2), MyGameMain.scale),
            };

            One = new Font("1", Vector2.Divide(new Vector2(MyGameMain._width / 3 - 200, MyGameMain._height / 2), MyGameMain.scale), font);

            LevelTwo = new LevelSelector(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.two)
            {
                Position = Vector2.Divide(new Vector2(2 * MyGameMain._width / 3 - 100, MyGameMain._height / 2), MyGameMain.scale),
            };

            Two = new Font("2", Vector2.Divide(new Vector2(2 * MyGameMain._width / 3 - 200, MyGameMain._height / 2), MyGameMain.scale), font);

            LevelThree = new LevelSelector(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.two)
            {
                Position = Vector2.Divide(new Vector2(3 * MyGameMain._width / 3 - 100, MyGameMain._height / 2), MyGameMain.scale),
            };

            Three = new Font("3", Vector2.Divide(new Vector2(3 * MyGameMain._width / 3 - 200, MyGameMain._height / 2), MyGameMain.scale), font);

            EndlessButton = new LevelSelector(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.Endless)
            {
                Position = new Vector2(2 * MyGameMain.originalX / 3 - 200 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 300 / MyGameMain.scaleY),
            };

            Endl = new Font("Endless", new Vector2(2 * MyGameMain.originalX / 3 - 200 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 150 / MyGameMain.scaleY), font);

            Back = new BackButton(UI, new Rectangle(820, 0, 125, 125), font, Color.Black)
            {
                Position = Vector2.Divide(new Vector2(3 * MyGameMain._width / 3 - 150, MyGameMain._height / 3), MyGameMain.scale),
            };

            Music = new Font("MUSIC", Vector2.Divide(new Vector2(1 * MyGameMain._width / 3 - 200, MyGameMain._height / 2), MyGameMain.scale), font);

            PlayT = new Font("PLAY", Vector2.Divide(new Vector2(MyGameMain._width / 3 - 200, MyGameMain._height / 2 - 150), MyGameMain.scale), font);
            SettingsT = new Font("SETTINGS", Vector2.Divide(new Vector2(MyGameMain._width / 3 * 2 - 350, MyGameMain._height / 2 - 150), MyGameMain.scale), font);
            LevelSelectT = new Font("LEVEL \n SELECT", Vector2.Divide(new Vector2((MyGameMain._width / 3 * 3) - 350, MyGameMain._height / 2 - 150), MyGameMain.scale), font);
            LeaderbaordT = new Font("LEADERBOARD", Vector2.Divide(new Vector2(MyGameMain._width / 3 - 200, MyGameMain._height / 2 + 100), MyGameMain.scale), font);

            Title = new Font("SPACE ASSAULT", Vector2.Divide(new Vector2(MyGameMain._width / 2, MyGameMain._height / 2 - 400), MyGameMain.scale), font);

            fRead = assets.Open("laser.wav");
            Laser = SoundEffect.FromStream(fRead);

            fRead = assets.Open("boop.wav");
            Boop = SoundEffect.FromStream(fRead);

            fRead = assets.Open("enemy_1.wav");
            Exp = SoundEffect.FromStream(fRead);

            fRead = assets.Open("shield_hit.wav");
            ShieldBounce = SoundEffect.FromStream(fRead);

            fRead = assets.Open("shipHit.wav");
            PlayerHit = SoundEffect.FromStream(fRead);

            fRead = assets.Open("shield_on.wav");
            ShieldOn = SoundEffect.FromStream(fRead);

            fRead = assets.Open("startup.wav");

            One1 = new Font("1", new Vector2(300, 1150), font);
            Two1 = new Font("2", new Vector2(300, 1250), font);
            Three1 = new Font("3", new Vector2(300, 1359), font);
            Four = new Font("4", new Vector2(300, 1450), font);
            Five = new Font("5", new Vector2(300, 1550), font);
            Six = new Font("6", new Vector2(300, 1500), font);
            Seven = new Font("7", new Vector2(300, 1750), font);
            Eight = new Font("8", new Vector2(300, 2000), font);
            Nine = new Font("9", new Vector2(300, 2250), font);
            Ten = new Font("10", new Vector2(300, 2500), font);

            FirstScore = new Font("0", new Vector2(900, 1150), font);
            SecondScore = new Font("0", new Vector2(900, 1250), font);
            ThirdScore = new Font("0", new Vector2(900, 1350), font);
            FourthScore = new Font("0", new Vector2(900, 1450), font);
            FifthScore = new Font("0", new Vector2(900, 1550), font);

            FirstName = new Font("username", new Vector2(400, 1150), font);
            SecondName = new Font("username", new Vector2(400, 1250), font);
            ThirdName = new Font("username", new Vector2(400, 1350), font);
            FourthName = new Font("username", new Vector2(400, 1450), font);
            FifthName = new Font("username", new Vector2(400, 1550), font);

            Pause = new Font("PAUSED", new Vector2(550, 950), font);

            Resume = new Font("RESUME", new Vector2(250, 1100), font);
            Restart = new Font("RESTART", new Vector2(250, 1250), font);
            Pause_Settings = new Font("SETTINGS", new Vector2(250, 1400), font);
            Quit = new Font("RETURN TO MENU", new Vector2(250, 1550), font);

            LevelFinished = new Font("LEVEL FINISHED", new Vector2(400, 950), font);
            Menu = new Font("MENU", new Vector2(300, 1500), font);
            NextLevel = new Font("NEXT LEVEL", new Vector2(600, 1500), font);
            Progress = new Font("Progress", new Vector2(350, 1200), font);
            LevelIndex = new LevelProg("0", new Vector2(700, 1200), font);

            LdbFirst = new Font("A", new Vector2(MyGameMain.originalX * 1 / 3 - 50 / MyGameMain.scaleX, MyGameMain.originalY / 2), font);
            LdbSecond = new Font("A", new Vector2(MyGameMain.originalX * 2 / 3 - 225 / MyGameMain.scaleX, MyGameMain.originalY / 2), font);
            LdbThird = new Font("A", new Vector2(MyGameMain.originalX * 3 / 3 - 400 / MyGameMain.scaleX, MyGameMain.originalY / 2), font);

            ResumeButton = new ButtonController(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black)
            {
                Position = new Vector2(950, 1100),
            };

            RestartButton = new LevelSelector(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.first)
            { //todo: logika za restart
                Position = new Vector2(950, 1250),
            };

            PauseSettingsButton = new SettingsButton(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black)
            {
                Position = new Vector2(950, 1400),

                //Position = Vector2.Divide(new Vector2(950, 1400), MyGameMain.scale),

            };

            NextLevelButton = new NextLevelButton(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black)
            {
                Position = new Vector2(1000, 200),
            };


            QuitButton = new MainMenuButton(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black)
            {
                Position = new Vector2(950, 1550),
            };

            QuitButton2 = new MainMenuButton(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black)
            {
                Position = new Vector2(350 / MyGameMain.scaleX, 1650 / MyGameMain.scaleY),
            };


            Name = new Font("ENTER NAME", new Vector2(400 / MyGameMain.scaleX, 950 / MyGameMain.scaleY), font);

            if (MyGameMain.lbe != null)
            {
                Up1 = new LetterUp(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.First, MyGameMain.lbe.FirstInd, LdbFirst)
                {
                    Position = new Vector2(MyGameMain.originalX * 1 / 3 - 50 / MyGameMain.scaleX, MyGameMain.originalY / 2 - 200 / MyGameMain.scaleY)
                };

                Up2 = new LetterUp(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.Second, MyGameMain.lbe.SecondInd, LdbSecond)
                {
                    Position = new Vector2(MyGameMain.originalX * 2 / 3 - 225 / MyGameMain.scaleX, MyGameMain.originalY / 2 - 200 / MyGameMain.scaleY)
                };

                Up3 = new LetterUp(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.Third, MyGameMain.lbe.ThirdInd, LdbThird)
                {
                    Position = new Vector2(MyGameMain.originalX * 3 / 3 - 400 / MyGameMain.scaleX, MyGameMain.originalY / 2 - 200 / MyGameMain.scaleY)
                };

                Down1 = new LetterDown(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.First, MyGameMain.lbe.FirstInd, LdbFirst)
                {
                    Position = new Vector2(MyGameMain.originalX * 1 / 3 - 50 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 200 / MyGameMain.scaleY)
                };

                Down2 = new LetterDown(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.Second, MyGameMain.lbe.SecondInd, LdbSecond)
                {
                    Position = new Vector2(MyGameMain.originalX * 2 / 3 - 225 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 200 / MyGameMain.scaleY)
                };

                Down3 = new LetterDown(UI, new Rectangle(1420, 0, 125, 125), font, Color.Black, MyGameMain.lbe.Third, MyGameMain.lbe.ThirdInd, LdbThird)
                {
                    Position = new Vector2(MyGameMain.originalX * 3 / 3 - 400 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 200 / MyGameMain.scaleY)
                };

                FinishLb = new Leaderboardfinish(UI, new Rectangle(413, 0, 124, 126), font, Color.Black)
                {
                    Position = new Vector2(MyGameMain.originalX * 1 / 2 - 400 / MyGameMain.scaleX, MyGameMain.originalY / 2 + 400 / MyGameMain.scaleY)
                };
            }

            fRead = assets.Open("exp1.png");

            Texture2D explosionTexture = Texture2D.FromStream(_graphicsDevice, fRead);
            explosion = new AnimatedSprite(TimeSpan.FromSeconds(1));
            explosion.loop = true;
            for (int i = 0; i < 9; i++)
            {
                int row = i % 3;
                int column = i / 3;
                sprite Sprite = new sprite(explosionTexture, new Rectangle(column * 223, row * 223, 223, 223), new Vector2(500, 1100));

                AnimatedSpriteFrame frame = new AnimatedSpriteFrame(Sprite, explosion.duration * (float)i / 9);
                explosion.AddFrame(frame);
            }

            fRead = assets.Open("enginePlume.png");

            Texture2D engineOn = Texture2D.FromStream(_graphicsDevice, fRead);
            engine = new AnimatedSprite(TimeSpan.FromSeconds(3));
            engine.loop = true;
            for (int i = 0; i < 5; i++)
            {
                int row = i % 2;
                int column = i / 3;
                sprite Sprite = new sprite(engineOn, new Rectangle(column * 18, row * 32, 18, 32), new Vector2(500, 1100));

                AnimatedSpriteFrame frame = new AnimatedSpriteFrame(Sprite, engine.duration * (float)i / 5);
                engine.AddFrame(frame);
            }

            UpdateScores();

            fRead.Close();
        }

        public void UpdateScores()
        {
            for (int i = 0; i < _leaderboard.leaderboard.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            FirstScore = new Font(_leaderboard.leaderboard.ElementAt(i).Value.ToString(), new Vector2(900, 1150), font);
                            FirstName = new Font(_leaderboard.leaderboard.ElementAt(i).Key, new Vector2(400, 1150), font);
                            break;
                        }

                    case 1:
                        {
                            SecondScore = new Font(_leaderboard.leaderboard.ElementAt(i).Value.ToString(), new Vector2(900, 1250), font);
                            SecondName = new Font(_leaderboard.leaderboard.ElementAt(i).Key, new Vector2(400, 1250), font);
                            break;
                        }

                    case 2:
                        {
                            ThirdScore = new Font(_leaderboard.leaderboard.ElementAt(i).Value.ToString(), new Vector2(900, 1350), font);
                            ThirdName = new Font(_leaderboard.leaderboard.ElementAt(i).Key, new Vector2(400, 1350), font);
                            break;
                        }

                    case 3:
                        {
                            FourthScore = new Font(_leaderboard.leaderboard.ElementAt(i).Value.ToString(), new Vector2(900, 1450), font);
                            FourthName = new Font(_leaderboard.leaderboard.ElementAt(i).Key, new Vector2(400, 1450), font);
                            break;
                        }

                    case 4:
                        {
                            FifthScore = new Font(_leaderboard.leaderboard.ElementAt(i).Value.ToString(), new Vector2(900, 1550), font);
                            FifthName = new Font(_leaderboard.leaderboard.ElementAt(i).Key, new Vector2(400, 1550), font);
                            break;
                        }
                }

            }

        }
    }
}

