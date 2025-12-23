namespace Suduko_Game
{
    internal class Play4x4Suduko
    {
        static int[,] board = _4x4SudukoGenerator.Generate4x4Suduko();

        internal static void Run()
        {
            Play4x4SudukoGame();
        }

        internal static void Play4x4SudukoGame()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();

                bool gameRunning = true;
                while(gameRunning && !_4x4SudukoGenerator.is4x4Solved(board))
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nRad 1-4, 0 för att avluta:");
                    if (!int.TryParse(Console.ReadLine(), out int r) || r < 0 || r > 4)
                    {
                        continue;
                    }

                    if (r == 0)
                    {
                        gameRunning = false;
                        break;
                    }

                    Console.Write("Kolumn (1-4): ");
                    if (!int.TryParse(Console.ReadLine(), out int c) || c < 1 || c > 4)
                    {
                        continue;
                    }

                    Console.Write("Siffra (1-4): ");
                    if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > 4)
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

                SolvedBoard();
                RestartGame();
            }
            }

        }

    }
}
