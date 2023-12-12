namespace ONeilloGame
{
    partial class LoadGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadGame));
            lblGameSaveSlot = new Label();
            comboBoxGameSlotChoiceLoading = new ComboBox();
            lblSelectGame = new Label();
            btnCancel = new Button();
            btnLoadGame = new Button();
            SuspendLayout();
            // 
            // lblGameSaveSlot
            // 
            lblGameSaveSlot.AutoSize = true;
            lblGameSaveSlot.Location = new Point(36, 74);
            lblGameSaveSlot.Name = "lblGameSaveSlot";
            lblGameSaveSlot.Size = new Size(91, 15);
            lblGameSaveSlot.TabIndex = 4;
            lblGameSaveSlot.Text = "Game Save Slot:";
            // 
            // comboBoxGameSlotChoiceLoading
            // 
            comboBoxGameSlotChoiceLoading.FormattingEnabled = true;
            comboBoxGameSlotChoiceLoading.Location = new Point(133, 71);
            comboBoxGameSlotChoiceLoading.Name = "comboBoxGameSlotChoiceLoading";
            comboBoxGameSlotChoiceLoading.Size = new Size(290, 23);
            comboBoxGameSlotChoiceLoading.TabIndex = 5;
            // 
            // lblSelectGame
            // 
            lblSelectGame.AutoSize = true;
            lblSelectGame.Location = new Point(36, 25);
            lblSelectGame.Name = "lblSelectGame";
            lblSelectGame.Size = new Size(245, 15);
            lblSelectGame.TabIndex = 6;
            lblSelectGame.Text = "Please select the game you want to continue:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(348, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoadGame
            // 
            btnLoadGame.BackColor = Color.FromArgb(255, 128, 255);
            btnLoadGame.Location = new Point(429, 122);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(75, 23);
            btnLoadGame.TabIndex = 8;
            btnLoadGame.Text = "Load";
            btnLoadGame.UseVisualStyleBackColor = false;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // LoadGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(539, 172);
            Controls.Add(btnLoadGame);
            Controls.Add(btnCancel);
            Controls.Add(lblSelectGame);
            Controls.Add(comboBoxGameSlotChoiceLoading);
            Controls.Add(lblGameSaveSlot);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoadGame";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Load Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGameSaveSlot;
        private ComboBox comboBoxGameSlotChoiceLoading;
        private Label lblSelectGame;
        private Button btnCancel;
        private Button btnLoadGame;
    }
}