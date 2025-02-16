namespace SOS_Game
{
    class Cell
    {
        // Data
        char letter;
        bool combined;

        // Constructor
        public Cell()
        {
            letter = '-';
            combined = false;
        }

        // Getters and Setters
        public char Letter
        {
            get { return letter; }
            set
            {
                if (letter == '-')
                    if (value == 'S' || value == 'O')
                        letter = value;
            }
        }
        public bool Combined
        {
            get { return combined; }
            set
            {
                if (letter != '-')
                    combined = value;
            }
        }
    }
}
