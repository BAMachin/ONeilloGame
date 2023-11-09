using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //private void label1PlayerOneTurn_Click(object sender, EventArgs e)
        //{
        //    if (playerColour == 0)
        //    {
        //        labelPlayerOneTurn.Show();
        //        label2PlayerTwoTurn.Hide();
        //    }
        //    else if (playerColour == 1)
        //    {
        //        label2PlayerTwoTurn.Show();
        //        labelPlayerOneTurn.Hide();
        //    }
        //}

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
            textBoxPlayer1.Enabled = false;
            textBoxPlayer2.Enabled = false;
        }
    }
}
