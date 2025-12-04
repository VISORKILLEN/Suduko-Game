namespace Suduko_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = SudukoGenerator.GenerateSuduko(40);
            bool gameRunning = true;
            while (gameRunning && !SudukoGenerator.isSolved(board))
            {
                Console.Clear();
                PrintBoard(board);
                Console.Write("Rad 1-9, 0 för av avsluta");
                
                if(!int.TryParse(Console.ReadLine(), out int r) || r<0 || r>9)
                {
                    continue;
                }

                if (r == 0)
                {
                    gameRunning = false;
                    break;
                }
            }

            Console.ReadKey();
        }

        //
        static void PrintBoard(int[,] board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    Console.Write(board[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
