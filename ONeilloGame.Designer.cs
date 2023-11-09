namespace ONeilloGame
{
    partial class ONeilloGame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ONeilloGame));
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            textBoxPlayer2 = new TextBox();
            textBoxPlayer1 = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1PlayerOneTurn = new Label();
            label2PlayerTwoTurn = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.MenuHighlight;
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Location = new Point(0, 555);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(713, 128);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.MenuHighlight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(713, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, saveGameToolStripMenuItem, exitToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(132, 22);
            newGameToolStripMenuItem.Text = "New Game";
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(132, 22);
            saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(132, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { speakToolStripMenuItem, informationPanelToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(169, 22);
            speakToolStripMenuItem.Text = "Speak";
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(169, 22);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // textBoxPlayer2
            // 
            textBoxPlayer2.BackColor = SystemColors.HighlightText;
            textBoxPlayer2.BorderStyle = BorderStyle.None;
            textBoxPlayer2.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPlayer2.Location = new Point(546, 577);
            textBoxPlayer2.Name = "textBoxPlayer2";
            textBoxPlayer2.PlaceholderText = "Player 2";
            textBoxPlayer2.Size = new Size(108, 40);
            textBoxPlayer2.TabIndex = 3;
            // 
            // textBoxPlayer1
            // 
            textBoxPlayer1.BackColor = SystemColors.HighlightText;
            textBoxPlayer1.BorderStyle = BorderStyle.None;
            textBoxPlayer1.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPlayer1.Location = new Point(210, 577);
            textBoxPlayer1.Name = "textBoxPlayer1";
            textBoxPlayer1.PlaceholderText = "Player 1";
            textBoxPlayer1.Size = new Size(111, 40);
            textBoxPlayer1.TabIndex = 2;
            textBoxPlayer1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._0;
            pictureBox2.Location = new Point(59, 565);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 118);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._11;
            pictureBox3.Location = new Point(395, 565);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(127, 118);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label1PlayerOneTurn
            // 
            label1PlayerOneTurn.AutoSize = true;
            label1PlayerOneTurn.BackColor = SystemColors.MenuHighlight;
            label1PlayerOneTurn.Location = new Point(210, 634);
            label1PlayerOneTurn.Name = "label1PlayerOneTurn";
            label1PlayerOneTurn.Size = new Size(74, 15);
            label1PlayerOneTurn.TabIndex = 6;
            label1PlayerOneTurn.Text = "Its your turn!";
            label1PlayerOneTurn.Click += label1PlayerOneTurn_Click;
            // 
            // label2PlayerTwoTurn
            // 
            label2PlayerTwoTurn.AutoSize = true;
            label2PlayerTwoTurn.BackColor = SystemColors.MenuHighlight;
            label2PlayerTwoTurn.Location = new Point(546, 634);
            label2PlayerTwoTurn.Name = "label2PlayerTwoTurn";
            label2PlayerTwoTurn.Size = new Size(74, 15);
            label2PlayerTwoTurn.TabIndex = 7;
            label2PlayerTwoTurn.Text = "Its your turn!";
            // 
            // ONeilloGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 683);
            Controls.Add(label2PlayerTwoTurn);
            Controls.Add(label1PlayerOneTurn);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(textBoxPlayer2);
            Controls.Add(textBoxPlayer1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ONeilloGame";
            Text = "ONeillo Game!";
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox textBoxPlayer2;
        private TextBox textBoxPlayer1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1PlayerOneTurn;
        private Label label2PlayerTwoTurn;
    }
}
