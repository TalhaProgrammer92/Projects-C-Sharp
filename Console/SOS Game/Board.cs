using System.Numerics;

namespace SOS_Game
{
    class Board
    {
        // Data
        Cell[,] grid = new Cell[9, 9];
        bool isFilled;

        // Constructor
        public Board()
        {
            Clear();
        }

        // Is filled property
        public bool IsFilled
        {
            get
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        if (grid[i, j].Letter == '-') 
                            return false;
                return true;
            }
        }

        // Clear board
        public void Clear()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    grid[i, j] = new Cell();
        }

        // Display
        public void Display()
        {
            // Index Numbers - Column
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("   ");
            for (int i = 0; i < 9; i++)
                Console.Write($"  {i} ");
            Console.WriteLine();

            // Grid
            for (int i = 0; i < 9; i++)
            {
                // Index Numbers - Row
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("  |");

                // The Grid
                for (int j = 0; j < 9; j++)
                {
                    // Color Setting
                    if (grid[i, j].Letter == '-')
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else
                    {
                        if (grid[i, j].Combined)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write($" {grid[i, j].Letter} ");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('|');
                }
                Console.WriteLine();
            }

            // Reset Color
            Console.ResetColor();
        }

        // Place letter
        public void PlaceLetterAt(int row, int column, char letter)
        {
            grid[row, column].Letter = letter;
        }

        // Get cell
        public Cell GetCellAt(int row, int column)
        {
            return grid[row, column];
        }
    }
}
