namespace Suduko_Game
{
    internal class Easy9x9Suduko : PlayGame
    {
        static int[,] board = SudukoGenerator.GenerateSuduko(20);
        internal static void RunEasy()
        {
            PlayEasySuduko();
        }

        // Play easy 9x9 Suduko game
        internal static void PlayEasySuduko()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                bool gameRunning = true;
                while (gameRunning && !SudukoGenerator.isSolved(board))
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nRad 1-9, 0 för att avsluta: ");

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

                // Controlle if board is solved
                if (SudukoGenerator.isSolved(board))
                {
                    SolvedBoard();
                    Console.WriteLine("Tryck på valfri tanget för att återgå till menyn.");
                    Console.ReadKey();
                    playing = false;
                }
            }
        }
    }
}
