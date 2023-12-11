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
    public partial class LoadGame : Form
    {
        // Property to get the selected slot from outside the form
        public int SelectedSlot { get; private set; }

        public LoadGame()
        {
            InitializeComponent();

            // Initialize UI elements and set event handlers
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Populate the ComboBox with game slots (1-5)
            for (int i = 1; i <= 5; i++)
            {
                comboBoxSlots.Items.Add(i);
            }

            // Set the default selected index
            comboBoxSlots.SelectedIndex = 0;

            // Set event handlers for buttons
            buttonOK.Click += ButtonOK_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Retrieve the selected slot from the ComboBox
            SelectedSlot = (int)comboBoxSlots.SelectedItem;

            // Set the DialogResult to OK
            DialogResult = DialogResult.OK;

            // Close the form
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Set the DialogResult to Cancel
            DialogResult = DialogResult.Cancel;

            // Close the form
            Close();
        }
    }
}

