using ONeilloGame.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ONeilloGame
{
    internal partial class SaveGame : Form
    {
        private readonly GameDataJson gameDataJson;

        public string GameName { get; private set; }
        public int SelectedSlot { get; private set; }

        //public string Settings { get; private set; }

        internal SaveGame(GameDataJson gameDataJson)
        {
            InitializeComponent();
            this.gameDataJson = gameDataJson;

            GameName = $"ONellio Game - {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

            // Populate the ComboBox with available slots
            for (int i = 1; i <= 5; i++)
            {
                comboBoxGameSlotChoice.Items.Add($"Game Slot: {i}");
            }

            //SelectedSlot = 0; // Set a default slot index

            // Display default values in UI
            txtBoxGameName.Text = GameName;
            comboBoxGameSlotChoice.SelectedIndex = SelectedSlot;
        }

        public void btnSaveGame_Click(object sender, EventArgs e)
        {
            SavingLogic();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void SavingLogic()
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtBoxGameName.Text))
            {
                //default name
                GameName = $"ONellio Game - {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            }

            if (comboBoxGameSlotChoice.SelectedIndex < 0)
            {
                //default save slot
                SelectedSlot = 0;
            }

            // Get the current game data
            GameDataJson.Composite compositeToSave = gameDataJson.DeserializedComposite;

            // Find the index of the selected slot
            int selectedIndex = comboBoxGameSlotChoice.SelectedIndex;
            string selectIndexString = selectedIndex.ToString(); 
            compositeToSave.Gdata.SaveSpace = selectIndexString; 

            // Check if the index is within the range of existing slots
            if (selectedIndex >= 0 && selectedIndex < compositeToSave.Data.Count)
            {
                // Update the game data for the selected slot
                compositeToSave.Data[selectedIndex].GameName = txtBoxGameName.Text;
                compositeToSave.Data[selectedIndex].GameBoardArray = compositeToSave.Gdata.GameBoardArray;
                compositeToSave.Data[selectedIndex].PlayerDataAndCounters = compositeToSave.Gdata.PlayerDataAndCounters;
            }
            else
            {
                // Add a new game data entry for the selected slot
                compositeToSave.Data.Add(new GameDataJson.Gdata
                {
                    GameName = txtBoxGameName.Text,
                    GameBoardArray = compositeToSave.Gdata.GameBoardArray,
                    PlayerDataAndCounters = compositeToSave.Gdata.PlayerDataAndCounters, 
                    SaveSpace = compositeToSave.Gdata.SaveSpace
                });
            }

            // Save the updated data
            gameDataJson.SaveGameData(compositeToSave);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
