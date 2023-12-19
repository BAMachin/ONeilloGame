using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using static ONeilloGame.GameDataJson;
using System.Text.RegularExpressions;

namespace ONeilloGame
{
    public partial class LoadGame : Form
    {
        public GameDataJson gameDataJson;

        public GameBoardControl gameBoardControl;
        public ONeilloGame ONeilloGame { get; set; }

        public LoadGame(ref GameBoardControl gbc)
        {
            InitializeComponent();

            for (int i = 1; i <= 5; i++)
            {
                comboBoxGameSlotChoiceLoading.Items.Add($"Game Slot {i}");
            }

            //gameBoardControl = new GameBoardControl(this);
            gameDataJson = new GameDataJson(gameBoardControl, ONeilloGame);
            
            this.gameBoardControl = gbc;

            btnCancel.Click += btnCancel_Click;
            btnLoadGame.Click += btnLoadGame_Click;

        }
       private void btnLoadGame_Click(object sender, EventArgs e)
       {
            string filePath = "C:\\ONeilloGame\\game_data.json";

            if (comboBoxGameSlotChoiceLoading.SelectedItem != null)
            {
                string selectedGameSlotString = comboBoxGameSlotChoiceLoading.SelectedItem.ToString();

                // Use regular expression to extract numeric part
                Match match = Regex.Match(selectedGameSlotString, @"\d+");

                if (match.Success)
                {
                    int selectedGameSlot = int.Parse(match.Value);
                    int adjustedGameSlot = selectedGameSlot - 1;

                    GameDataJson.Composite compositeToRetrieve = gameDataJson.LoadAllGameData(filePath);

                    if (compositeToRetrieve != null && compositeToRetrieve.Data != null)
                    {
                        foreach (var saveSpaceData in compositeToRetrieve.Data)
                        {
                            string saveSpaceFromJson = saveSpaceData.SaveSpace;

                            if (saveSpaceFromJson == adjustedGameSlot.ToString())
                            {
                                // Found the matching SaveSpace based on selectedGameSlot
                                //MessageBox.Show($"Found matching SaveSpace for user selection: {selectedGameSlotString}");

                                string gameName = saveSpaceData.GameName;
                                var playerData = saveSpaceData.PlayerDataAndCounters;
                                string player1Name = playerData.Player1Name;
                                string player2Name = playerData.Player2Name;
                                int blackCounters = playerData.BlackCounters;
                                int whiteCounters = playerData.WhiteCounters;

                                int[,] gameBoardArrayFromData = saveSpaceData.GameBoardArray;

                                //MessageBox.Show($"Game Name: {gameName}, Players: {player1Name} & {player2Name}, ounters: " +
                                    //$"{blackCounters} & {whiteCounters}");

                                gameBoardControl.ResetBoardBasedOnSavedData(player1Name, player2Name, blackCounters, whiteCounters, gameBoardArrayFromData);

                                break; 
                            }
                            else
                            {
                               // MessageBox.Show("Please choose another game slot.");
                            }
                        }
                    }
                }
                
                this.Close(); 
            }
       }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
