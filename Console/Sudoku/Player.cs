namespace Sudoku
{
    class Player
    {
        // Attribute
        public string name { get; }
        int score;

        // Constructor
        public Player(string name)
        {
            this.name = name;
            score = 0;
        }

        // Get the score
        public int GetScore()
        {
            return score;
        }

        // Increase / Decrease the score
        public void IncreaseScore()
        {
            score += 5;
        }

        public void DecreaseScore()
        {
            if (score >= 2)
                score -= 2;
        }
    }
}
