using Android.Content.Res;
using Android.OS;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using SpaceAndroid;

public class ReadAsset : Activity1 {
    public Texture2D background1;
    GraphicsDevice _graphicsDevice;

    public ReadAsset(GraphicsDevice gd) {
        _graphicsDevice = gd;
    }

    public void Test() {
        string content;
        AssetManager assets = this.Assets;
        using (StreamReader sr = new StreamReader(assets.Open("black.png")))
        {
            content = sr.ReadToEnd();
        }
    }

    protected override void OnCreate(Bundle bundle) {
        base.OnCreate(bundle);
        FileStream input = (FileStream)Assets.Open("black.png");
        background1 = Texture2D.FromStream(_graphicsDevice, input);

    }
}