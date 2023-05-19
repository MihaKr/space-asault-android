using System;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Android.Icu.Number;
using Java.Util.Logging;
using Microsoft.Xna.Framework;

namespace SpaceAndroid {
    public class LeaderBoardManager {
        public Dictionary<string, int> leaderboard;

        public LeaderBoardManager() {
            leaderboard = new Dictionary<string, int>();
            LoadLeaderboard();
        }

        public void Add(string name, int score) {
            leaderboard[name] = score/2;
            var sortedDict = from entry in leaderboard orderby entry.Value descending select entry;
            leaderboard = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);

            SaveLeaderboard();
            MyGameMain.LeaderBoard.ResetScore();
        }

        void SaveLeaderboard()  {
            String content;
            string json = JsonSerializer.Serialize(leaderboard);

            //File.WriteAllText("/Users/mihakristofelc/NewEngine/assets/leaderboard.json", string.Empty);
            //File.WriteAllText("/Users/mihakristofelc/NewEngine/assets/leaderboard.json", json);

            using (StreamReader sr = new StreamReader(MyGameMain.assets.Open("leaderboard.json")))
            {
                content = sr.ReadToEnd();
            }

            // get a writable file path
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "leaderboard.json");

            // write the data to the writable path - now you can read and write it
            File.WriteAllText(filename, content);
        }

        void LoadLeaderboard() {
            Stream fRead = MyGameMain.assets.Open("leaderboard.json");

            StreamReader reader = new StreamReader(fRead);
            string json = reader.ReadToEnd();

            //string json = File.ReadAllText("/Users/mihakristofelc/NewEngine/assets/leaderboard.json");
            leaderboard = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
        }
    }
}