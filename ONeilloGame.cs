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
//if not valid moves at all - notify player
//who has won the game 

//Speak setting - player placed counter row and col only - set to null but unsure why??

//JSON File setting - for new and load game
//Exit game - save if half way through a game prompt
//if there are no saved games - the load button should be disabled

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

        private PlayerDataAndCounters playerData = new PlayerDataAndCounters();

        //private SpeechSynthesizer synthesizer = new();
        public ONeilloGame()
        {
            InitializeComponent();
            gameBoardControl = new GameBoardControl(this);
            this.Controls.Add(gameBoardControl);

            gameBoardControl.PlayerTurnChanged += GameBoardControl_PlayerTurnChanged;
            gameBoardControl.CountersUpdated += GameBoardControl_CountersUpdated;

            //gameBoardControl.rowColValueSent += GameBoardControl_RowColValueSent;

            informationPanelToolStripMenuItem.Checked = true;
            speakToolStripMenuItem.Checked = false;
            synth = new SpeechSynthesizer();

        }

        //private void GameBoardControl_RowColValueSent(int row, int col)
        //{
        //    ProvideTilePlacement(row, col);
        //}


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
            speakToolStripMenuItem.Checked = !speakToolStripMenuItem.Checked; // Toggle the checked state

            if (speakToolStripMenuItem.Checked)
            {
                MessageBox.Show($"Speak setting has been switched on");
                //Debug.WriteLine($"Before calling Speak. Synthesizer: {synthesizer}");
            }
        }

        //private void ProvideTilePlacement(int row, int col)
        //{
        //    string rowString = row.ToString(); 
        //    string colString = col.ToString();
        //    string textToSpeak = $"The counter has been placed at {rowString} {colString}.";
        //    // Speak the row and col selected
        //    Speak(textToSpeak);
        //}

        //private void Speak(string textToSpeak)
        //{
        //    if (synth != null && speakToolStripMenuItem.Checked) //initialised and checked on the menu
        //    {
        //        synth.SpeakAsync(textToSpeak);
        //    }
        //    else
        //    {
        //        // Log or handle the case where synthesizer is null or speaking is turned off
        //        Debug.WriteLine("SpeechSynthesizer is not initialized or speaking is turned off");
        //    }
        //}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                message = "Remember to save your game";
                title = "Close Window";
                MessageBox.Show(message, title);
            }
            else
            {
                //prompt the user to save the game 
                //message box with save game button and save to json file
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save game has been clicked
            using (SaveGame saveGameForm = new SaveGame())
            {
                if (saveGameForm.ShowDialog() == DialogResult.OK)
                {
                    // Save the game using the provided information (name and slot)
                    string gameName = saveGameForm.GameName;
                    int selectedSlot = saveGameForm.SelectedSlot;

                    // Call the method to save the game with the provided information
                    SaveGameData(gameName, selectedSlot);
                }
                // else: The user canceled the operation
            }
        }
        private void SaveGameData(string gameName, int selectedSlot)
        {
            GameDataJson gameData = new GameDataJson();
            GameDataJson.Composite compositeToSave = new GameDataJson.Composite();
            // Set other game data properties here

            // Save the composite to the specified slot
            // For example, assuming there's an array of composites for different slots
            SaveGameDataToSlot(compositeToSave, selectedSlot);
        }

        private void SaveGameDataToSlot(GameDataJson.Composite composite, int slot)
        {
            // Save the composite to the specified slot
            // You might want to manage your game data storage logic here
            // For example, save it to an array or dictionary based on the slot
        }
    }
}
