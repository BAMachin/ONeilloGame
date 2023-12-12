using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ONeilloGame.GameDataJson;
using System.Text.RegularExpressions;

namespace ONeilloGame
{
    public partial class LoadGame : Form
    {
        private GameDataJson gameDataJson;
        public GameBoardControl gameBoardControl;
        public ONeilloGame ONeilloGame { get; }

        public LoadGame()
        {
            InitializeComponent();

            btnCancel.Click += btnCancel_Click;
            btnLoadGame.Click += btnLoadGame_Click;

            for (int i = 1; i <= 5; i++)
            {
                comboBoxGameSlotChoiceLoading.Items.Add($"Game Slot {i}");
            }

            // Create an instance of GameBoardControl
            gameBoardControl = new GameBoardControl(this);

            // Now you can initialize gameDataJson with the instantiated gameBoardControl
            gameDataJson = new GameDataJson(gameBoardControl, ONeilloGame);
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\ONeilloGame\\game_data.json";

            // Check if an item is selected in the ComboBox
            if (comboBoxGameSlotChoiceLoading.SelectedItem != null)
            {
                // Get the selected game slot
                string selectedGameSlotString = comboBoxGameSlotChoiceLoading.SelectedItem.ToString();

                // Use regular expression to extract numeric part
                Match match = Regex.Match(selectedGameSlotString, @"\d+");

                if (match.Success)
                {
                    int selectedGameSlot = int.Parse(match.Value);
                    int adjustedGameSlot = selectedGameSlot - 1;

                    //MessageBox.Show($"You have chosen {selectedGameSlotString}");
                    //MessageBox.Show($"Adjusted Game Slot: {adjustedGameSlot}");

                    GameDataJson.Composite compositeToRetrieve = gameDataJson.LoadAllGameData(filePath);

                    //MessageBox.Show("data returned...");

                    if (compositeToRetrieve != null && compositeToRetrieve.Data != null)
                    {
                        foreach (var saveSpaceData in compositeToRetrieve.Data)
                        {
                            string saveSpaceFromJson = saveSpaceData.SaveSpace;

                            if (saveSpaceFromJson == adjustedGameSlot.ToString())
                            {
                                // Found the matching SaveSpace based on selectedGameSlot
                                // Use saveSpaceItem as needed
                                MessageBox.Show($"Found matching SaveSpace for user selection: {selectedGameSlotString}");

                                string gameName = saveSpaceData.GameName;
                                var playerData = saveSpaceData.PlayerDataAndCounters;
                                string player1Name = playerData.Player1Name;
                                string player2Name = playerData.Player2Name;
                                int blackCounters = playerData.BlackCounters;
                                int whiteCounters = playerData.WhiteCounters;

                                int[,] gameBoardArrayFromData = saveSpaceData.GameBoardArray;

                                MessageBox.Show($"Game Name: {gameName}, players: {player1Name} & {player2Name}, counters: " +
                                    $"{blackCounters} & {whiteCounters}");

                                //Now using the data returned to update the board to that state:

                                gameBoardControl.ResetBoardBasedOnSavedData(player1Name, player2Name, blackCounters, whiteCounters, gameBoardArrayFromData);

                                break; 
                                //Exit once the loop has been found 
                            }
                            else
                            {
                                MessageBox.Show("Invalid game slot format.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid game slot format.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
