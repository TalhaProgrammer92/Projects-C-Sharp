namespace Sudoku
{
    class Game
    {
        // Attributes
        Player player = new Player("Talha Ahmad");
        Grid board = new Grid();
        bool gameOver;
        int row, column, number;

        // Constructor
        public Game()
        {
            gameOver = false;
        }

        // Update
        void Update()
        {
            if (board.IsFilled())
            {
                if (AllValidInGrid())
                    gameOver = true;
                else
                    gameOver = false;
            }
            else
                gameOver = false;
        }

        // Check whole grid
        public bool AllValidInGrid()
        {
            bool allValid = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!IsValidEntry(i, j))
                    {
                        allValid = false;
                        player.DecreaseScore();
                    }
                }
            }
            return allValid;
        }

        // Pre-fill the Board's cell
        void PreFillCell(int row_index, int column_index, byte value)
        {
            board.cells[row_index, column_index].Value = value;
            board.cells[row_index, column_index].MakeFixed();
        }

        // Pre-fill the Board (Difficulty: Medium)
        void PreFillBoard()
        {
            // Row 1
            PreFillCell(0, 0, 9);
            PreFillCell(0, 5, 5);
            PreFillCell(0, 6, 1);

            // Row 2
            PreFillCell(1, 2, 5);
            PreFillCell(1, 3, 4);
            PreFillCell(1, 6, 8);

            // Row 3
            PreFillCell(2, 1, 4);
            PreFillCell(2, 2, 7);

            // Row 4
            PreFillCell(3, 0, 8);
            PreFillCell(3, 5, 3);
            PreFillCell(3, 8, 6);

            // Row 5
            PreFillCell(4, 0, 7);
            PreFillCell(4, 1, 6);
            PreFillCell(4, 3, 9);
            PreFillCell(4, 8, 2);

            // Row 6
            PreFillCell(5, 5, 4);
            PreFillCell(5, 8, 7);

            // Row 8
            PreFillCell(7, 0, 6);
            PreFillCell(7, 5, 9);
            PreFillCell(7, 6, 3);

            // Row 9
            PreFillCell(8, 0, 5);
            PreFillCell(8, 4, 2);
            PreFillCell(8, 8, 8);
        }

        // Get data from user and use it
        void GetPlayerInput()
        {
            int[] valid_numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Get location
            do
            {
                // Get data
                row = Misc.GetInput("Enter number for row between 1 and 9>> ", valid_numbers);
                column = Misc.GetInput("Enter number for column between 1 and 9>> ", valid_numbers);

                // Decrement lcoaiton values
                row--; column--;

                // If the player trying to change fixed value
                if (board.cells[row, column].IsFixed())
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"The developer had set the value '{board.cells[row, column].Value}' at position ({row + 1}, {column + 1}) to unchangeable!\n");
                }
            } while (board.cells[row, column].IsFixed());

            // Get number                
            number = Misc.GetInput("Enter number for entry between 1 and 9>> ", valid_numbers);
        }

        // Place data according to player's input
        void PlaceEntry()
        {
            board.cells[row, column].Value = Convert.ToByte(number);
        }

        // Check if a single number entered by user at specific lcoation is correct
        bool IsValidEntry(int row, int column)
        {
            // Line check
            for (int i = 0; i < 9; i++)
            {
                // Row
                if (i != column)
                {
                    if (board.cells[row, i].Value == number)
                        return false;
                }
                // Column
                if (i != row)
                {
                    if (board.cells[i, column].Value == number)
                        return false;
                }
            }

            // Box Check
            int boxRow = row - row % 3;
            int boxColumn = column - column % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boxRow + i != row && boxColumn + j != column)
                    {
                        if (board.cells[boxRow + i, boxColumn + j].Value == number)
                            return false;
                    }
                }
            }

            return true;
        }

        void DisplayScoreOfPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your Current Score is {player.GetScore()}");
            Console.ResetColor();
        }

        void DisplayResult()
        {
            // Clear Screen
            Console.Clear();

            // Display the board
            board.Display();

            // Announce
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = $" Your Score is {player.GetScore()}.";

            // Add some greets
            if (player.GetScore() >= 180)
                message = "Genius!" + message + " You have made a record but you should not stop to keep practicing.";
            else if (player.GetScore() >= 120)
                message = "Great!" + message + " You have the potential to make a record.";
            else if (player.GetScore() >= 80)
                message = "Good!" + message + " You can get even better.";
            else if (player.GetScore() > 50)
                message = "Not too Bad!" + message + " You need to focus more on next time.";
            else if (player.GetScore() <= 50)
                message = "Too Bad!" + message + " You should keep practicing and remember failure is the key to success.";

            // Final Result
            Console.WriteLine(message);
            Console.ResetColor();
        }

        void CheckEntryValidation()
        {
            bool valid = IsValidEntry(this.row, this.column);
            board.cells[row, column].valid = valid;

            // Score System
            if (valid)
                player.IncreaseScore();
            else
                player.DecreaseScore();
        }

        // Play the game
        public void Play()
        {
            // Set the game's board and difficulty level
            PreFillBoard();

            // Game Loop
            while (!gameOver)
            {
                // Clear Screen
                Console.Clear();

                // Display the board
                board.Display();

                // Display Current Score
                DisplayScoreOfPlayer();

                // Get input by the player
                GetPlayerInput();

                // Place
                PlaceEntry();

                // Check Entry Validation
                CheckEntryValidation();

                // Update
                Update();
            }

            // Game Result
            DisplayResult();
        }
    }
}
