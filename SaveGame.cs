using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONeilloGame
{
    public partial class SaveGame : Form
    {
        public string GameName { get; private set; }
        public int SelectedSlot { get; private set; }

        public SaveGame()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input, set properties, and close the form
            GameName = txtBoxGameName.Text;
            SelectedSlot = comboBoxGameSlotChoice.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
