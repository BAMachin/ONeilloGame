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
            bottompictureBox1 = new PictureBox();
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
            bottomtextBoxPlayer2 = new TextBox();
            bottomtextBoxPlayer1 = new TextBox();
            bottompictureBox2 = new PictureBox();
            bottompictureBox3 = new PictureBox();
            bottomlabel2PlayerTwoTurn = new Label();
            bottomplayer1Counter = new Label();
            bottomplayer2Counter = new Label();
            bottomstartGameBtn = new Button();
            bottomlabel1Player1Turn = new Label();
            ((System.ComponentModel.ISupportInitialize)bottompictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottompictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bottompictureBox3).BeginInit();
            SuspendLayout();
            // 
            // bottompictureBox1
            // 
            bottompictureBox1.Anchor = AnchorStyles.Bottom;
            bottompictureBox1.BackColor = SystemColors.MenuHighlight;
            bottompictureBox1.Location = new Point(1, 649);
            bottompictureBox1.Name = "bottompictureBox1";
            bottompictureBox1.Size = new Size(789, 118);
            bottompictureBox1.TabIndex = 0;
            bottompictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.MenuHighlight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(790, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
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
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
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
            speakToolStripMenuItem.Click += speakToolStripMenuItem_Click;
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(169, 22);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += informationPanelToolStripMenuItem_Click;
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
            // bottomtextBoxPlayer2
            // 
            bottomtextBoxPlayer2.AcceptsReturn = true;
            bottomtextBoxPlayer2.Anchor = AnchorStyles.Bottom;
            bottomtextBoxPlayer2.BackColor = SystemColors.HighlightText;
            bottomtextBoxPlayer2.BorderStyle = BorderStyle.None;
            bottomtextBoxPlayer2.Cursor = Cursors.IBeam;
            bottomtextBoxPlayer2.Font = new Font("Calibri", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            bottomtextBoxPlayer2.Location = new Point(549, 666);
            bottomtextBoxPlayer2.Name = "bottomtextBoxPlayer2";
            bottomtextBoxPlayer2.PlaceholderText = "Player #2";
            bottomtextBoxPlayer2.Size = new Size(108, 33);
            bottomtextBoxPlayer2.TabIndex = 3;
            bottomtextBoxPlayer2.TextAlign = HorizontalAlignment.Center;
            // 
            // bottomtextBoxPlayer1
            // 
            bottomtextBoxPlayer1.AcceptsReturn = true;
            bottomtextBoxPlayer1.Anchor = AnchorStyles.Bottom;
            bottomtextBoxPlayer1.BackColor = SystemColors.HighlightText;
            bottomtextBoxPlayer1.BorderStyle = BorderStyle.None;
            bottomtextBoxPlayer1.Cursor = Cursors.IBeam;
            bottomtextBoxPlayer1.Font = new Font("Calibri", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            bottomtextBoxPlayer1.Location = new Point(138, 666);
            bottomtextBoxPlayer1.Name = "bottomtextBoxPlayer1";
            bottomtextBoxPlayer1.PlaceholderText = "Player #1";
            bottomtextBoxPlayer1.Size = new Size(111, 33);
            bottomtextBoxPlayer1.TabIndex = 2;
            bottomtextBoxPlayer1.TextAlign = HorizontalAlignment.Center;
            bottomtextBoxPlayer1.TextChanged += textBox1_TextChanged;
            // 
            // bottompictureBox2
            // 
            bottompictureBox2.Anchor = AnchorStyles.Bottom;
            bottompictureBox2.Image = Properties.Resources._0;
            bottompictureBox2.Location = new Point(1, 649);
            bottompictureBox2.Name = "bottompictureBox2";
            bottompictureBox2.Size = new Size(128, 118);
            bottompictureBox2.TabIndex = 4;
            bottompictureBox2.TabStop = false;
            // 
            // bottompictureBox3
            // 
            bottompictureBox3.Image = Properties.Resources._11;
            bottompictureBox3.Location = new Point(663, 649);
            bottompictureBox3.Name = "bottompictureBox3";
            bottompictureBox3.Size = new Size(127, 118);
            bottompictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            bottompictureBox3.TabIndex = 5;
            bottompictureBox3.TabStop = false;
            bottompictureBox3.Click += pictureBox3_Click;
            // 
            // bottomlabel2PlayerTwoTurn
            // 
            bottomlabel2PlayerTwoTurn.Anchor = AnchorStyles.Bottom;
            bottomlabel2PlayerTwoTurn.AutoSize = true;
            bottomlabel2PlayerTwoTurn.BackColor = SystemColors.MenuHighlight;
            bottomlabel2PlayerTwoTurn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            bottomlabel2PlayerTwoTurn.ForeColor = Color.Navy;
            bottomlabel2PlayerTwoTurn.Location = new Point(546, 704);
            bottomlabel2PlayerTwoTurn.Name = "bottomlabel2PlayerTwoTurn";
            bottomlabel2PlayerTwoTurn.Size = new Size(111, 20);
            bottomlabel2PlayerTwoTurn.TabIndex = 7;
            bottomlabel2PlayerTwoTurn.Text = "Player 2 to go!";
            bottomlabel2PlayerTwoTurn.Visible = false;
            // 
            // bottomplayer1Counter
            // 
            bottomplayer1Counter.Anchor = AnchorStyles.Bottom;
            bottomplayer1Counter.AutoSize = true;
            bottomplayer1Counter.BackColor = SystemColors.ActiveCaptionText;
            bottomplayer1Counter.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            bottomplayer1Counter.ForeColor = SystemColors.ButtonHighlight;
            bottomplayer1Counter.Location = new Point(44, 683);
            bottomplayer1Counter.Name = "bottomplayer1Counter";
            bottomplayer1Counter.Size = new Size(0, 47);
            bottomplayer1Counter.TabIndex = 8;
            // 
            // bottomplayer2Counter
            // 
            bottomplayer2Counter.Anchor = AnchorStyles.Bottom;
            bottomplayer2Counter.AutoSize = true;
            bottomplayer2Counter.BackColor = SystemColors.Window;
            bottomplayer2Counter.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            bottomplayer2Counter.Location = new Point(706, 683);
            bottomplayer2Counter.Name = "bottomplayer2Counter";
            bottomplayer2Counter.Size = new Size(0, 47);
            bottomplayer2Counter.TabIndex = 9;
            // 
            // bottomstartGameBtn
            // 
            bottomstartGameBtn.Anchor = AnchorStyles.Bottom;
            bottomstartGameBtn.BackColor = Color.FromArgb(255, 128, 255);
            bottomstartGameBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            bottomstartGameBtn.Location = new Point(307, 683);
            bottomstartGameBtn.Name = "bottomstartGameBtn";
            bottomstartGameBtn.Size = new Size(191, 47);
            bottomstartGameBtn.TabIndex = 10;
            bottomstartGameBtn.Text = "Start Game";
            bottomstartGameBtn.UseVisualStyleBackColor = false;
            bottomstartGameBtn.Click += startGameBtn_Click;
            // 
            // bottomlabel1Player1Turn
            // 
            bottomlabel1Player1Turn.Anchor = AnchorStyles.Bottom;
            bottomlabel1Player1Turn.AutoSize = true;
            bottomlabel1Player1Turn.BackColor = SystemColors.MenuHighlight;
            bottomlabel1Player1Turn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            bottomlabel1Player1Turn.ForeColor = Color.Navy;
            bottomlabel1Player1Turn.Location = new Point(138, 704);
            bottomlabel1Player1Turn.Name = "bottomlabel1Player1Turn";
            bottomlabel1Player1Turn.Size = new Size(111, 20);
            bottomlabel1Player1Turn.TabIndex = 11;
            bottomlabel1Player1Turn.Text = "Player 1 to go!";
            bottomlabel1Player1Turn.Visible = false;
            // 
            // ONeilloGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 767);
            Controls.Add(bottomlabel1Player1Turn);
            Controls.Add(bottomstartGameBtn);
            Controls.Add(bottomplayer2Counter);
            Controls.Add(bottomplayer1Counter);
            Controls.Add(bottomlabel2PlayerTwoTurn);
            Controls.Add(bottompictureBox3);
            Controls.Add(bottompictureBox2);
            Controls.Add(bottomtextBoxPlayer2);
            Controls.Add(bottomtextBoxPlayer1);
            Controls.Add(bottompictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ONeilloGame";
            Text = "ONeillo Game!";
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)bottompictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bottompictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bottompictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox bottompictureBox1;
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
        private TextBox bottomtextBoxPlayer2;
        private TextBox bottomtextBoxPlayer1;
        private PictureBox bottompictureBox2;
        private PictureBox bottompictureBox3;
        private Label bottomlabel2PlayerTwoTurn;
        public Label bottomplayer1Counter;
        public Label bottomplayer2Counter;
        private Button bottomstartGameBtn;
        private Label bottomlabel1Player1Turn;
    }
}
