namespace SOS_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Player player = new Player("Talha Ahmad");
            //player.IncreaseScore();
            //player.IncreaseScore();
            //player.IncreaseScore();
            //Console.WriteLine($"Name:\t{player.name}\nScore:\t{player.GetScore()}");

            //Cell cell = new Cell();
            //cell.Letter = 'O';
            //cell.Letter = 'S';
            //cell.Combined = true;
            //Console.WriteLine($"\nCell:\t{cell.Letter}\nComb:\t{cell.Combined}");

            Board myBoard = new Board();

            myBoard.PlaceLetterAt(1, 1, 'S');
            myBoard.PlaceLetterAt(1, 5, 'S');
            myBoard.PlaceLetterAt(3, 4, 'O');
            myBoard.PlaceLetterAt(5, 2, 'P');

            myBoard.Display();
        }
    }
}
