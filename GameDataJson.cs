using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ONeilloGame.Properties;

namespace ONeilloGame
{
    public class GameDataJson
    {
        private const string FilePath = "game_data.json";

        public class Composite
        {
            //public Settings Settings { get; set; }
            public Gdata Gdata { get; set; }
            public IDictionary<string, Gdata> Data { get; set; }
        }

        public class Gdata
        {
            public int[,] GameBoardArray { get; set; }
        }

        public class PlayerDataAndCounters
        {
            public string Player1Name { get; set; }
            public string Player2Name { get; set; }
            public int BlackCounters { get; set; }
            public int WhiteCounters { get; set; }
        }

        public void SaveGameData(Composite compositeToSerialize, string filePath = FilePath)
        {
            string stringComposite = JsonConvert.SerializeObject(compositeToSerialize, Formatting.Indented);
            File.WriteAllText(filePath, stringComposite);
        }

        public Composite LoadGameData(string filePath = FilePath)
        {
            if (!File.Exists(filePath))
            {
                // Handle the case where the file doesn't exist
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string stringComposite = File.ReadAllText(filePath);
            Composite deserializedComposite = JsonConvert.DeserializeObject<Composite>(stringComposite);
            return deserializedComposite;
        }
    }
}
