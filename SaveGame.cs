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

            SelectedSlot = 0; // Set a default slot index

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
                MessageBox.Show("Please enter a valid game name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxGameSlotChoice.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a game slot.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the current game data
            GameDataJson.Composite compositeToSave = gameDataJson.DeserializedComposite;

            // Save the game data to the selected slot
            string selectedSlotName = $"Slot {comboBoxGameSlotChoice.SelectedIndex + 1}";
            compositeToSave.Data[selectedSlotName] = compositeToSave.Gdata;

            // Update the game name (assuming it's a property in Gdata)
            compositeToSave.Gdata.GameName = txtBoxGameName.Text;

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
