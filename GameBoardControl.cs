using GameboardGUI;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static ONeilloGame.GameDataJson;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

//The gameboard logic
//Add in something to count how many counters each turn

namespace ONeilloGame
{
    public partial class GameBoardControl : UserControl
    {
        const int COLUMNS = 8;
        const int ROWS = 8;

        public delegate void PlayerTurnChangedEventHandler(int playerColor);
        public event PlayerTurnChangedEventHandler PlayerTurnChanged;

        public delegate void CountersUpdatedEventHandler(int blackCounters, int whiteCounters);
        public event CountersUpdatedEventHandler CountersUpdated;

        public delegate void TilePlacedEventHandler(int row, int col);
        public event TilePlacedEventHandler rowColValueSent;


        //Returning the array that makes up the board.
        int[,] gameBoardArray = new int[ROWS, COLUMNS];

        GameboardImageArray gameboardGui;
        
        public int[,] gameboardCoords;
        string imagePath = "Resources/";
        private int playerColour = 0;
        const int tileMargin = 1;

        public int PlayerColour
        {
            get { return playerColour; }
        }

        public GameBoardControl(Form parent) //Pulling in the parent form before code runs
        {
            InitializeComponent();

            //To set the first point and the last point on the board
            Point topCorner = new Point(10, 30);
            Point bottomCorner = new Point(10, 135);

            gameboardCoords = this.MakeBoardGame();

            try
            {
                this.gameboardGui = new GameboardImageArray(parent, gameboardCoords, topCorner, bottomCorner, tileMargin, imagePath);
                gameboardGui.UpdateBoardGui(gameboardCoords);
                gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
            }
            catch (Exception ex)
            {
                // Handling the error
                MessageBox.Show("An error with the game occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parent.Close();
            }
        }

        public int[,] MakeBoardGame()
        {
            //Changing all default values to 10, to ensure only 4 in the middle are coloured in. 
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    gameBoardArray[i, j] = 10;
                }
            }

            //Setting the 4 points in the middle of the UI
            gameBoardArray[3, 3] = 1;
            gameBoardArray[4, 4] = 1;
            gameBoardArray[4, 3] = 0;
            gameBoardArray[3, 4] = 0;

            return gameBoardArray;
        }
        private void CountTheTilesOnTheBoard()
        {
            int blackCounters = 0;
            int whiteCounters = 0;

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    int tileValue = gameBoardArray[i, j];

                    if (tileValue == 0)
                    {
                        blackCounters++;
                    }
                    else if (tileValue == 1)
                    {
                        whiteCounters++;
                    }
                }
            }
                        CountersUpdated?.Invoke(blackCounters, whiteCounters);
        }

        public int rowSelect;
        public int colSelect;

        public int RowSelected
        {
            get { return rowSelect; }
        }

        public int ColSelected
        {
            get { return colSelect; }
        }

        private void GameTileClicked(object sender, EventArgs e)
        {

            //Gets the value within the array that was selected
            int colSelect = gameboardGui.GetCurrentColumnIndex(sender);
            int rowSelect = gameboardGui.GetCurrentRowIndex(sender);

            MessageBox.Show($"{colSelect}, {rowSelect} has been clicked");

            bool isValidMove = CheckSurroundingTiles(rowSelect, colSelect, playerColour, gameBoardArray);

            if (isValidMove)
            {
                //Moves have been made
                CountTheTilesOnTheBoard();
                SwitchPlayerColour();
            }
            else
            {
                //the move isn't valid and no move has been made
                MessageBox.Show("Move not valid");
                //not part of spec to have an indication anyway
            }
            
        }
        public bool CheckSurroundingTiles(int row, int col, int playerColour, int[,] gameBoardArray)
        {
            bool isValidMove = false;
            List<int> tileCoordinatesToFlip = new List<int>();

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int dir = 0; dir < 8; dir++)
            {
                int x = row + dx[dir];
                int y = col + dy[dir];

                List<int> tileValuesWithinCircumference = new List<int>();
                List<int> currentDirectionTilesToFlip = new List<int>();

                int opponentsColour = (playerColour == 0) ? 1 : 0;
                bool foundOpponent = false;

                while (x >= 0 && x < gameBoardArray.GetLength(0) && y >= 0 && y < gameBoardArray.GetLength(1))
                {
                    int tileValue = gameBoardArray[x, y];
                    tileValuesWithinCircumference.Add(tileValue);

                    if (tileValue == opponentsColour)
                    {
                        foundOpponent = true;
                        currentDirectionTilesToFlip.Add(x * 100 + y);

                        // Check if the opponent is sandwiched by the current player's counters
                        if (x - dx[dir] >= 0 && x - dx[dir] < gameBoardArray.GetLength(0) &&
                            y - dy[dir] >= 0 && y - dy[dir] < gameBoardArray.GetLength(1) &&
                            gameBoardArray[x - dx[dir], y - dy[dir]] == playerColour)
                        {
                            // Valid move condition for the edge
                            isValidMove = true;
                            tileCoordinatesToFlip.AddRange(currentDirectionTilesToFlip);
                            break;
                        }
                    }
                    else if (tileValue == playerColour && foundOpponent)
                    {
                        // Opponent's color found, and there is at least one opponent's piece in between
                        isValidMove = true;
                        tileCoordinatesToFlip.AddRange(currentDirectionTilesToFlip);
                        break;
                    }
                    else if (tileValue == 0 || !foundOpponent) // Break if empty tile or no opponent found
                    {
                        break;
                    }

                    x += dx[dir];
                    y += dy[dir];
                }
            }

            // Check if the move is at the top or bottom row
            if ((row == 0 || row == gameBoardArray.GetLength(0) - 1) && isValidMove)
            {
                // Check for sandwich conditions for the top or bottom row
                int oppositeColour = (playerColour == 0) ? 1 : 0;

                // Check for the sandwich condition above the current position
                if (row > 0 && gameBoardArray[row - 1, col] == oppositeColour &&
                    row < gameBoardArray.GetLength(0) - 2 && gameBoardArray[row + 2, col] == playerColour)
                {
                    // Valid move condition for the sandwich
                    tileCoordinatesToFlip.Add((row - 1) * 100 + col); // Add the opponent's tile to flip
                }

                // Check for the sandwich condition below the current position
                if (row < gameBoardArray.GetLength(0) - 2 && gameBoardArray[row + 1, col] == oppositeColour &&
                    row > 0 && gameBoardArray[row - 2, col] == playerColour)
                {
                    // Valid move condition for the sandwich
                    tileCoordinatesToFlip.Add((row + 1) * 100 + col); // Add the opponent's tile to flip
                }
            }

            if (isValidMove)
            {
                UpdateTiles(tileCoordinatesToFlip, row, col, gameBoardArray);
            }
            else
            {
                MessageBox.Show($"Current player doesn't have any valid moves!");
                SwitchPlayerColour(); 
            }

            return isValidMove;
        }

        public void UpdateTiles(List<int> tileCoordinatesToFlip, int rowSelect, int colSelect, int[,] gameBoardArray)
        {
            foreach (int tile in tileCoordinatesToFlip)
            {
                int x = tile / 100; // Extract row from unique identifier
                int y = tile % 100; // Extract column from unique identifier
                SwapColour(x, y, gameBoardArray); // Pass the gameBoardArray to SwapColour
            }

            // Place the player's piece in the current position
            gameBoardArray[rowSelect, colSelect] = playerColour; // Set the current player's color
            SetTileForGamePlay(rowSelect, colSelect, playerColour); // Assuming SetTileForGamePlay sets the UI or representation
        }

        private void SwapColour(int row, int col, int[,] gameBoardArray)
        {
            gameBoardArray[row, col] = playerColour; // Set the current player's color
            SetTileForGamePlay(row, col, playerColour); // Assuming SetTileForGamePlay sets the UI or representation
        }

        public void SetTileForGamePlay(int rowSelect, int colSelect, int playerColour)
        {
            //tiles are set to the other colour
            string imageName = playerColour.ToString();
            gameboardGui.SetTile(rowSelect, colSelect, imageName);
            rowColValueSent?.Invoke(rowSelect, colSelect);
        }

        private void SwitchPlayerColour()
        {
            playerColour = (playerColour == 0) ? 1 : 0;

            PlayerTurnChanged?.Invoke(playerColour);
        }
        private void ONeilloGame_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
