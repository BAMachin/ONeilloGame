using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ONeilloGame.GameDataJson;


//TO DO:
//Check code logic - validate moves

//JSON File settings 
//new game
//if there are no saved games - the load button should be disabled
//how to make it load the slots 
//how to make it update the file rather than rewrite
//retrive game


//final touches....
//to make board game square rather than rectangular
//check all variable names
//check all comment locations and if required

namespace ONeilloGame
{
    public partial class ONeilloGame : Form
    {
        private GameBoardControl gameBoardControl;

        private SpeechSynthesizer synth;

        private PlayerDataAndCounters PlayerDataAndCounters = new PlayerDataAndCounters();

        private GameDataJson gameDataJson;

        public ONeilloGame()
        {
            InitializeComponent();

            gameBoardControl = new GameBoardControl(this);
            this.Controls.Add(gameBoardControl);
            synth = new SpeechSynthesizer();

            gameBoardControl.PlayerTurnChanged += GameBoardControl_PlayerTurnChanged;
            gameBoardControl.CountersUpdated += GameBoardControl_CountersUpdated;

            informationPanelToolStripMenuItem.Checked = true;
            speakToolStripMenuItem.Checked = false;

            gameDataJson = new GameDataJson(gameBoardControl, this);
        }

        private int latestBlackCounters;
        private int latestWhiteCounters;

        private void GameBoardControl_RowColValueSent(int row, int col)
        {
            ProvideTilePlacement(row, col);
        }
        public void ShowPlayerOneTurnLabel()
        {
            bottomlabel1Player1Turn.Show();
            bottomlabel2PlayerTwoTurn.Hide();
        }
        public void ShowPlayerTwoTurnLabel()
        {
            bottomlabel2PlayerTwoTurn.Show();
            bottomlabel1Player1Turn.Hide();
        }
        private void GameBoardControl_PlayerTurnChanged(int playerColor)
        {
            if (playerColor == 0)
            {
                ShowPlayerOneTurnLabel();
            }
            else if (playerColor == 1)
            {
                ShowPlayerTwoTurnLabel();
            }
        }
        private void GameBoardControl_CountersUpdated(int blackCounters, int whiteCounters)
        {
            // Update counter labels
            bottomplayer1Counter.Text = blackCounters.ToString();
            bottomplayer2Counter.Text = whiteCounters.ToString();

            bottomplayer1Counter.Refresh();
            bottomplayer2Counter.Refresh();

            // Store the latest values
            latestBlackCounters = blackCounters;
            latestWhiteCounters = whiteCounters;

        }

        public PlayerDataAndCounters GetPlayerData()
        {
            //text controls
            string player1Name = bottomtextBoxPlayer1.Text;
            string player2Name = bottomtextBoxPlayer2.Text;

            // Create and return a PlayerDataAndCounters object
            return new PlayerDataAndCounters
            {
                Player1Name = player1Name,
                Player2Name = player2Name,
                BlackCounters = latestBlackCounters,
                WhiteCounters = latestWhiteCounters
            };
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the AboutONeilloGame form
            AboutONeilloGame aboutForm = new AboutONeilloGame();

            // Show the aboutForm as a dialog (modal) window
            aboutForm.ShowDialog();
        }
        private void startGameBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Let's go play the game!");
            bottomtextBoxPlayer1.Enabled = false;
            bottomtextBoxPlayer2.Enabled = false;

            bottomstartGameBtn.Enabled = false;
            gameBoardControl.Enabled = true;
            ShowPlayerOneTurnLabel();

            string player1Name = bottomtextBoxPlayer1.Text;
            string player2Name = bottomtextBoxPlayer2.Text;

        }
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            informationPanelToolStripMenuItem.Checked = !informationPanelToolStripMenuItem.Checked; // Toggle the checked state

            if (!informationPanelToolStripMenuItem.Checked)
            {
                // Hide the controls
                bottompictureBox1.Hide();
                bottomtextBoxPlayer2.Hide();
                bottomtextBoxPlayer1.Hide();
                bottompictureBox2.Hide();
                bottompictureBox3.Hide();
                bottomlabel2PlayerTwoTurn.Hide();
                bottomplayer1Counter.Hide();
                bottomplayer2Counter.Hide();
                bottomstartGameBtn.Hide();
                bottomlabel1Player1Turn.Hide();
            }
            else
            {
                bottompictureBox1.Show();
                bottomtextBoxPlayer2.Show();
                bottomtextBoxPlayer1.Show();
                bottompictureBox2.Show();
                bottompictureBox3.Show();
                bottomlabel2PlayerTwoTurn.Show();
                bottomplayer1Counter.Show();
                bottomplayer2Counter.Show();
                bottomstartGameBtn.Show();
                bottomlabel1Player1Turn.Show();
            }
        }
        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speakToolStripMenuItem.Checked = !speakToolStripMenuItem.Checked;

            if (speakToolStripMenuItem.Checked)
            {
                gameBoardControl.rowColValueSent += GameBoardControl_RowColValueSent;
                MessageBox.Show($"Speak setting has been switched on");
            }
        }
        private void ProvideTilePlacement(int row, int col)
        {
            string rowString = row.ToString();
            string colString = col.ToString();

            string textToSpeak = $"The counter has been placed at {rowString} {colString}";

            //MessageBox.Show("TEXT TO SPEAK: " + textToSpeak);

            Speak(textToSpeak);
        }
        private void Speak(string textToSpeak)
        {
            if (synth != null && speakToolStripMenuItem.Checked)
            {
                synth.SpeakAsync(textToSpeak);
            }
            else
            {
                Debug.WriteLine("SpeechSynthesizer is not initialized or speaking is turned off");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                message = "Do you want to save your game before closing?";
                title = "Close Window";
                result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    using (SaveGame saveGameForm = new SaveGame(gameDataJson))
                    {
                        if (saveGameForm.ShowDialog() == DialogResult.OK)
                        {
                            string gameName = saveGameForm.GameName;
                            int selectedSlot = saveGameForm.SelectedSlot;

                            // Pass the SaveGame instance to SaveGameData
                            SaveGameData(gameName, selectedSlot);
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            // No else clause is needed for the outer DialogResult.Yes check
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save game has been clicked
            using (SaveGame saveGameForm = new SaveGame(gameDataJson))
            {
                if (saveGameForm.ShowDialog() == DialogResult.OK)
                {
                    string gameName = saveGameForm.GameName;
                    int selectedSlot = saveGameForm.SelectedSlot;

                    SaveGameData(gameName, selectedSlot);
                }
            }
        }

        private void SaveGameData(string gameName, int selectedSlot)
        {
            // Access the current game data
            GameDataJson.Composite compositeToSave = gameDataJson.DeserializedComposite;

            // Save the game data to the selected slot
            string selectedSlotName = $"Slot {selectedSlot}";
            compositeToSave.Data[selectedSlotName] = compositeToSave.Gdata;

            // Update the game name
            compositeToSave.Gdata.GameName = gameName;

            // Save the updated data
            gameDataJson.SaveGameData(compositeToSave);
        }

        private void SaveGameDataToSlot(GameDataJson.Composite composite, string gameName, int slot, SaveGame saveGameForm)
        {
            // Save the composite to the specified slot
            saveGameForm.SavingLogic();
        }


        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load the game data
            GameDataJson.Composite loadedComposite = gameDataJson.LoadGameData();

            if (loadedComposite != null)
            {
                // Assuming you have instances of Gdata and PlayerDataAndCounters within your GameDataJson class
                //gameDataJson.Gdata.GameBoardArray = loadedComposite.Gdata.GameBoardArray;
                //gameDataJson.PlayerDataAndCounters.Player1Name = loadedComposite.Gdata.PlayerData.Player1Name;
                //gameDataJson.PlayerDataAndCounters.Player2Name = loadedComposite.Gdata.PlayerData.Player2Name;
                //gameDataJson.PlayerDataAndCounters.BlackCounters = loadedComposite.Gdata.PlayerData.BlackCounters;
                //gameDataJson.PlayerDataAndCounters.WhiteCounters = loadedComposite.Gdata.PlayerData.WhiteCounters;
            }
            else
            {
                MessageBox.Show("No saved game data found.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the current game?", "Save Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    SaveGame saveGameForm = new SaveGame(gameDataJson);
                    DialogResult saveResult = saveGameForm.ShowDialog();

                    if (saveResult == DialogResult.OK)
                    {
                        // No need to call RefreshBoard here; it will be called at the end of the method
                    }
                    else if (saveResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    return;
            }

            // Dispose the existing control if it exists
            //gameBoardControl?.Dispose();

            // Create a new instance of GameBoardControl
            gameBoardControl = new GameBoardControl(this);

            gameBoardControl.RefreshBoard();
        }

    }
}
