using GameboardGUI;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

//The gameboard logic

namespace ONeilloGame
{

    public partial class GameBoardControl : UserControl
    {
        const int COLUMNS = 8;
        const int ROWS = 8;

        GameboardImageArray gameboardGui;
        public int[,] gameboardCoords;
        string imagePath = "Resources/";
        private int playerColour = 0;
        const int tileMargin = 1;

        public GameBoardControl()
        {
            ONeilloGame parent = (ONeilloGame)this.Parent;
            InitializeComponent();

            //To set the first point and the last point on the board.
            Point topCorner = new Point(0, 0);
            Point bottomCorner = new Point(8, 8);

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
            //Returning the array that makes up the board.
            int[,] gameBoardArray = new int[ROWS, COLUMNS];

            //Changing all default values to 10, to ensure only 4 in the middle are coloured in. 
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    gameBoardArray[i, j] = 10;
                }
            }

            //Setting the 4 points in the middle of the UI
            gameBoardArray[3, 3] = 0;
            gameBoardArray[4, 4] = 0;
            gameBoardArray[4, 3] = 1;
            gameBoardArray[3, 4] = 1;

            return gameBoardArray;
        }
        private void GameTileClicked(object sender, EventArgs e)
        {
            int colSelect = gameboardGui.GetCurrentColumnIndex(sender);
            int rowSelect = gameboardGui.GetCurrentRowIndex(sender);

            //Gets the value within the array that was selected

            bool isValidMove = CheckSurroundingTiles(rowSelect, colSelect, playerColour);

            if (isValidMove)
            {
                setTileForGamePlay(rowSelect, colSelect, playerColour);
            }
            else
            {
                DialogResult result = MessageBox.Show("Move not valid");
            }

        }
        public bool CheckSurroundingTiles(int row, int col, int playerColour)
        {
            //variable to change all colours inbetween two counters to flip them to the opposite colour
            //bool flipAllPlayerCounter = false; 

            List<int> pointsEvaluated = new List<int>();
            //Looks at each direction from the point of the tile clicked
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int dir = 0; dir < 8; dir++)
            {
                int x = row + dx[dir];
                int y = col + dy[dir];

                // Check within boundaries of the board
                while (x >= 0 && x < ROWS && y >= 0 && y < COLUMNS)
                {
                    //gets tile value
                    int tileValue = gameboardCoords[x, y];
                    
                    //adds tile value to a list
                    pointsEvaluated.Add(tileValue);

                    if ((tileValue == 10) || (tileValue == playerColour))
                    {
                        //tile is blank
                        //or
                        //tile is the same as player colour
                        //not valid
                        return false; 
                    }
                    else
                    {
                        //tile is not blank or player colour
                        //valid move
                        moveIsValid(pointsEvaluated); 
                    }
                    
                    //NEEDS TO MEET ANOTHER COUNTER OF THE SAME COLOUR 
                    //if its gets to find a counter of colour playing or empty then it is a valid move 
                    // make a list of the counters scanned
                    // check if its valid
                    // for each loop to swap those points to the colour playing
                    // carry on checking to ensure all counters are changed - multipoint direction turns 
                    // but do that afterwards get first bit of logic in first 


                    // Move to the next tile in this direction
                    x += dx[dir];
                    y += dy[dir];
                }
            }
            moveIsValid(pointsEvaluated);
            return false;
        }

        private void SwitchPlayerColor()
        {
            playerColour = (playerColour == 0) ? 1 : 0;
        }

        public void moveIsValid(List<int> pointsEvaluated)
        {
            foreach (int point in pointsEvaluated)
            {
                //setTileForGamePlay(rowSelect, colSelect, playerColor);
            }
        }

        public void setTileForGamePlay(int rowSelect, int colSelect, int playerColor)
        {
            string imageName = playerColor.ToString();
            gameboardGui.SetTile(rowSelect, colSelect, imageName);
            SwitchPlayerColor();
        }


        private void ONeilloGame_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
