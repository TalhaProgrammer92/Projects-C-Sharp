namespace Sudoku
{
    class Misc
    {
        // Print a squence of characters
        public static void Sequence(int length, char character = ' ', bool line_break = false)
        {
            for (int i = 0; i < length; i++)
                Console.Write(character);
            if (line_break) LineBreak();
        }

        // Line Break
        public static void LineBreak()
        {
            Console.WriteLine();
        }

        // Check if a number is in range
        public static bool InRange(int number, int[] range)
        {
            for (int i = 0; i < range.Length; i++)
                if (number == range[i])
                    return true;
            return false;
        }

        // Get valid int from user
        public static int GetInput(string prompt, int[] valid_entries)
        {
            bool valid = false;
            while (true)
            {
                // Get number
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(prompt);
                    int number = Convert.ToInt32(Console.ReadLine());
                    
                    if (InRange(number, valid_entries))
                    {
                        Console.ResetColor();
                        return number;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Out of range entry!\n");
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid Entry!\n");
                }
            }
        }
    }
}
