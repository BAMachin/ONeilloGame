using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TO DO:
//Get gameboard parent working correctly
//Check code logic
//Speak setting
//JSON File setting - for new and load game
//Exit game - save if half way through a game prompt
//Board counters - number of counters of each colour

//the user controls surrounding the game board

namespace ONeilloGame
{
    public partial class ONeilloGame : Form
    {
        private GameBoardControl gameBoardControl;

        public ONeilloGame()
        {
            InitializeComponent();

            gameBoardControl = new GameBoardControl();

            this.Controls.Add(gameBoardControl);
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

        private void label1PlayerOneTurn_Click(object sender, EventArgs e)
        {
            //need to figure out how to pull in the colour from the gameboard controls code 

            //if (playerColour == 0)
            //{
            //    bottomlabel1Player1Turn.Show();
            //    bottomlabel2PlayerTwoTurn.Hide();
            //}
            //else if (playerColour == 1)
            //{
            //    bottomlabel2PlayerTwoTurn.Show();
            //    bottomlabel1Player1Turn.Hide();
            //}
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
            MessageBox.Show("Let's go! The game has started.");
            bottomtextBoxPlayer1.Enabled = false;
            bottomtextBoxPlayer2.Enabled = false;
        }

        private void player1Counter_Click(object sender, EventArgs e)
        {

        }

        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (informationPanelToolStripMenuItem.Checked)
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
    }
}
