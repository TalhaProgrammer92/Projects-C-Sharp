namespace SOS_Game
{
    class Player
    {
        // Data
        public string name { get; }
        int score;

        // Constructor
        public Player(string name)
        {
            this.name = name;
            score = 0;
        }

        // Increase score
        public void IncreaseScore()
        {
            score++;
        }

        // Get score
        public int GetScore()
        {
            return score;
        }

        // Take input from player
        public static int TakeInput(string message, int[] legalNumbers)
        {
            do
            {
                // Get the number
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message);
                int input = -1;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception e) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Entry!");
                }

                // Check input character
                foreach (var number in legalNumbers)
                    if (input == number)
                        return input;

                // Invalid entry
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out of Range!");
            } while (true);
        }
    }
}
