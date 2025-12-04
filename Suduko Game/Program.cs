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
                Console.Write("\nRad 1-9, 0 för av avsluta: ");

                if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 9)
                {
                    continue;
                }

                if (r == 0)
                {
                    gameRunning = false;
                    break;
                }

                Console.Write("Kolumn (1-9): ");
                if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 9)
                {
                    continue;
                }

                Console.Write("Siffra (1-9): ");
                if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 9)
                {
                    continue;
                }

                if (SudukoGenerator.IsSafe(board, r - 1, c - 1, num))
                {
                    board[r - 1, c - 1] = num;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Siffra placerad");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltlig placering av nummer");
                    Console.ResetColor();
                }

                Console.WriteLine("Tryck på valfri tanget för att fortsätta.");
                Console.ReadKey();
            }

            if (SudukoGenerator.isSolved(board))
            {
                Console.Clear();
                PrintBoard(board);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Grattis! Du har löst Sudokut!");
                Console.ResetColor();
            }
        }

        //
        static void PrintBoard(int[,] board)
        {

            for (int r = 0; r < 9; r++)
            {
                if (r % 3 == 0 && r != 0)
                {
                    Console.WriteLine("------+-------+------");
                }

                for (int c = 0; c < 9; c++)
                {
                    if (c % 3 == 0 && c != 0)
                    {
                        Console.Write("| ");
                    }
                    int val = board[r, c];
                    Console.Write(val == 0 ? ". " : val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
