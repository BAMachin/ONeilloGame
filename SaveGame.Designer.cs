namespace ONeilloGame
{
    partial class SaveGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveGame));
            btnSaveGame = new Button();
            btnCancel = new Button();
            lblGameName = new Label();
            lblGameSaveSlot = new Label();
            comboBoxGameSlotChoice = new ComboBox();
            txtBoxGameName = new TextBox();
            SuspendLayout();
            // 
            // btnSaveGame
            // 
            btnSaveGame.BackColor = Color.FromArgb(255, 128, 255);
            btnSaveGame.Location = new Point(433, 127);
            btnSaveGame.Name = "btnSaveGame";
            btnSaveGame.Size = new Size(75, 23);
            btnSaveGame.TabIndex = 0;
            btnSaveGame.Text = "Save";
            btnSaveGame.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(352, 127);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.Location = new Point(33, 40);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(76, 15);
            lblGameName.TabIndex = 2;
            lblGameName.Text = "Game Name:";
            // 
            // lblGameSaveSlot
            // 
            lblGameSaveSlot.AutoSize = true;
            lblGameSaveSlot.Location = new Point(33, 81);
            lblGameSaveSlot.Name = "lblGameSaveSlot";
            lblGameSaveSlot.Size = new Size(91, 15);
            lblGameSaveSlot.TabIndex = 3;
            lblGameSaveSlot.Text = "Game Save Slot:";
            // 
            // comboBoxGameSlotChoice
            // 
            comboBoxGameSlotChoice.FormattingEnabled = true;
            comboBoxGameSlotChoice.Location = new Point(137, 80);
            comboBoxGameSlotChoice.Name = "comboBoxGameSlotChoice";
            comboBoxGameSlotChoice.Size = new Size(290, 23);
            comboBoxGameSlotChoice.TabIndex = 4;
            // 
            // txtBoxGameName
            // 
            txtBoxGameName.Location = new Point(137, 37);
            txtBoxGameName.Name = "txtBoxGameName";
            txtBoxGameName.PlaceholderText = "Please enter a name for your game...";
            txtBoxGameName.Size = new Size(290, 23);
            txtBoxGameName.TabIndex = 5;
            // 
            // SaveGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(539, 172);
            Controls.Add(txtBoxGameName);
            Controls.Add(comboBoxGameSlotChoice);
            Controls.Add(lblGameSaveSlot);
            Controls.Add(lblGameName);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveGame);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SaveGame";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSaveGame;
        private Button btnCancel;
        private Label lblGameName;
        private Label lblGameSaveSlot;
        private ComboBox comboBoxGameSlotChoice;
        private TextBox txtBoxGameName;
    }
}