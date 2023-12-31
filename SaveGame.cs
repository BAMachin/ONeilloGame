﻿using ONeilloGame.Properties;
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
        public string Settings { get; private set; }

        internal SaveGame(GameDataJson gameDataJson)
        {
            InitializeComponent();
            this.gameDataJson = gameDataJson;

            GameName = $"ONellio Game - {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

            for (int i = 1; i <= 5; i++)
            {
                comboBoxGameSlotChoice.Items.Add($"Game Slot: {i}");
            }

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
            else
            {
                // Set the SelectedSlot property based on the selected index
                SelectedSlot = comboBoxGameSlotChoice.SelectedIndex;
            }

            // Get the current game data
            GameDataJson.Composite compositeToSave = gameDataJson.DeserializedComposite;

            // Find the index of the selected slot
            int selectedIndex = SelectedSlot; // Use the SelectedSlot property here
            string selectIndexString = selectedIndex.ToString();
            compositeToSave.Gdata.SaveSpace = selectIndexString;

            // Check if the index is within the range of existing slots
            if (selectedIndex >= 0 && selectedIndex < compositeToSave.Data.Count)
            {
                // Check if the user wants to override the existing data
                DialogResult result = MessageBox.Show("Do you want to override the existing data for this slot?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the game data for the selected slot
                    compositeToSave.Data[selectedIndex].GameName = txtBoxGameName.Text;
                    compositeToSave.Data[selectedIndex].GameBoardArray = compositeToSave.Gdata.GameBoardArray;
                    compositeToSave.Data[selectedIndex].PlayerDataAndCounters = compositeToSave.Gdata.PlayerDataAndCounters;
                }
            }
            else
            {
                // Add a new game data entry for the selected slot
                compositeToSave.Data.Add(new GameDataJson.Gdata
                {
                    GameName = txtBoxGameName.Text,
                    GameBoardArray = compositeToSave.Gdata.GameBoardArray,
                    PlayerDataAndCounters = compositeToSave.Gdata.PlayerDataAndCounters,
                    SaveSpace = selectIndexString
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
