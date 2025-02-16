namespace Sudoku
{
    class Grid
    {
        // Attribute
        public Cell[,] cells = new Cell[9, 9];

        // Constructor
        public Grid()
        {
            Reset();
        }

        // Clear the grid
        public void Reset()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    cells[i, j] = new Cell();
        }

        // Display the Grid
        public void Display()
        {
            // The Grid of cells
            for (int i = 0; i < 9; i++)
            {
                // Box Row Seperators
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (i % 3 == 0)
                    Misc.Sequence(length: 41, character: '=', line_break: true);

                // Cells
                for (int j = 0; j < 9; j++)
                { 
                    // Double Pipe
                    if (j % 3 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('|');
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write('|');

                    // The cell
                    Cell cell = cells[i, j];
                    if (cell.Value == 0)
                        Misc.Sequence(length: 3);
                    else
                    {
                        if (cell.IsFixed()) Console.ForegroundColor = ConsoleColor.DarkYellow;
                        else
                        {
                            if (cell.valid) Console.ForegroundColor = ConsoleColor.Green;
                            else Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write($" {cell.Value} ");
                    }

                    // Pipe
                    if (j < 8)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('|');

                    if (j < 8) Console.Write('\b');
                }
                Console.WriteLine('|');

                // Row Seperators
                if (i % 3 == 0 || i == 1 || i == 4 || i == 7)
                {
                    int double_pipe = 0;
                    for (int j = 0; j < 41; j++)
                    {
                        // Double Pipe (||)
                        if (j == double_pipe || j == double_pipe + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write('|');

                            // Update "double_pipe" variable
                            if (j == double_pipe + 1)
                                double_pipe += 13;
                        }
                        // (-)
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write('-');
                        }
                    }
                    Console.WriteLine();
                }
            }

            // Last Seperator
            Console.ForegroundColor = ConsoleColor.Cyan;
            Misc.Sequence(length: 41, character: '=', line_break: true);
            Console.ResetColor();
        }

        // If board filled
        public bool IsFilled()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i, j].Value == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
