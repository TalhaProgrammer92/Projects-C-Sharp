namespace SOS_Game
{
    class Round
    {
        Board gameBoard = new Board();
        Player[] players = new Player[2];
        char[] letters = new char[2] {'S', 'O'};
        bool gameOver;
        int turn;

        // Constructor
        public Round(Player[] players)
        {
            // Settnig up variables
            this.players = players;
            gameOver = false;
            turn = 0;
        }

        // Update game control variables
        void Update()
        {
            turn = (turn < players.Length - 1) ? turn = turn + 1 : turn = 0;
            gameOver = gameBoard.IsFilled;
        }

        // Play the round
        public void StartGame()
        {
            int[] legalBoardIndex = new int[9] {0, 1, 2, 3, 4, 5, 6, 7, 8};
            int[] legalLetterIndex = new int[2] {1, 2};

            while (!gameOver)
            {
                // Clear the console
                Console.Clear();

                // Display the board
                gameBoard.Display();

                // Tell player's turn
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n{players[turn].name}'s Turn !!");
                
                // Get index data from user
                int row = Player.TakeInput("Enter row index>> ", legalBoardIndex);
                int column = Player.TakeInput("Enter column index>> ", legalBoardIndex);
                int letter_index = Player.TakeInput("Enter 1 for 'S' and 2 for 'O'>> ", legalLetterIndex);

                // Update Game Control
                Update();
            }
        }
    }
}
