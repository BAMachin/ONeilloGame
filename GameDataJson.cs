using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ONeilloGame.Properties;

namespace ONeilloGame
{
    public class GameDataJson
    {
        private const string FilePath = "C:\\ONeilloGame\\game_data.json";

        public Composite deserializedComposite;

        private GameBoardControl gameBoardControlInstance;
        private ONeilloGame ONeilloGameInstance;

        public GameDataJson(GameBoardControl gameBoardControl, ONeilloGame ONeilloGame)
        {
            // Assuming gameBoardControl is the instance of GameBoardControl you want to work with
            gameBoardControlInstance = gameBoardControl;
            ONeilloGameInstance = ONeilloGame;
        }

        public Composite DeserializedComposite
        {
            get
            {
                // Access GameBoardArray through the GameBoardControl instance
                int[,] gameBoardArray = gameBoardControlInstance.GameBoardArray;


                return new Composite
                {
                    Gdata = new Gdata
                    {
                        GameBoardArray = gameBoardArray,
                        PlayerDataAndCounters = ONeilloGameInstance.GetPlayerData()//GetPlayerData gets player names and number of counters each
                    },
                    Data = new Dictionary<string, Gdata>()
                };
            }
        }

        public class Composite
        {
            //public Settings Settings { get; set; }
            public Gdata Gdata { get; set; }
            public IDictionary<string, Gdata> Data { get; set; }
        }

        public class Gdata
        {
            public int[,] GameBoardArray { get; set; }
            public PlayerDataAndCounters PlayerDataAndCounters { get; set; }
            public string GameName { get; set; }
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
            // Create the directory if it doesn't exist
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the game data to the file
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
            deserializedComposite = JsonConvert.DeserializeObject<Composite>(stringComposite);
            return deserializedComposite;
        }
    }
}
