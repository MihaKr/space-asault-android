using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using SpaceAndroid;
using Android.Content.Res;

namespace SpaceAndroid;

public class MyGameMain : Game
{
    public static int _width;
    public static int _height;

    //public static int _width = 800;
    //public static int _height = 800;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private static GraphicsDevice Gd;
    private static MyGameMain X;

    public static scene _selected;

    public static scene _currentScene;
    public static scene _nextScene;
    public static scene _prevScene;

    public static float w;
    public static float h;

    private EnemyController _enemyController;

    public static Random Random;

    public static LoadContent _content;

    public static Gameplay _gameplay;
    public static Renderer _renderer;
    public static LeaderBoardManager _leaderboard;

    public static menu mainMenu;
    public static SettingsMenu Settings;
    public static LevelSelect LevelSelect;
    public static LeaderBoard LeaderBoard;

    public static DemoLevel2 two;
    public static DemoLevel first;
    public static DemoLevel third;
    public static DemoLevel fourth;
    public static DemoLevel fifth;
    public static DemoLevel sixth;
    public static DemoLevel2 seventh;
    public static DemoLevel eight;
    public static DemoLevel ninth;
    public static DemoLevel tenth;
    public static DemoLevel eleventh;
    public static DemoLevel2 twelth;

    public static Endless Endless;

    public static Boss1 Boss1;
    public static Boss2 Boss2;
    public static Boss3 Boss3;

    public static LeaderboardEntry lbe;

    public static Vector2 mouseScale;

    public static Vector3 ScaleV;
    public static Matrix ScaleMatrix;

    public static Vector2 PosScale;

    public static float scale;

    public static float originalX = 1080;
    public static float originalY = 2400;

    public static float scaleX;
    public static float scaleY;

    public static AssetManager assets;

    public MyGameMain(AssetManager a)
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        assets = a;
    }

    protected override void Initialize()
    {
        //window size
        /*
        _graphics.PreferredBackBufferWidth = _width;
        _graphics.PreferredBackBufferHeight = _height;
        */


        Viewport viewport = GraphicsDevice.Viewport;
        scaleX = 1; // baseScreenWidth is the width of the game screen
        scaleY = 1; // baseScreenHeight is the height of the game screen
        //_graphics.PreferredBackBufferWidth = 800;
        //_graphics.PreferredBackBufferHeight = 600;

        TouchPanel.DisplayHeight = _graphics.PreferredBackBufferHeight;
        TouchPanel.DisplayWidth = _graphics.PreferredBackBufferWidth;
        _graphics.ApplyChanges();

        IsFixedTimeStep = true;
        TargetElapsedTime = System.TimeSpan.FromSeconds(1d / 60);

        Random = new Random(0);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Gd = GraphicsDevice;
        X = this;
        float widthScale = _width / (float)1284;
        float heightScale = _height / (float)2778;

        PosScale = new Vector2((float)1284 / _width, (float)2778 / _height);

        scale = Math.Min(widthScale, heightScale);

        ScaleMatrix = Matrix.CreateScale(scale);

        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _leaderboard = new LeaderBoardManager();

        _content = new LoadContent(GraphicsDevice, _leaderboard);
        _content.load(assets);

        first = new DemoLevel(_content, GraphicsDevice, this);
        two = new DemoLevel2(_content, GraphicsDevice, this);
        third = new DemoLevel(_content, GraphicsDevice, this);
        fourth = new DemoLevel(_content, GraphicsDevice, this);

        fifth = new DemoLevel(_content, GraphicsDevice, this);
        sixth = new DemoLevel(_content, GraphicsDevice, this);
        seventh = new DemoLevel2(_content, GraphicsDevice, this);
        eight = new DemoLevel(_content, GraphicsDevice, this);

        ninth = new DemoLevel(_content, GraphicsDevice, this);
        tenth = new DemoLevel(_content, GraphicsDevice, this);
        eleventh = new DemoLevel(_content, GraphicsDevice, this);
        twelth = new DemoLevel2(_content, GraphicsDevice, this);

        mainMenu = new menu(_content, GraphicsDevice, this);
        _content.load(assets);
        LeaderBoard = new LeaderBoard(_content, GraphicsDevice, this);
        Settings = new SettingsMenu(_content, GraphicsDevice, this);
        Boss1 = new Boss1(_content, GraphicsDevice, this);
        Boss2 = new Boss2(_content, GraphicsDevice, this);
        Boss3 = new Boss3(_content, GraphicsDevice, this);

        Endless = new Endless(_content, GraphicsDevice, this);

        LevelSelect = new LevelSelect(_content, GraphicsDevice, this);
        lbe = new LeaderboardEntry(_content, GraphicsDevice, this);
        _content.load(assets);
        lbe = new LeaderboardEntry(_content, GraphicsDevice, this);

        _currentScene = mainMenu;

        w = _width / 128;
        h = _height / 128;

        _currentScene.Background = _content.Background;

        _gameplay = new Gameplay(_currentScene, _currentScene._enemyController, _currentScene._PowerUpController, _leaderboard);
        _renderer = new Renderer(_currentScene, w, h);

        _gameplay.AddLevel(first);
        _gameplay.AddLevel(two);
        _gameplay.AddLevel(third);
        _gameplay.AddLevel(fourth);
        _gameplay.AddLevel(Boss1);

        _gameplay.AddLevel(fifth);
        _gameplay.AddLevel(sixth);
        _gameplay.AddLevel(seventh);
        _gameplay.AddLevel(eight);
        _gameplay.AddLevel(Boss2);

        _gameplay.AddLevel(ninth);
        _gameplay.AddLevel(tenth);
        _gameplay.AddLevel(eleventh);
        _gameplay.AddLevel(twelth);
        _gameplay.AddLevel(Boss3);

        //_content.BackgroundSong.Play();
    }

    protected override void Update(GameTime gameTime)
    {
        if (_nextScene != null)
        {
            _prevScene = _currentScene;
            _currentScene = _nextScene;
            _gameplay.ChangeScene(_nextScene);
            _renderer.ChangeScene(_nextScene);
            _gameplay.LevelEnd = false;
            _nextScene = null;
        }

        _gameplay.Update(gameTime);

        base.Update(gameTime);
    }

    public static void Reset()
    {
        first = new DemoLevel(_content, Gd, X);
        two = new DemoLevel2(_content, Gd, X);
        third = new DemoLevel(_content, Gd, X);
        fourth = new DemoLevel(_content, Gd, X);

        fifth = new DemoLevel(_content, Gd, X);
        sixth = new DemoLevel(_content, Gd, X);
        seventh = new DemoLevel2(_content, Gd, X);
        eight = new DemoLevel(_content, Gd, X);

        ninth = new DemoLevel(_content, Gd, X);
        tenth = new DemoLevel(_content, Gd, X);
        eleventh = new DemoLevel(_content, Gd, X);
        twelth = new DemoLevel2(_content, Gd, X);

        mainMenu = new menu(_content, Gd, X);
        LeaderBoard = new LeaderBoard(_content, Gd, X);
        Settings = new SettingsMenu(_content, Gd, X);
        Boss1 = new Boss1(_content, Gd, X);
        Boss2 = new Boss2(_content, Gd, X);
        Boss3 = new Boss3(_content, Gd, X);
        LevelSelect = new LevelSelect(_content, Gd, X);
        lbe = new LeaderboardEntry(_content, Gd, X);
        lbe = new LeaderboardEntry(_content, Gd, X);
        Endless = new Endless(_content, Gd, X);


        _currentScene = mainMenu;

        w = _width / 128;
        h = _height / 128;

        _currentScene.Background = _content.Background;

        _gameplay = new Gameplay(_currentScene, _currentScene._enemyController, _currentScene._PowerUpController, _leaderboard);
        _renderer = new Renderer(_currentScene, w, h);

        _gameplay.AddLevel(first);
        _gameplay.AddLevel(two);
        _gameplay.AddLevel(third);
        _gameplay.AddLevel(fourth);
        _gameplay.AddLevel(Boss1);
        _gameplay.AddLevel(fifth);
        _gameplay.AddLevel(sixth);
        _gameplay.AddLevel(seventh);
        _gameplay.AddLevel(eight);
        _gameplay.AddLevel(Boss2);
        _gameplay.AddLevel(ninth);
        _gameplay.AddLevel(tenth);
        _gameplay.AddLevel(eleventh);
        _gameplay.AddLevel(twelth);
        _gameplay.AddLevel(Boss3);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, ScaleMatrix);

        //_spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null,null, null);

        _renderer.Draw(_spriteBatch, gameTime);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}