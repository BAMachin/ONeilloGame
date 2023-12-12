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
            gameBoardControlInstance = gameBoardControl;
            ONeilloGameInstance = ONeilloGame;
        }

        public Composite DeserializedComposite
        {
            get
            {
                int[,] gameBoardArray = gameBoardControlInstance.GameBoardArray;

                return new Composite
                {
                    Gdata = new Gdata
                    {
                        GameBoardArray = gameBoardArray,
                        PlayerDataAndCounters = ONeilloGameInstance.GetPlayerData(),
                        GameName = "ONellio Game - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    }
                };
            }
        }

        public class Composite
        {
            public Gdata Gdata { get; set; }
            public List<Gdata> Data { get; set; } = new List<Gdata>(); // Initialize as an empty list
        }


        public class Gdata
        {
            public int[,] GameBoardArray { get; set; }
            public PlayerDataAndCounters PlayerDataAndCounters { get; set; }
            public string GameName { get; set; }
            public string SaveSpace { get; set; }
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
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);

                string stringComposite = JsonConvert.SerializeObject(compositeToSerialize, Formatting.Indented);
                File.WriteAllText(filePath, stringComposite);

            }
            else
            {
                string dataAlreadyInFileString = File.ReadAllText(filePath);
                var existingComposite = JsonConvert.DeserializeObject<Composite>(dataAlreadyInFileString);

                // Add the new data to the existing data
                existingComposite.Data.Add(compositeToSerialize.Gdata);

                // Serialize the combined data
                string updatedData = JsonConvert.SerializeObject(existingComposite, Formatting.Indented);

                // Write the updated data back to the file
                File.WriteAllText(filePath, updatedData);
            }
        }

        public Composite LoadAllGameData(string filePath = FilePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string stringComposite = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Composite>(stringComposite);
        }
    }
}
