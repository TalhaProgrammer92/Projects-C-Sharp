namespace Sudoku
{
    class Cell
    {
        // Attributes
        byte value;
        public bool valid;
        bool fixed_;

        // Constructor
        public Cell()
        {
            value = 0;
            valid = false;
            fixed_ = false;
        }

        // Property
        public byte Value
        {
            get { return this.value; }
            set
            {
                if (!fixed_)
                    if (value > 0 && value <= 9)
                        this.value = value;
            }
        }

        // Make Fixed
        public void MakeFixed()
        {
            if (value != 0)
                fixed_ = true;
        }

        // Get Fixed Status
        public bool IsFixed()
        {
            return fixed_;
        }
    }
}
