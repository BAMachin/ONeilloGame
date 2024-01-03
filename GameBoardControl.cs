using GameboardGUI;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Speech.Synthesis;
using System.Windows.Forms;
using static ONeilloGame.GameDataJson;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

//The gameboard logic

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

        public delegate void BoardResetEventHandler();
        public event BoardResetEventHandler BoardReset;

        public delegate void LoadGameEventHandler(string player1Name, string player2Name, int blackCounters, int whiteCounters);
        public event LoadGameEventHandler LoadGame;

        public ONeilloGame ONeilloGame; 

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

        public int[,] GameBoardArray
        {
            get { return gameBoardArray; }
            set { gameBoardArray = value; }
        }


        public GameBoardControl(Form parent)
        {
            InitializeComponent();

            this.ONeilloGame = ONeilloGame;

            // To set the first point and the last point on the board
            Point topCorner = new Point(10, 30);
            Point bottomCorner = new Point(10, 135);

            gameboardCoords = this.MakeBoardGame();

            try
            {
                parent.ClientSize = new Size(816, 816);

                this.gameboardGui = new GameboardImageArray(parent, gameboardCoords, topCorner, bottomCorner, tileMargin, imagePath);
                gameboardGui.UpdateBoardGui(gameboardCoords);
                gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error with the game occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parent.Close();
            }
        }

        public void ResetBoard()
        {
            MakeBoardGame(); //returns the original array with all 10s except 4 middle counters
            gameboardGui.UpdateBoardGui(gameBoardArray);
            BoardReset?.Invoke();
            playerColour = 0;
        }

        public void ResetBoardBasedOnSavedData(string player1Name, string player2Name, int blackCounters, int whiteCounters, int[,] gameBoardArrayFromData)
        {
            // Copy the saved game board array to the current board array
            Array.Copy(gameBoardArrayFromData, gameBoardArray, gameBoardArrayFromData.Length);

            // Update the GUI with the new board state
            gameboardGui.UpdateBoardGui(gameBoardArray);

            // Set playerColour to 0
            playerColour = 0;

            MessageBox.Show($"Game Loading:\n{player1Name} with {blackCounters} counters,\n{player2Name} with {whiteCounters} counters");

            LoadGame.Invoke(player1Name, player2Name, blackCounters, whiteCounters); 

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
        private (int blackCounters, int whiteCounters) CountTheTilesOnTheBoard()
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
            return (blackCounters, whiteCounters);
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
            // Gets the value within the array that was selected
            int colSelect = gameboardGui.GetCurrentColumnIndex(sender);
            int rowSelect = gameboardGui.GetCurrentRowIndex(sender);

            //MessageBox.Show($"{colSelect}, {rowSelect} has been clicked");

            // Declare and initialize tileCoordinatesToFlip
            List<int> tileCoordinatesToFlip = new List<int>();

            bool isCurrentMoveValid = CheckSurroundingTiles(rowSelect, colSelect, playerColour, gameBoardArray, tileCoordinatesToFlip);

            if (isCurrentMoveValid)
            {
                UpdateTiles(tileCoordinatesToFlip, rowSelect, colSelect, gameBoardArray);
                CountTheTilesOnTheBoard();
                SwitchPlayerColour();
            }
            else
            {
                // The move isn't valid and no move has been made
                MessageBox.Show("Move not valid, checking if there are any valid moves on the board");

                // Now to check the entire board
                bool foundValidMoveOnEntireBoard = false;

                // Iterate through each cell on the game board
                for (int row = 0; row < ROWS; row++)
                {
                    for (int col = 0; col < COLUMNS; col++)
                    {
                        if (CheckSurroundingTiles(row, col, playerColour, gameBoardArray, tileCoordinatesToFlip))
                        {
                            foundValidMoveOnEntireBoard = true;
                            break; // Break out of the loop if any valid move is found
                        }
                    }

                    if (foundValidMoveOnEntireBoard)
                        break; // Break out of the outer loop if any valid move is found
                }

                // Check if at least one valid move was found
                if (!foundValidMoveOnEntireBoard)
                {
                    // No valid moves found on the board for the current player
                    // Check if there are valid moves for the other player
                    bool foundValidMoveForOtherPlayer = false;

                    // Iterate through each cell on the game board
                    for (int row = 0; row < ROWS; row++)
                    {
                        for (int col = 0; col < COLUMNS; col++)
                        {
                            if (CheckSurroundingTiles(row, col, 1 - playerColour, gameBoardArray, tileCoordinatesToFlip))
                            {
                                foundValidMoveForOtherPlayer = true;
                                break; // Break out of the loop if any valid move is found for the other player
                            }
                        }

                        if (foundValidMoveForOtherPlayer)
                            break; // Break out of the outer loop if any valid move is found for the other player
                    }

                    if (!foundValidMoveForOtherPlayer)
                    {
                        // Call the method and get the counts
                        var counters = CountTheTilesOnTheBoard();
                        int blackCounters = counters.blackCounters;
                        int whiteCounters = counters.whiteCounters;

                        // Display a message saying the game is finished
                        MessageBox.Show($"Game Finished!\n\nPlayer 1 Count: {blackCounters}\nPlayer 2 Count: {whiteCounters}");
                    }
                    else
                    {
                        // There are still valid moves for the other player
                        MessageBox.Show("No valid moves found on the board for the current player, player switch");
                        SwitchPlayerColour();
                    }
                }
                else
                {
                    // There are valid moves for the current player, they need to choose another tile
                    MessageBox.Show("Valid moves found, please select another tile to place");
                }
            }
        }


        public bool CheckSurroundingTiles(int row, int col, int playerColour, int[,] gameBoardArray, List<int> tileCoordinatesToFlip)
        {
            const int BoardSize = 100;
            bool isValidMove = false;

            int[] directionX = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] directionY = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int dir = 0; dir < 8; dir++)
            {
                int x = row + directionX[dir];
                int y = col + directionY[dir];

                List<int> currentDirectionTilesToFlip = new List<int>();

                while (IsValidCoordinate(x, y, gameBoardArray.GetLength(0), gameBoardArray.GetLength(1)))
                {
                    int tileValue = gameBoardArray[x, y];

                    if (tileValue == playerColour)
                    {
                        if (currentDirectionTilesToFlip.Count > 0)
                        {
                            isValidMove = true;
                            tileCoordinatesToFlip.AddRange(currentDirectionTilesToFlip);
                        }
                        break;
                    }
                    else if (tileValue == 1 - playerColour) // Opponent's color
                    {
                        currentDirectionTilesToFlip.Add(x * BoardSize + y);
                    }
                    else if (tileValue == 0) // Empty tile
                    {
                        break;
                    }

                    x += directionX[dir];
                    y += directionY[dir];
                }

                if (IsTopOrBottomRow(row, gameBoardArray.GetLength(0)) && directionX[dir] != 0 &&
                    IsValidCoordinate(row + 2 * directionX[dir], col + 2 * directionY[dir], gameBoardArray.GetLength(0), gameBoardArray.GetLength(1)) &&
                    gameBoardArray[row + 2 * directionX[dir], col + 2 * directionY[dir]] == playerColour &&
                    gameBoardArray[row + directionX[dir], col + directionY[dir]] == 1 - playerColour)
                {
                    isValidMove = true;
                    tileCoordinatesToFlip.Add((row + directionX[dir]) * BoardSize + col + directionY[dir]);
                }
            }

            return isValidMove;
        }

        private bool IsValidCoordinate(int x, int y, int rows, int cols)
        {
            return x >= 0 && x < rows && y >= 0 && y < cols;
        }

        private bool IsTopOrBottomRow(int row, int numRows)
        {
            return row == 0 || row == numRows - 1;
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
            SetTileForGamePlay(rowSelect, colSelect, playerColour); 
        }

        private void SwapColour(int row, int col, int[,] gameBoardArray)
        {
            gameBoardArray[row, col] = playerColour; // Set the current player's color
            SetTileForGamePlay(row, col, playerColour); 
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
