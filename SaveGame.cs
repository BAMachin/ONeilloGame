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

        internal SaveGame(GameDataJson gameDataJson)
        {
            InitializeComponent();
            this.gameDataJson = gameDataJson;

            // Set default values if needed
            GameName = $"ONellio Game - {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            SelectedSlot = 0; // Set a default slot index
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtBoxGameName.Text))
            {
                MessageBox.Show("Please enter a valid game name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxGameSlotChoice.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a game slot.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set properties and close the form
            GameDataJson.Composite compositeToSave = new GameDataJson.Composite
            {
                //Settings = new Settings(),
                Gdata = new GameDataJson.Gdata(),
                Data = new Dictionary<string, GameDataJson.Gdata>()
            };

            // Save the game data
            gameDataJson.SaveGameData(compositeToSave);

            DialogResult = DialogResult.OK;
            Close();
        }

        // Event handler for the Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
