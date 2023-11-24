using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using ONeilloGame.Properties;

namespace ONeilloGame
{
    internal class GameDataJson
    {
        public class Composite
        {
            public Settings settings { get; set; }
            public Gdata gdata { get; set; }
            public IDictionary<string, Gdata> data { get; set; }
        }

        internal class Gdata
        {
            public int[,] gameBoardArray { get; set; }

        }

        internal class PlayerDataAndCounters
        {
            public string player1Name { get; set; }
            public string player2Name { get; set; } 

            public int blackCounters { get; set; }
            public int whiteCounters { get; set; }

        }

        public void SaveGameData()
        {
            Composite compositeToSerialize = new Composite();
            // Initialize your composite data here

            string stringComposite = JsonConvert.SerializeObject(compositeToSerialize, Formatting.Indented);
            File.WriteAllText("example.json", stringComposite);
        }

        public Composite LoadGameData()
        {
            string stringComposite = File.ReadAllText("example.json");
            Composite deserializedComposite = JsonConvert.DeserializeObject<Composite>(stringComposite);
            return deserializedComposite;
        }
    }
}
